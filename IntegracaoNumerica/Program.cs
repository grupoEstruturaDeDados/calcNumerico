namespace IntegracaoNumerica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //intervalo inferior
            double a = 0;

            //intervalo superior
            double b = 1;

            //número de partições
            int n = 100000;

            //deltaX
            double deltaX = (b - a) / n;

            Console.WriteLine($"Intervalo inferior: {a}\nIntervalo Superior: {b}\nNúmero de partições: {n}\nDeltaX: {deltaX}\n");
            Riemann(a, n, deltaX);
            TrapezioRepetido(a, b, n, deltaX);
            TrapezioSimples(a, b, n, deltaX);
            UmTercoDeSimpsonRepetida(a, b, n, deltaX);
        }

        private static void Riemann(double a, int n, double deltaX)
        {
            double somaRiemann = 0;

            for (int i = 0; n > 0; i++, n--)
            {
                double x = a + i * deltaX;
                somaRiemann += Funcao(x) * deltaX;
            }

            Console.WriteLine($"Método soma de Riemann: {somaRiemann}");
        }

        private static void TrapezioRepetido(double a, double b, int n, double deltaX)
        {
            double soma1 = 0;
            double soma2 = 0;
            int contador = n;

            for (int i = 0; contador > 0; i++, contador--)
            {
                double x = a + i * deltaX;

                if (i == 0 || i == n)
                {
                    soma1 += Funcao(x);
                }
                else
                {
                    soma2 += 2 * Funcao(x);
                }
            }

            double somaTrapRepetido = (soma1 + soma2) * (deltaX / 2);
            Console.WriteLine($"Método Trapézio Repetido: {somaTrapRepetido}");
        }

        private static void TrapezioSimples(double a, double b, int n, double deltaX)
        {
            double somaTrapSimples = 0.5 * (Funcao(a) + Funcao(b));
            int aux = n;
            for (int i = 0; aux > 0; i++, aux--)
            {
                double x = a + i * deltaX;
                somaTrapSimples += Funcao(x);
            }

            Console.WriteLine($"Método Trapézio Simples: {somaTrapSimples * deltaX}");
        }

        private static void UmTercoDeSimpsonRepetida(double a, double b, int n, double deltaX)
        {
            double soma1 = 0;
            double soma2 = 0;
            double soma3 = 0;
            int contador = n;

            for (int i = 0; contador > 0; i++, contador--)
            {
                double x = a + i * deltaX;

                if(i==0 || i == n)
                {
                    soma1 += Funcao(x);
                }
                else if(i%2 == 0)
                {
                    soma2 += 2 * Funcao(x);
                }
                else
                {
                    soma3 += 4 * Funcao(x);
                }
            }

            double somaUmTercoDeSimpsonRepetida = (soma1 + soma2 + soma3) * (deltaX / 3);
            Console.WriteLine($"Método 1/3 de Simpson Repetida: {somaUmTercoDeSimpsonRepetida}");

        }

        private static double Funcao(double x)
        {
            return Math.Exp(x);
        }
    }
}