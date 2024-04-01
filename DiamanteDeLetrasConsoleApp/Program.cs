using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace DiamanteDeLetrasConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string opcao = Menu();

                if (VerificaOpcaoSair(opcao))
                    Environment.Exit(0);

                opcao = SubMenu();

                char letra = VerificaLetraDeEntrada(opcao);

                char[] alfabeto = new char[26];
                char[] alfabetoMinusculo = new char[26];

                int posicaoDaLetraNoAlfabeto = GeraAlfabeto(letra, ref alfabeto, ref alfabetoMinusculo);

                GeraDiamanteDeLetras(ref alfabeto, posicaoDaLetraNoAlfabeto);

                //int quantidadesDeLetras = 5;


                //char letra;

                //De acordo com o número informado pelo usuário é gerado automáticamente e atribuído a um array as letras do alfabeto
                //for (int i = 0; i < alfabeto.Length; i++)
                //{
                //    if (alfabeto[0].Equals('\0'))
                //    {
                //        alfabeto[0] = 'A';
                //    }
                //    else
                //    {
                //        char prov = alfabeto[i - 1];
                //        prov++;
                //        alfabeto[i] = prov;
                //    }
                //}

                //int cont = 0;
                //int aux = 0;

                //Gera a parte superior da figura
                

                Console.ReadLine();
            }
        }

        #region Menu
        static string Menu()
        {
            Console.Clear();
            Console.WriteLine("PROGRAMA DIAMANTE DE LETRAS");
            Console.WriteLine();

            Console.WriteLine("Digite 'S' para sair e 'C' para continuar!");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();
            Console.WriteLine();

            opcao = VerificaSeOpcaoDeMenuValida(opcao);

            return opcao;
        }
        #endregion

        #region Verifica se opção de entrada é válida, caso não seja pede para que opcao seja inserida novamente
        static string VerificaSeOpcaoDeMenuValida(string opcao)
        {
            while((opcao != "S") && (opcao != "s") && (opcao != "C") && (opcao != "c"))
            {
                Console.Clear();
                Console.WriteLine("Opção inválida, por favor digite novamente...");
                Console.Write("opção: ");
                opcao = Console.ReadLine();
            }
            return opcao;
        }
        #endregion

        #region Verifica se opção digitada foi sair, se sim retorna verdadeiro, se não retorna falso
        static bool VerificaOpcaoSair(string opcao)
        {
            if ((opcao == "S") || (opcao == "s"))
            {
                Console.WriteLine();
                Console.WriteLine("Tem certeza que quer mesmo encerrar o sistema?");
                Console.WriteLine("Digite 'S' para sair e 'C' para continuar!");
                Console.Write("Opção: ");
                opcao = VerificaSeOpcaoDeMenuValida(Console.ReadLine());
                if ((opcao == "S") || (opcao == "s"))
                    return true;
                else
                    return false;
            }
            else
            return false;
        }
        #endregion

        #region Submenu
        static string SubMenu()
        {
            Console.Clear();
            Console.WriteLine("PROGRAMA DIAMANTE DE LETRAS");
            Console.WriteLine();
            Console.Write("Digite a letra: ");
            string letra;
            letra = Console.ReadLine();
            return letra;
        }
        #endregion

        #region Verifica letra de entrada
        static char VerificaLetraDeEntrada(string letra)
        {
            char letraChar;
            while (
                (letra != "A") && (letra != "a") && (letra != "B") && (letra != "b") && (letra != "C") && (letra != "c") &&
                (letra != "D") && (letra != "d") && (letra != "E") && (letra != "e") && (letra != "F") && (letra != "f") &&
                (letra != "G") && (letra != "g") && (letra != "H") && (letra != "h") && (letra != "I") && (letra != "i") &&
                (letra != "J") && (letra != "j") && (letra != "K") && (letra != "k") && (letra != "L") && (letra != "l") &&
                (letra != "M") && (letra != "m") && (letra != "N") && (letra != "n") && (letra != "O") && (letra != "o") &&
                (letra != "P") && (letra != "p") && (letra != "Q") && (letra != "q") && (letra != "R") && (letra != "r") &&
                (letra != "S") && (letra != "s") && (letra != "T") && (letra != "t") && (letra != "U") && (letra != "u") &&
                (letra != "V") && (letra != "v") && (letra != "W") && (letra != "w") && (letra != "Y") && (letra != "y") &&
                (letra != "X") && (letra != "x") && (letra != "Z") && (letra != "z")
                )
            {
                Console.WriteLine();
                Console.WriteLine("Opção inválida, por favor digite novamente...");
                Console.WriteLine("Digite a letra: ");
                letra = Console.ReadLine();
            }
            letraChar = char.Parse(letra);
            return letraChar;
        }
        #endregion

        #region Gera o alfabeto até a letra que foi definida pelo usuário e retorna aposição da letra no array;
        static int GeraAlfabeto(char letraDeEntrada, ref char[] alfabeto, ref char[] alfabetoMinusculo)
        {
            int posicao = 0;

            for (int i = 0; i < 26; i++)
            {
                if (alfabeto[0].Equals('\0'))
                    alfabeto[0] = 'A';
                else
                {
                    char aux = alfabeto[i - 1];
                    aux++;
                    alfabeto[i] = aux;
                }
            }
            for (int i = 0; i < 26; i++)
            {
                if (alfabetoMinusculo[0].Equals('\0'))
                    alfabetoMinusculo[0] = 'a';
                else
                {
                    char aux = alfabetoMinusculo[i - 1];
                    aux++;
                    alfabetoMinusculo[i] = aux;
                }
            }
            for (int i = 0; i < 26; i++)
            {
                if (letraDeEntrada == alfabeto[i])
                {
                    posicao = i;
                }
            }
            for (int i = 0; i < 26; i++)
            {
                if (letraDeEntrada == alfabetoMinusculo[i])
                    posicao = i;
            }
            
            return posicao;
        }
        #endregion

        static void GeraDiamanteDeLetras(ref char[] alfabeto, int posicao)
        {
            Console.WriteLine("Posição: " + posicao);
            for (int i = 0; i < posicao; i++)
            {
                for (int n = posicao; n > i; n--)
                {
                    Console.Write(" ");
                }

                Console.Write(alfabeto[i]);

                for (int j = 1; j < i + i; j++)
                {
                    Console.Write(" ");
                }

                if (i != 0)
                    Console.Write(alfabeto[i]);
                Console.WriteLine();
            }

            Console.Write(alfabeto[posicao]);

            //Essa estrutura gera a parte central da figura
            for (int i = 0; i < posicao + posicao - 1; i++)
            {
                Console.Write(" ");
            }

            Console.Write(alfabeto[posicao]);
            Console.WriteLine();

            //aux = ((alfabeto.Length - 1) / 2) + 1;

            for (int i = posicao - 1; i >= 0; i--)
            {
                for (int n = posicao; n > i; n--)
                {
                    Console.Write(" ");
                }

                Console.Write(alfabeto[i]);

                for (int j = 0; j < i + i - 1; j++)
                {
                    Console.Write(" ");
                }

                if (i != 0)
                    Console.Write(alfabeto[i]);
                //for (int i = 0; i < ((alfabeto.Length - 1) / 2); i++)
                //{
                //    for (int n = ((alfabeto.Length - 1) / 2); n > i; n--)
                //    {
                //        Console.Write(" ");
                //    }

                //    Console.Write(alfabeto[i]);

                //    for (int j = 1; j < i + i; j++)
                //    {
                //        Console.Write(" ");
                //    }

                //    if (i != 0)
                //        Console.Write(alfabeto[i]);
                //    Console.WriteLine();
                //}

                //Console.Write(alfabeto[(alfabeto.Length - 1) / 2]);

                ////Essa estrutura gera a parte central da figura
                //for (int i = 0; i < alfabeto.Length - 2; i++)
                //{
                //    Console.Write(" ");
                //}

                //Console.Write(alfabeto[(alfabeto.Length - 1) / 2]);
                //Console.WriteLine();

                ////aux = ((alfabeto.Length - 1) / 2) + 1;

                //for (int i = ((alfabeto.Length - 1) / 2) - 1; i >= 0; i--)
                //{
                //    for (int n = ((alfabeto.Length - 1) / 2); n > i; n--)
                //    {
                //        Console.Write(" ");
                //    }

                //    Console.Write(alfabeto[i]);

                //    for (int j = 0; j < i + i - 1; j++)
                //    {
                //        Console.Write(" ");
                //    }

                //    if (i != 0)
                //        Console.Write(alfabeto[i]);
                Console.WriteLine();
            }
        }
    }
}
