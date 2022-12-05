using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spline_Interpolation__CSharp_
{
    static class Matrix//Esta clase estática sirve para resolver un sistema lineal de dos con dos
    {
        public static Tuple<float, float> LinealSystem(float[] a, float[] b)//Método para resolver el sistema lineal
        {//Recibe dos arrays de dobles como parámetros de entrada, que simulan una matriz de 2X3 Ampliada
            if(Math.Abs(a[0]) < Math.Abs(b[0]))//Para evitar errores de división con los double, colocamos el más grande primero
            {
                float[] temp = a;
                a = b;
                b = temp;
            }

            if(Math.Abs(b[0]) > 0.00000001)//Si ya el primer parámetro es 0, no hace falta trabajar con las ecuaciones
            {//En otro caso
                //La idea será multiplicar toda la segunda fila por a[0], y luego restarle
                //el anterior b[0]*a[i], esto nos garantiza que b[0] será 0
                float temp = b[0];
                for(int i = 0; i < 3; i++)
                {
                    b[i] = b[i] * a[0];
                    b[i] = b[i] - temp * a[i];
                }
            }

            float second = b[2] / b[1];//El segundo valor de la matriz será el de la segunda fila
            float first = (a[2] - a[1] * second) / a[0];//El primer oserá un despeje usando el de la segunda
            return new Tuple<float, float>(first, second);
        } 
    }
}
