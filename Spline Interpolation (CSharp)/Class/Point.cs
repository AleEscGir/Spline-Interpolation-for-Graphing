using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spline_Interpolation__CSharp_
{
    public class Point
    {//Clase Punto
        public float x { get; private set; }//Esta clase tiene un punto X y Y
        public float y { get; private set; }
        public Vector vector { get; private set; }//Y tiene un Vector director asociado
        //Ese vector sirve para trabajar con ecuaciones paramétricas de la recta
        public Point(float x, float y)//Esta inicialización solo requiere dos puntos
        {
            this.x = x;
            this.y = y;
            this.vector = new Vector(0, 0);//Inicializamos el vector en 0,0
        }

        public Point(float x, float y, float a, float b)//Esta inicizalización requiere dos puntos más
        {
            this.x = x;
            this.y = y;
            this.vector = new Vector(a, b);
        }

        public Point(float x, float y, Vector vector)//Esta inicizalización obtiene directamente el vector
        {
            this.x = x;
            this.y = y;
            this.vector = vector;
        }

        public void PutVector(Vector vector)//Mediante este método agregamos un vector director al punto
        {
            if (vector == null)//Si es null lanzamos excepción
                throw new Exception("No se puede agregar un vector vacío");

            this.vector = vector;//Colocamos el vector
        }

        public Point Clone()//Mediante esta propiedad devolvemos un clon del punto
        {
            return new Point(this.x, this.y, this.vector.a, this.vector.b);
        }

        public static Point Evaluate(Point point, int t) //Este método, dado un punto y un entero, devuelve el punto resultante
        {//de evaluar ese entero en la ecuación paramétrica de la forma x = xo + t*a, y = y0 + t*b
            return new Point(point.x + t * point.vector.a, point.y + t * point.vector.b, 0, 0);
        }

        public static Vector Parametrization(Point P1, Point P2)//Este método, dado dos puntos, devuelve el vector director
        {//Nota: Después intercambiar P1 y P2, para que sea mejor al usuario
            float a = P1.x - P2.x;//Para ello restamos las X y Y de ambos vectores
            float b = P1.y - P2.y;
            return new Vector(a, b);//Devolvemos dicho vector
        }

        public static Point Intercept(Point P1, Point P2)//Este método devuelve el punto resultante de la intersección de dos vectores directores
        {//Lo sieguiente son cosas de Matemática Numérica
            if (Math.Abs(P1.vector.a - P2.vector.a) < 0.000000001)//En caso de que el componente A de dos vectores sea iguales
            {
                if (Math.Abs(P1.vector.b - P2.vector.b) < 0.000000001)//Comprobamos que B tambiém sea igual
                    return null;
                    //throw new Exception("Ambos Vectores directores son iguales, imposible realizar la operación");
            }

            float[] first = { P1.vector.a, -P2.vector.a, P2.x - P1.x };
            float[] second = { P1.vector.b, -P2.vector.b, P2.y - P1.y};

            Tuple<float, float> solution = Matrix.LinealSystem(first, second);

            //Luego, con dicho t, calculamos los nuevos x1 y y1
            float x1 = P1.x + solution.Item1 * P1.vector.a;//Despeje de la fórmula x = x0 + a*t
            float y1 = P1.y + solution.Item1 * P1.vector.b;//Despeje de la fórmula y = y0 + b*t

            return new Point(x1, y1);//Retornamos el nuevo punto
        }

        public static float Distance(Point P1, Point P2)//Método para hallar la distancia entre dos puntos
        {
            return (float)(Math.Sqrt(Math.Pow(P1.x - P2.x, 2) + Math.Pow(P1.y - P2.y, 2)));
        }

        public static Point MiddlePoint(Point P1, Point P2)//Método para hallar el punto medio entre dos puntos
        {
            return new Point((P1.x + P2.x) / 2, (P1.y + P2.y) / 2);
        }
    }
}
