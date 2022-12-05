using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Spline_Interpolation__CSharp_
{
    public partial class InterpolationForm : Form
    {
        public Picture Picture { get; private set; } //Aquí irán guardadas las secciones y puntos para dibujar
        public Picture InterpolationPicture { get; private set; } //En este Picture se guardará el original cuando se Interpole
        public int AddPointCounter { get; private set; }//Este bool sirve para auxiliar al método de añadir puntos
        public Point AddPoint { get; private set; }//Este punto sirve para auxiliar al método de añadir puntos
        public bool NumericPut { get; private set; }//Este bool sirve para auxiliar al método de pintado a partir del cambio de valor del NumericPoint
        public bool ShowVector { get; private set; }//Este bool sirve para auxiliar al método de mostrar los vectores directores de los puntos

        public InterpolationForm()
        {
            InitializeComponent();

            this.Picture = new Picture();//Inicializamos la pintura que será vista en el PictureBox
            this.Picture.AddSection(new Section("NoName"));//Le agregamos una sección para que esta no sea null
            this.WFSectionNameTextBox.Text = this.Picture.sections[0].sectionname;//Colocamos el nombre de la sección en el TextBox correspondiente

            this.AddPointCounter = -1;//Inicializamos el contador auxiliar en 0
            this.ShowVector = false;
            this.NumericPut = false;

            this.WFInterpolationMenuGroupBox.Enabled = false;
        }

        #region Numerics
        private void WFActualPointNumeric_ValueChanged(object sender, EventArgs e)//Método que indica que ocurre al cambiar el valor del Numeric
        {
            if (this.NumericPut == false)//Este está porque, si estamos cambiando los numeric a mano, no podemos repintar el PictureBox
            {
                this.WFPainterPictureBox.Refresh();//Actualizamos el Picture Box
            }
        }

        private void WFActualSectionNumeric_ValueChanged(object sender, EventArgs e)//Método que indica que ocurre al cambiar el valor del Numeric
        {//Actualizamos el máximo del numeric del punto actual
            this.WFActualPointNumeric.Maximum = this.Picture.sections[(int)this.WFActualSectionNumeric.Value - 1].points.Count();
            this.WFActualPointNumeric.Value = WFActualPointNumeric.Maximum == 0 ? 0 : 1;//Modificamos el valor del numeric
            this.WFPainterPictureBox.Refresh();//Actualizamos el picture box
        }

        #endregion

        #region Buttons

        private void WFAddSectionButton_Click(object sender, EventArgs e) //Mediante este botón añadimos una nueva sección
        {
            this.Picture.AddSection(new Section("NoName"));
            this.WFActualSectionNumeric.Maximum++;
        }

        private void WFRemoveSectionButton_Click(object sender, EventArgs e)//Mediante este método podemos remover una sección
        {
            if(this.WFActualSectionNumeric.Maximum == 1)//Si solo nos queda una, lanzamos un mensaje
            {
                MessageBox.Show("Debes tener al menos una sección");
                return;
            }

            this.Picture.sections.RemoveAt((int)this.WFActualSectionNumeric.Value - 1);//En otro caso la eliminamos
            this.WFActualSectionNumeric.Value--;//Disminuímos el valor actual del Numeric
            this.WFActualSectionNumeric.Maximum--;//Y su máximo valor posible
            this.WFPainterPictureBox.Refresh();
        }

        private void WFConnectSectionsButton_Click(object sender, EventArgs e)//Mediante este método podemos conectar la sección actual con cualquier otra sección
        {//Con conectar nos referimos a que el último punto de una sección es igual al primero de otra
            if (this.WFConnectSectionNumeric.Value == this.WFActualSectionNumeric.Value) //Si estamos en la misma sección, no hacemos nada
            {
                MessageBox.Show("Debes conectar secciones diferentes");
                return;
            }

            //Para no hacer una línea extremadamente larga, dividimos el proceso por partes
            int count = this.Picture.sections[(int)this.WFActualSectionNumeric.Value - 1].points.Count();//Obtenemos el count de la sección actual
            Point temporal = this.Picture.sections[(int)this.WFActualSectionNumeric.Value - 1].points[count - 1]; //Luego obtenemos el punto
            this.Picture.sections[(int)this.WFConnectSectionNumeric.Value - 1].AddPoints(temporal, 0);//Por último, lo agregamos a la primera sección del otro
            this.WFPainterPictureBox.Refresh();
        }

        private void WFAddPointButton_Click(object sender, EventArgs e)
        {
            this.AddPointCounter = 1;
            this.WFSectionsGroupBox.Enabled = false; //Hacemos que el usuario no pueda tocar ningún otro botón mientras tanto
            this.WFAddPointButton.BackColor = Color.DarkGray;//Le cambiamos el color al botón para que se sepa que está presionado
        }

        private void WFRemovePointButton_Click(object sender, EventArgs e) //Con este botón removemos el punto actual de la sección actual
        {
            if(this.Picture.sections[(int)this.WFActualSectionNumeric.Value - 1].points.Count() == 0)//Si no existen puntos en esta sección, avisamos de ello
            {
                MessageBox.Show("No exiten puntos para remover");//Lanzamos el mensaje
                return;//Terminamos el método
            }
            //Removemos el punto
            this.Picture.sections[(int)this.WFActualSectionNumeric.Value - 1].points.RemoveAt((int)this.WFActualPointNumeric.Value - 1);
            if(WFActualPointNumeric.Maximum == 1)//Si solo tenemos un punto
                this.WFActualPointNumeric.Minimum--;//Disminuímos el mínimo
            this.WFActualPointNumeric.Maximum--;//Disminuímos el máximo valor posible
            this.WFPainterPictureBox.Refresh();
        }

        private void WFChangeNameButton_Click(object sender, EventArgs e)//Este botón sirve para cambiar el nombre de la sección actual
        {
            if(this.WFChangeNameTextBox.Text == null || this.WFChangeNameTextBox.Text == "")//Si no se ha escrito nada, se da el aviso
            {
                MessageBox.Show("Debes escribir un nombre válido para la sección");//Lanzamos el mensaje
                return;//Terminamos el método
            }

            this.WFSectionNameTextBox.Text = this.WFChangeNameTextBox.Text;//Cambiamos lo que muestra el texto
            //Cambiamos el nombre de la sección
            this.Picture.sections[(int)this.WFActualSectionNumeric.Value - 1].ChangeName(this.WFChangeNameTextBox.Text);
            this.WFChangeNameTextBox.Text = "";//Borramos lo escrito
        }

        private void WFShowVectorButton_Click(object sender, EventArgs e)//Mediante este botón podemos mostrar los vectores directores asociados a los puntos
        {//Este método funciona a partir de un booleano auxiliar
            if(this.ShowVector)//Si el botón estaba presionado
            {
                this.WFShowVectorButton.BackColor = Color.LightGray;//Cambiamos el color del botón
                this.ShowVector = false;//Colocamos el booleano en falso
            }
            else//Si no está presionado hacemos lo contrario
            {
                this.WFShowVectorButton.BackColor = Color.DarkGray;
                this.ShowVector = true;
            }

            this.WFPainterPictureBox.Refresh();
        }

        private void WFSaveButton_Click(object sender, EventArgs e)
        {
            string directory = ""; //Creamos un string vacío que será el que guardará el directorio del lugar en el que queremos almacenar la información
            SaveFileDialog save = new SaveFileDialog(); //Abrimos un SaveFileDialog, encargado de buscar una dirección para colocar ahí el archivo
            if (save.ShowDialog() == DialogResult.OK) //En caso de que haya sido elegido un archivo, guardamos su directorio
                directory = save.FileName;

            if (directory == "") //En caso de que el directorio esté vacío quiere decir que no fue elegido ningún directorio, por tanto avisamos al usuario y nos detenemos
            {
                MessageBox.Show("Debes elegir una ubicación para salvar tu rutina");
                return;
            }
            //En caso de que sea válido utilizamos la clase SteamWrite, la cual, mediante un directorio crea un archivo, le agregamos la extensión txt para que el archivo sea legible a modo de txt
            StreamWriter writer = new StreamWriter(directory + ".txt");

            writer.WriteLine(this.Picture.sections.Count().ToString());//Lo primero que escribimos es el número de secciones

            for(int i = 0; i < this.Picture.sections.Count; i++)//Luego, por cada sección
            {//Escribiremos la cantidad de puntos de la sección seguido del nombre de la misma
                writer.WriteLine(this.Picture.sections[i].points.Count().ToString() + " " + this.Picture.sections[i].sectionname);

                for(int j = 0; j < this.Picture.sections[i].points.Count(); j++)//Luego, por cada punto en la sección
                {
                    Point temporal = this.Picture.sections[i].points[j];//Guardamos el punto en un temporal
                    //Escribimos los x e y del punto ,así como los a y b del vector director asociado
                    writer.WriteLine(temporal.x.ToString() + " " + temporal.y.ToString() + " " + temporal.vector.a.ToString() + " " + temporal.vector.b.ToString());
                }
            }

            writer.Dispose();//Mediante el Dispose le damos formato al writer (si no lo hacemos da errores raros...)
        }

        private void WFLoadButton_Click(object sender, EventArgs e)
        {
            this.Picture.CleanAll();

            string directory = ""; //Creamos un string vacío que será aquel que guardará el directorio
            OpenFileDialog search = new OpenFileDialog(); //Creamos un OpenFileDialog
            if (search.ShowDialog() == DialogResult.OK) //Mediante su propiedad ShowDialog podemos abrir una ventana en la que el usuario puede elegir un archivo, donde le tomaremos el directorio para poder cargarlo
                directory = search.FileName; //Guardamos el directorio en nuestro string

            if (directory == "") //En caso de que el string esté vacío, debemos lanzar un MessageBox y detenemos el método
            {
                MessageBox.Show("Debe elegir un archivo");
                return;
            }

            try //Mediante un try controlamos las posibles excepciones que pueden lanzar
            {
                StreamReader charger = new StreamReader(directory); //Mediante esta clase (tomada de System.IO), podemos leer lo que está escrito en un documento legible

                int sectioncounter = int.Parse(charger.ReadLine());//Guardamos el número de secciones

                for(int i = 0; i < sectioncounter; i++)//Hacemos un for que itere por todas ellas
                {
                    string[] temporalsection = charger.ReadLine().Split(' ');//Guardamos la cantidad de puntos y el nombre de la sección en un temporal
                    this.Picture.sections.Add(new Section(temporalsection[1]));//Creamos la sección con el nombre designado

                    for(int j = 0; j < int.Parse(temporalsection[0]); j++)//Por cada punto iremos iterando nuevamente
                    {
                        string[] pointtemporal = charger.ReadLine().Split(' ');//Guardamos el x, y del punto, así como el a y b de su vector director para crear un nuevo punto
                        //Añadimos el punto
                        this.Picture.sections[i].points.Add(new Point(float.Parse(pointtemporal[0]), float.Parse(pointtemporal[1]), float.Parse(pointtemporal[2]), float.Parse(pointtemporal[3])));
                    }
                }
            }
            catch (Exception a) //En caso de que ocurra una excepción, exiten tres posibilidades
            {
                if (a is FormatException) //La primera es que sea debido a que eligieron un archivo no legible, por tanto, le avisamos al usuario de ello
                    MessageBox.Show("Debe elegir un archivo que sea legible(ej: .txt)");

                if (a is NullReferenceException || a is IndexOutOfRangeException)//La segunda es que hayan dado un números de instrucciones superior a la cantidad de instrucciones, en este caso el split dará un NullReferenceException
                    MessageBox.Show("El archivo leído no es correcto");

                else //En caso de que no ocurran las anteriores, mostramos la excepción
                    MessageBox.Show(a.Message);

                this.Picture.CleanAll();//Si ocurrió un error limpiamos el picture
                return;
            }

            //Ahora tenemos que reestrablecer todos los numerics
            this.NumericPut = true;//Para no entrar al método Refresh en vano
            if(this.Picture.sections.Count == 0)//En caso de que no hayan secciones ni puntos, creamos uno desde 0 con valores predeterminados
            {
                this.Picture.sections.Add(new Section("NoName"));
                this.WFSectionNameTextBox.Text = "NoName";

                this.WFActualPointNumeric.Maximum = 0;
                this.WFActualPointNumeric.Minimum = 0;
                this.WFActualPointNumeric.Value = 0;

                this.WFActualSectionNumeric.Maximum = 1;
                this.WFActualSectionNumeric.Value = 1;

                this.WFConnectSectionNumeric.Maximum = 1;
                this.WFConnectSectionNumeric.Value = 1;
            }
            else//Si existían secciones
            {
                if (this.Picture.sections[0].points.Count() == 0)//Si la primera no tenía puntos, entonces
                {//Modificamos los numeric de la siguiente forma
                    
                    this.WFActualPointNumeric.Maximum = 0;
                    this.WFActualPointNumeric.Minimum = 0;
                    this.WFActualPointNumeric.Value = 0;

                    this.WFActualSectionNumeric.Maximum = this.Picture.sections.Count();
                    this.WFActualSectionNumeric.Value = 1;

                    this.WFConnectSectionNumeric.Maximum = this.Picture.sections.Count();
                    this.WFConnectSectionNumeric.Value = 1;
                }
                else//Si tenía puntos, lo hacemos de esta forma
                { 
                    this.WFActualPointNumeric.Maximum = this.Picture.sections[0].points.Count();
                    this.WFActualPointNumeric.Minimum = 1;
                    this.WFActualPointNumeric.Value = 1;

                    this.WFActualSectionNumeric.Maximum = this.Picture.sections.Count();
                    this.WFActualSectionNumeric.Value = 1;

                    this.WFConnectSectionNumeric.Maximum = this.Picture.sections.Count();
                    this.WFConnectSectionNumeric.Value = 1;
                }

                this.WFSectionNameTextBox.Text = this.Picture.sections[0].sectionname;//Actualizamos el nombre de la sección
            }
            this.NumericPut = false;
            this.WFPainterPictureBox.Refresh();
        }

        private void WFInterpolationStartButton_Click(object sender, EventArgs e)//Botón que inicia la interpolación
        {//Básicamente devolvemos la capacidad de presionar los botones para interpolar y detenemos la de los otros
            this.WFInterpolationMenuGroupBox.Enabled = true;
            this.WFSaveLoadGroupBox.Enabled = false;
            this.WFSectionsGroupBox.Enabled = false;

            this.InterpolationPicture = this.Picture.Clone(); //Guardamos una copia de Picture, puesto que perderemos el original al interpolar
        }

        private void WFEndInterplationButton_Click(object sender, EventArgs e)//Botón que finaliza la interpolación
        {//Devolvemos la capacidad de presionar los botones que no sean de interpolación y detenemos los de interpolación
            this.WFInterpolationMenuGroupBox.Enabled = false;
            this.WFSaveLoadGroupBox.Enabled = true;
            this.WFSectionsGroupBox.Enabled = true;

            this.Picture = this.InterpolationPicture; //Devolvemos Picture a su estado original
            this.InterpolationPicture = null;//Hacemos null InterpolationPicture
            this.WFPainterPictureBox.Refresh();
        }

        private void WFInterpolationButton_Click(object sender, EventArgs e)//Con este botón procedemos a interpolar
        {
            int count = (int)this.WFPointsNumberNumeric.Value;//Guardamos en un int la cantidad de puntos a interpolar
            this.Picture = this.InterpolationPicture.Clone();//Hacemos que Picture sea un clon del original

            while (count > 0)//Mientras count sea mayor que 0
            {
                for (int i = 0; i < this.Picture.sections.Count(); i++)//Vamos por todas las secciones
                {
                    if (count < this.Picture.sections[i].points.Count() - 1)//Si tenemos menos puntos para interpolar que la cantidad de puntos de la lista
                    {//Es count-1 puesto que solo podemos interpolar entre un punto y otro una vez
                        this.Picture.sections[i].InterpolationCycle(count);//Entramos al método con el contador
                        this.WFPainterPictureBox.Refresh();//Reiniciamos el PictureBox
                        return;//Detenemos la interpolación
                    }

                    count -= this.Picture.sections[i].points.Count();//Le restamos a count la cantidad de puntos de la lista
                    count++;//Aumentamos en 1 count puesto que en la operación anterior restamos 1 de más
                    this.Picture.sections[i].InterpolationCycle();//Hacemos un ciclo de interpolación
                    
                }
            }

            this.WFPainterPictureBox.Refresh();//Reiniciamos el PictureBox
        }

        #endregion

        #region PictureBox

        private void WFPainterPictureBox_MouseClick(object sender, MouseEventArgs e)
        {//El Mouse Click funciona según los botones presionados, pasando uno por uno
            
            if(this.AddPointCounter != -1)//Si este contador no es 0, fue presionado el botón de agregar
            {
                if (this.AddPointCounter == 1)//Si está en la primera fase
                {
                    this.AddPoint = new Point(e.X, e.Y);//Guardamos el punto actual
                    this.AddPointCounter++;//Aumentamos el contador para en el próximo click hacer la fase dos
                }
                else//Si el contador no está en 1, es que estamos en la segunda fase
                {
                    if (this.WFActualPointNumeric.Value == 0)//Primero tenemos que actualizar el Numeric, en caso de ser 0, es que no tiene puntos
                    {
                        this.NumericPut = true;//Cambiamos el booleano para no entrar en el método Refresh del Picture Box al cambiar el valor del Numeric
                        this.WFActualPointNumeric.Maximum = 1;//Colocamos el máximo y mínimo posibles y el valor en 1
                        this.WFActualPointNumeric.Minimum = 1;
                        this.WFActualPointNumeric.Value = 1;
                        this.NumericPut = false;//Lo devolvemos a falso
                    }
                    else//En caso de que no sea el primer punto, simplmente aumentamos el máximo para elegir
                        this.WFActualPointNumeric.Maximum++;

                    //Luego pasamos a la parte interesante de la fase dos, agregarle al punto que guardamos su vector director
                    this.AddPoint.PutVector(Point.Parametrization(this.AddPoint, new Point(e.X, e.Y)));//Lo agregamos mediante el método Parametrization
                    this.AddPointCounter = -1;//Reiniciamos el contador y agregamos el punto
                    this.Picture.sections[(int)this.WFActualSectionNumeric.Value - 1].AddPoints(this.AddPoint, (int)this.WFActualPointNumeric.Value - 1);
                    this.AddPoint = null; //Hacemos null el punto
                    this.WFAddPointButton.BackColor = Color.LightGray;//Le cambiamos el color al botón para que se sepa que ya no está presionado
                    this.WFSectionsGroupBox.Enabled = true; //Le devolvemos al usuario la capacidad de presionar botones
                }
                this.WFPainterPictureBox.Refresh();
                return;//Detenemos el método
            }
            
        }

        private void WFPainterPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; //Usamos esto para no pedir constantemente el Graphics de e
            SolidBrush c = new SolidBrush(Color.White); //Creamos una brocha que pintará en blanco el fondo de las casillas

            g.FillRectangle(c, e.ClipRectangle); //Ni idea...

            Pen black = new Pen(Color.Black, 1); //Creamos un lapiz que dibujará en negro las casillas
            Pen red = new Pen(Color.Red, 1); //Creamos otro lapiz que dibujará en rojo el punto actual

            //Ahora iremos dibujando los diferentes puntos que han sido guardados
            for(int i = 0; i < this.Picture.sections.Count(); i++)//Vamos por todas las secciones
            {
                for(int j = 0; j < this.Picture.sections[i].points.Count(); j++)//Y por todos los puntos de cada una
                {
                    Point temporal = this.Picture.sections[i].points[j];//Guardamos el punto actual en un temporal
                    //Ahora, dibujamos el punto, de esta forma para que sea más visible
                    g.DrawLine(black, temporal.x - 1, temporal.y, temporal.x + 1, temporal.y);
                    g.DrawLine(black, temporal.x, temporal.y - 1, temporal.x, temporal.y + 1);
                    
                    if(this.ShowVector)
                    {
                        Point a = Point.Evaluate(temporal, -20);
                        Point b = Point.Evaluate(temporal, 20);

                        g.DrawLine(black, a.x, a.y, b.x, b.y);
                    }
                }
            }

            //Ahora pasamos a dibujar el punto que actualmente está seleccionado
            if (this.WFActualPointNumeric.Value != 0)//En caso de que exista un punto seleccionado claro está
            {//Guardamos el punto en un temporal
                Point select = this.Picture.sections[(int)this.WFActualSectionNumeric.Value - 1].points[(int)this.WFActualPointNumeric.Value - 1];
                g.DrawLine(red, select.x - 2, select.y, select.x + 2, select.y);//Lo dibujamos de rojo
                g.DrawLine(red, select.x, select.y - 2, select.x, select.y + 2);
                
            }

            if (this.AddPoint != null)//También dibujamos el punto que esté guardado temporalmente en AddPoint
            {
                g.DrawLine(black, this.AddPoint.x - 1, this.AddPoint.y, this.AddPoint.x + 1, this.AddPoint.y);
                g.DrawLine(black, this.AddPoint.x, this.AddPoint.y - 1, this.AddPoint.x, this.AddPoint.y + 1);
            }
        }


        #endregion
    }
}
