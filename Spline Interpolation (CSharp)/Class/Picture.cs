using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spline_Interpolation__CSharp_
{
    public class Picture
    {//Clase que contendrá las diferentes secciones de la mano
        public List<Section> sections { get; private set; }//Esta es la lista de secciones

        public Picture()//Constructor de la clase
        {
            this.sections = new List<Section>();
        }

        public void AddSection(Section section)//Añade una sección a la lista
        {
            this.sections.Add(section);

        }
        public void CleanSections()//Limpia todos los puntos en la secciones actuales
        {
            for (int i = 0; i < this.sections.Count(); i++)
            {
                this.sections[i].Clean();
            }
        }

        public void CleanAll()//Borra todas las secciones actuales
        {
            this.sections = new List<Section>();
        }

        public Picture Clone()
        {
            Picture temporal = new Picture();//Creamos el Picture que será devuelto más tarde

            for(int i = 0; i < this.sections.Count(); i++)//Iteramos por cada una de sus secciones
            {
                temporal.AddSection(this.sections[i].Clone());//Le colocamos un clon de cada sección
            }

            return temporal;//Retornamos el temporal
        }
    }
}
