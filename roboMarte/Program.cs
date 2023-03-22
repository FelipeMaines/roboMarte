namespace roboMarte
{
    internal class Program
    {
        static string[] matriz = new string[2];
        static string[] inicialPrimeiro = new string[3];
        static char[] comandos = new char[50];

        static void mensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }
        static string[] tamanhoMatriz(string mensagem)
        {
            Console.WriteLine(mensagem);
            string tamanho = Console.ReadLine();
            matriz = tamanho.Split(' ');

            return matriz;
        }

        static string[] posicaoInicial(string mensagem)
        {
            Console.WriteLine(mensagem);
            string posicaoInicialPrimeiro = Console.ReadLine();
            inicialPrimeiro = posicaoInicialPrimeiro.Split(' ');

            return inicialPrimeiro;

        }

        static char[] pegarComandos(string mensagem)
        {
            Console.WriteLine("Qual sao os comandos dados: ");
            string strcomandos = Console.ReadLine();
            comandos = strcomandos.ToCharArray();

            return comandos;
        }

        private static int darValorDeAcordoComDirecao(int valorDirecao)
        {
            switch (inicialPrimeiro[2])
            {
                case "N":
                    valorDirecao = 0;
                    break;

                case "L":
                    valorDirecao = 90;
                    break;

                case "S":
                    valorDirecao = 180;
                    break;

                case "O":
                    valorDirecao = 270;
                    break;


                default:
                    mensagemErro("ERRO");
                    break;


            }

            return valorDirecao;
        }

        private static void verificarEArrumarDirecao(ref int valorDirecao, ref int yPrimeiro, ref int xPrimeiro, ref int contador, int intMatrizXPrimeiro, int intMatrizYPrimeiro, ref bool isOut)
        {
            foreach (char comando in comandos)
            {
                if (isOut)
                {
                    mensagemErro("SAIU DA AREA");
                    break;
                }
                if (comando == 'E')
                {

                    if (valorDirecao == 0)
                    {
                        valorDirecao = 360;
                    }

                    valorDirecao -= 90;
                }

                else if (comando == 'D')
                {
                    if (valorDirecao == 360)
                    {
                        valorDirecao = 0;
                    }

                    valorDirecao += 90;
                }

                if (comando == 'M')
                {
                    if (valorDirecao == 0 || valorDirecao == 360)
                    {

                        yPrimeiro += 1;

                        if (yPrimeiro > intMatrizYPrimeiro)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Robo saiu do espaco de trabalho!");
                            isOut = true;
                            contador++;
                            continue;
                        }

                    }

                    else if (valorDirecao == 90)
                    {
                        xPrimeiro += 1;

                        if (xPrimeiro > intMatrizXPrimeiro)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Robo saiu do espaco de trabalho!");
                            contador++;
                            continue;
                        }
                    }

                    else if (valorDirecao == 180)
                    {
                        yPrimeiro -= 1;

                        if (yPrimeiro == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("O robo saiu da area! ");
                            contador++;
                            continue;
                        }
                    }

                    else if (valorDirecao == 270)
                    {
                        xPrimeiro -= 1;

                        if (yPrimeiro == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("O robo saiu da area! ");
                            contador++;
                            continue;
                        }
                    }

                }
            }
        }

        static char direcaoFinal(int valorDirecao, ref char olhando)
        {
            switch (valorDirecao)
            {
                case 0:
                    olhando = 'N';
                    break;

                case 360:
                    olhando = 'N';
                    break;

                case 90:
                    olhando = 'L';
                    break;

                case 180:
                    olhando = 'S';
                    break;

                case 270:
                    olhando = 'O';
                    break;
            }

            return olhando;
        }

        private static int seNaoEstaFora(int yPrimeiro, int xPrimeiro, char olhando, int contador, bool isOut)
        {
            if (!isOut)
            {
                //Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{xPrimeiro} {yPrimeiro} {olhando}");
                contador++;
                Console.ResetColor();
            }

            return contador;
        }
        static void Main(string[] args)
        {

            int valorDirecao = 0;
            int valorDirecaoSeg = 0;
            int yPrimeiro = 0, xPrimeiro = 0;
            int ySegundo = 0, xSegundo = 0;
            char olhando = 'n';
            int contador = 0;

            do
            {
                matriz = tamanhoMatriz("Qual o tamanho da matriz: ");

                int intMatrizXPrimeiro = int.Parse(matriz[0]);
                int intMatrizYPrimeiro = int.Parse(matriz[1]);

                posicaoInicial("Qual a posicao inicial: ");

                xPrimeiro = int.Parse(inicialPrimeiro[0]);
                yPrimeiro = int.Parse(inicialPrimeiro[1]);

                valorDirecao = darValorDeAcordoComDirecao(valorDirecao);

                comandos = pegarComandos("Quais sao os comandos dados: ");

                bool isOut = false;

                verificarEArrumarDirecao(ref valorDirecao, ref yPrimeiro, ref xPrimeiro, ref contador, intMatrizXPrimeiro, intMatrizYPrimeiro, ref isOut);
                direcaoFinal(valorDirecao, ref olhando);

                contador = seNaoEstaFora(yPrimeiro, xPrimeiro, olhando, contador, isOut);

            } while (contador != 2);

        } // AAA

       


    }
}


