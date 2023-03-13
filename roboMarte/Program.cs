namespace roboMarte
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int valorDirecao = 0;
            int y= 0, x=0;
            char olhando = 'n' ;

            //Declarando o tamanho da matriz

            string[] matriz = new string[100];
            Console.WriteLine("Qual o tamnho do espaco:");
            string tamanho = Console.ReadLine();

            matriz = tamanho.Split(' ');


            string[] inicial = new string[100];
            Console.WriteLine("Qual a posicao inicial: ");
            string posicaoInicial = Console.ReadLine();

            inicial = posicaoInicial.Split(' ');


            x = int.Parse(inicial[0]);
            y = int.Parse(inicial[1]);

            //Dando Norte eh igual ou a 0 ou a 360 / L = 90 / S = 180 / O = 270

            switch (inicial[2])
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
                if (comando == 'E') { 

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
                    if(valorDirecao == 0 || valorDirecao == 360)
                    {
                        y += 1;
                    }

                    else if (valorDirecao == 90)
                    {
                        x += 1;
                    }

                    else if (valorDirecao == 180)
                    {
                        y -= 1;
                    }

                    else if (valorDirecao == 270)
                    {
                        x -= 1;
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

            Console.WriteLine($"{x} {y} {olhando}");





            //Console.WriteLine($"{tamanho}, {posicaoInicial}, {valorDirecao}");





        }
    }
}