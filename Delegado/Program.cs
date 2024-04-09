namespace Delegado
{
    internal class Program
    {
        public delegate void Estadisticas(int[] numeros);
        static void Main(string[] args)
        {
            Estadisticas delegaStats;
            int[] numeroOperar = {10, 100, 20, 30, 40};
            delegaStats = Escribir;
            delegaStats +=Organizar;
            delegaStats +=Media;
            delegaStats +=Max;
            delegaStats +=Min;
            delegaStats += Rango;

            delegaStats(numeroOperar);
        }

        static void Media(int[] numeros)
        {
            int sum = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                sum += numeros[i];
            }
            int media = sum/numeros.Length;
            Console.Write("La media de los numeros es: ");
            Console.WriteLine(media);
        }
        static void Organizar(int[] numeros)
        {
            Array.Sort(numeros);
            
            Console.Write("Organizados en orden ascendente:"+"\n");
            for (int i = 0;i < numeros.Length;i++)
            {
                Console.Write(numeros[i]+", ");
            }
            Console.WriteLine();
        }
        static void Escribir(int[] numeros)
        { 
            Console.Write("Los números dados son:" + "\n");
            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write(numeros[i] + ", ");
            }
            Console.WriteLine();
        }
        static void Max(int[] numeros)
        {
            int max = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                if (max <= numeros[i])
                {
                    max = numeros[i];
                }
            }
            Console.Write("El máximo es: ");
            Console.WriteLine(max);
        }
        static void Min(int[] numeros)
        {
            int min = numeros[0];
            for (int i = 0; i < numeros.Length; i++)
            {
                if (min >= numeros[i])
                {
                    min = numeros[i];
                }
            }
            Console.Write("El mínimo es: ");
            Console.WriteLine(min);
        }
        static void Rango(int[] numeros)
        {
            int min = numeros[0];
            int max = numeros[0];
            for (int i = 0; i < numeros.Length; i++)
            {
                if (min >= numeros[i])
                {
                    min = numeros[i];
                }
                if (max <= numeros[i])
                {
                    max = numeros[i];
                }
            }
            Console.WriteLine("El rango es: "+ (max-min));
        }


    }
}