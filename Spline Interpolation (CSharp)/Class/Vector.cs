using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spline_Interpolation__CSharp_
{
    public class Vector //Clase vector, utilizada para simular la ecuación paramétrica de la recta
    {
        public float a { get; private set; }//Tenemos que valores dos float, que son las componentes a y b del vector
        public float b { get; private set; }
        public Vector(float a, float b)//Constructor de la clase
        {
            if (a == 0 && b == 0)//En caso de que ambos sea 0, los colocamos así
            {
                this.a = a;
                this.b = b;
            }
            else//Si no
            {
                double norm = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));//Calculamos la norma de los vectores
                this.a = a / (float)norm;//Los guardados divididos sobre su norma
                this.b = b / (float)norm;
            }//Con esto garantizamos que estén normalizados
        }
    }
}
