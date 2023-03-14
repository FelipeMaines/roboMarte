namespace roboMarte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Primeiro 
            int valorDirecao = 0;
            int valorDirecaoSeg = 0;
            int yPrimeiro = 0, xPrimeiro = 0;
            int ySegundo = 0, xSegundo = 0;
            char olhando = 'n';

            //Declarando o tamanho da matriz

            string[] matriz = new string[100];
            Console.WriteLine("Qual o tamnho do espaco:");
            string tamanho = Console.ReadLine();

            matriz = tamanho.Split(' ');

            int intMatrizXPrimeiro = int.Parse(matriz[0]);
            int intMatrizYPrimeiro = int.Parse(matriz[1]);


            string[] inicialPrimeiro = new string[100];
            Console.WriteLine("Qual a posicao inicial: ");
            string posicaoInicialPrimeiro = Console.ReadLine();

            inicialPrimeiro = posicaoInicialPrimeiro.Split(' ');


            xPrimeiro = int.Parse(inicialPrimeiro[0]);
            yPrimeiro = int.Parse(inicialPrimeiro[1]);




            //Dando Norte eh igual ou a 0 ou a 360 / L = 90 / S = 180 / O = 270

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
                    Console.WriteLine("Erro");
                    break;
            }


            Console.WriteLine("Qual sao os comandos dados: ");
            string strcomandos = Console.ReadLine();

            char[] comandos = new char[50];

            comandos = strcomandos.ToCharArray();

            foreach (char comando in comandos)
            {
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
                        if (yPrimeiro > intMatrizYPrimeiro)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Robo saiu do espaco de trabalho!");
                            break;
                        }

                        yPrimeiro += 1;
                    }

                    else if (valorDirecao == 90)
                    {
                        if (xPrimeiro > intMatrizXPrimeiro)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Robo saiu do espaco de trabalho!");
                            break;
                        }
                        xPrimeiro += 1;
                    }

                    else if (valorDirecao == 180)
                    {
                        if (yPrimeiro == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("O robo saiu da area! ");
                            break;
                        }
                        yPrimeiro -= 1;
                    }

                    else if (valorDirecao == 270)
                    {
                        if (yPrimeiro == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("O robo saiu da area! ");
                            break;
                        }
                        xPrimeiro -= 1;
                    }

                }
            }

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


            //Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{xPrimeiro} {yPrimeiro} {olhando}");

            Console.ForegroundColor = ConsoleColor.White;

            //Segundo Robo --------------------------------------------------------------------------------------

            string[] inicialSegundo = new string[100];
            Console.WriteLine("Qual a posicao inicial do segundo robo: ");
            string posicaoInicialSegundo = Console.ReadLine();

            inicialSegundo = posicaoInicialSegundo.Split(' ');

            xSegundo = int.Parse(inicialSegundo[0]);
            ySegundo = int.Parse(inicialSegundo[1]);

            switch (inicialSegundo[2])
            {
                case "N":
                    valorDirecaoSeg = 0;
                    break;

                case "L":
                    valorDirecaoSeg = 90;
                    break;

                case "S":
                    valorDirecaoSeg = 180;
                    break;

                case "O":
                    valorDirecaoSeg = 270;
                    break;


                default:
                    Console.WriteLine("Erro");
                    break;
            }


            Console.WriteLine("Qual sao os comandos dados: ");
            string strcomandosSeg = Console.ReadLine();

            char[] comandosSeg = new char[50];

            comandosSeg = strcomandosSeg.ToCharArray();


            foreach (char comando in comandosSeg)
            {
                if (comando == 'E')
                {

                    if (valorDirecaoSeg == 0)
                    {
                        valorDirecaoSeg = 360;
                    }

                    valorDirecaoSeg -= 90;
                }

                else if (comando == 'D')
                {
                    if (valorDirecaoSeg == 360)
                    {
                        valorDirecaoSeg = 0;
                    }

                    valorDirecaoSeg += 90;
                }

                if (comando == 'M')
                {
                    if (valorDirecaoSeg == 0 || valorDirecaoSeg == 360)
                    {
                        if (ySegundo > 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Robo saiu do espaco de trabalho!");
                            break;
                        }

                        ySegundo += 1;
                    }

                    else if (valorDirecaoSeg == 90)
                    {
                        if (xSegundo > 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Robo saiu do espaco de trabalho!");
                            break;
                        }
                        xSegundo += 1;
                    }

                    else if (valorDirecaoSeg == 180)
                    {
                        if (ySegundo == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("O robo saiu da area! ");
                            break;
                        }
                        ySegundo -= 1;
                    }

                    else if (valorDirecaoSeg == 270)
                    {
                        if (ySegundo == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("O robo saiu da area! ");
                            break;
                        }
                        xSegundo -= 1;
                    }

                }
            }

            char olhandoSeg = 'f';

            switch (valorDirecaoSeg)
            {
                case 0:
                    olhandoSeg = 'N';
                    break;

                case 360:
                    olhandoSeg = 'N';
                    break;

                case 90:
                    olhandoSeg = 'L';
                    break;

                case 180:
                    olhandoSeg = 'S';
                    break;

                case 270:
                    olhandoSeg = 'O';
                    break;
            }


            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{xSegundo} {ySegundo} {olhandoSeg}");

            Console.ForegroundColor = ConsoleColor.White;






        }
    }
}