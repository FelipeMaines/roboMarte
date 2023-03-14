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



            int contador = 0;
            do
            {
                string[] matriz = new string[2];
                Console.WriteLine("Qual o tamnho do espaco:");
                string tamanho = Console.ReadLine();

                matriz = tamanho.Split(' ');

                int intMatrizXPrimeiro = int.Parse(matriz[0]);
                int intMatrizYPrimeiro = int.Parse(matriz[1]);


                string[] inicialPrimeiro = new string[3];
                Console.WriteLine("Qual a posicao inicial: ");
                string posicaoInicialPrimeiro = Console.ReadLine();

                inicialPrimeiro = posicaoInicialPrimeiro.Split(' ');


                xPrimeiro = int.Parse(inicialPrimeiro[0]);
                yPrimeiro = int.Parse(inicialPrimeiro[1]);

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

                bool isOut = false;

                foreach (char comando in comandos)
                {
                    if (isOut)
                    {
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

                if (!isOut)
                {
                    //Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{xPrimeiro} {yPrimeiro} {olhando}");
                    contador++;
                }
                Console.ForegroundColor = ConsoleColor.White;



            } while (contador != 2);

        }
    }
}


