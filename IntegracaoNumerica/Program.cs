namespace IntegracaoNumerica
{
    internal class Program
    {
        private static readonly double VALOR_EXATO = 11.25;
        //private static readonly double VALOR_EXATO = 3.5 + (1 / (2 * Math.Exp(8)));

        static void Main(string[] args)
        {
            //intervalo inferior
            double a = 2;

            //intervalo superior
            double b = 3;

            //número de partições
            int n = 5;

            //deltaX
            double deltaX = (b - a) / n;

            Console.WriteLine($"Intervalo inferior: {a}\nIntervalo Superior: {b}\nNúmero de partições: {n}\nDeltaX: {deltaX}\nValor Exato: {VALOR_EXATO}\n");
            Riemann(a, n, deltaX);
            TrapezioRepetido(a, n, deltaX);
            TrapezioSimples(a, b, n, deltaX);
            UmTercoDeSimpsonRepetida(a, n, deltaX);
        }

        private static void Riemann(double a, int n, double deltaX)
        {
            double somaRiemann = 0;

            for (int i = 0; n > 0; i++, n--)
            {
                double x = a + i * deltaX;
                somaRiemann += Funcao(x) * deltaX;
            }

            Console.WriteLine($"Método soma de Riemann: {somaRiemann} - Erro porcentual: {ErroPorcentual(somaRiemann)} %");
        }

        private static void TrapezioRepetido(double a, int n, double deltaX)
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
            Console.WriteLine($"Método Trapézio Repetido: {somaTrapRepetido} - Erro porcentual: {ErroPorcentual(somaTrapRepetido)} %");
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
            double result = somaTrapSimples * deltaX;
            Console.WriteLine($"Método Trapézio Simples: {result} - Erro porcentual: {ErroPorcentual(result)} %");
        }

        private static void UmTercoDeSimpsonRepetida(double a, int n, double deltaX)
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
            Console.WriteLine($"Método 1/3 de Simpson Repetida: {somaUmTercoDeSimpsonRepetida} - Erro porcentual: {ErroPorcentual(somaUmTercoDeSimpsonRepetida)} %");

        }

        private static double Funcao(double x)
        {
            //return 1 - Math.Exp(-2 * x);
            return Math.Exp(x);
        }

        private static double ErroPorcentual(double valorAproximado)
        {
            return VALOR_EXATO > valorAproximado ? ((VALOR_EXATO - valorAproximado) / VALOR_EXATO) * 100 : ((valorAproximado - VALOR_EXATO) / VALOR_EXATO) * 100;
        }
    }
}