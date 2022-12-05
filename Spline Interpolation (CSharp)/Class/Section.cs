using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spline_Interpolation__CSharp_
{
    public class Section//Esta clase contiene un nombre y la lista de puntos asociadas a la sección
    {
        public List<Point> points { get; private set; }
        public string sectionname { get; private set; }

        public Section(string sectionname)//Constructor de la clase
        {
            this.sectionname = sectionname;
            this.points = new List<Point>();
        }

        public void ChangeName(string name) //Mediante este método podemos cambiar el nombre de la sección
        {
            if (name == null || name == "")
                return;
            this.sectionname = name;
        }

        public void AddPoints(Point point) //Dado un punto, este es añadido a la lista de puntos
        {
            this.points.Add(point);
        }
        public void AddPoints(Point point, int pos) //Dado un punto y una posición, este es añadido a la lista de puntos en dicha posición
        {
            if (pos < 0 || pos > this.points.Count()) //Si el punto está fuera de los índices de la lista (sin incluir el propio Count) lanzamos excepción
                throw new Exception("Índice fuera de la lista de puntos");

            if(pos == this.points.Count())//En caso de que esté justo después de la última posición
            {
                this.points.Add(point);//Lo añadimos
                return;//Terminamos
            }

            this.points.Insert(pos, point);//En otro caso lo insertamos
        }

        private bool InterpolatePoint(int pos1, int pos2)//Método para, dado dos puntos con vectores directores hallar un nuevo punto
        {//Devuelve true si la Interpolación fue exitosa, false en otro caso
            //Primero hallamos el vector director del nuevo punto, que será el que crean los dos puntos elegidos
            Vector vector = Point.Parametrization(this.points[pos1], this.points[pos2]);

            //Luego buscamos el punto resultante de la intercepción de los vectores directores de ambos puntos
            Point temporal = Point.Intercept(this.points[pos1], this.points[pos2]);

            if (temporal == null)
                return false;

            //Buscamos también el punto medio entre ambos puntos
            Point middle = Point.MiddlePoint(this.points[pos1], this.points[pos2]);

            //Por último, nuestro punto será el punto medio entre ambos puntos hallados
            Point newpoint = Point.MiddlePoint(middle, temporal);
            newpoint.PutVector(vector);//Le colocamos el vector director al nuevo punto

            this.points.Insert(pos2, newpoint);//Lo insertamos entre ambos puntos en la lista de puntos
            return true;
        }

        public void InterpolationCycle()//Mediante este método procedemos a interpolar totalmente en la lista de puntos
        {
            for (int i = 0; i < this.points.Count() - 1; i += 2)//El for aumenta de dos en dos puesto que en
            {//cada interpolación se añade un punto entre los dos actuales
                this.InterpolatePoint(i, i + 1);
            }
        }

        public void InterpolationCycle(int number)//Mediante este método procedemos a interpolar solo una cantidad limitada de puntos
        {//Esta vez el método tendrá un contador como parámetro de entrada

            bool interpolate = true; //booleano para saber si tuvo éxito la interpolación

            for (int i = 0; i < this.points.Count() - 1; i += interpolate? 2:1)//Si logramos interpolar
            {//Aumentamos en dos el contador, puesto que colocamos un punto nuevo, en otro caso vamos al punto siguiente
                number--;//Disminuímos el contador
                if (number < 0)//Si es menor que 0, terminamos
                    return;
                interpolate = this.InterpolatePoint(i, i + 1);//En otro caso interpolamos
            }
        }

        public void Clean()//Elimina todos los puntos actuales
        {
            this.points = new List<Point>();
        }

        public Section Clone()//Mediante esta propiedad devolvemos un clon de la sección
        {
            Section temporal = new Section(this.sectionname);//Creamos la sección que devolveremos más tarde

            for (int i = 0; i < this.points.Count(); i++)//Vamos por todos los puntos
            {
                temporal.AddPoints(this.points[i].Clone());//Agregamos un clon de cada punto a dicha sección
            }

            return temporal;//Retornamos la sección
        }
    }
}
