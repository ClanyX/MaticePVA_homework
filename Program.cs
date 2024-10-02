using System;
using System.Drawing;
using System.Security.Cryptography;

namespace MaticePVA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zmáčkni jakékoliv tlačítko pro start...");
            Start();
        }

        static void Start()
        {
            while (true)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Vyber operaci\n1. Součet\n2. Rozdíl\n3. Transponování\n4. Násobení skalárem\n5. Součin\n6. EXIT");
                Console.Write("Operace(číslo): ");
                if (int.TryParse(Console.ReadLine(), out int operation))
                {
                    switch (operation)
                    {
                        case 1:
                            Soucet();
                            break;

                        case 2:
                            Rozdil();
                            break;

                        case 3:
                            Transponovani();
                            break;

                        case 4:
                            NasobeniCislem();
                            break;

                        case 5:
                            Nasobeni();
                            break;

                        case 6:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Špatně zadaná operace...\nZadej novou operaci.");
                            Start();
                            break;
                    }
                }
                else
                    Console.WriteLine("Neplatný vstup, zadej číslo...");
            }
        }

        static void Soucet()
        {
            Console.WriteLine("Soušet\nPrvní matice");
            int[,] matice1 = new int[VelikostRadek(), VelikostSloupec()];
            matice(matice1);

            Console.WriteLine("Druhá matice");
            int[,] matice2 = new int[VelikostRadek(), VelikostSloupec()];
            matice(matice2);

            if (matice1.GetLength(0) == matice2.GetLength(0) && matice1.GetLength(1) == matice2.GetLength(1))
            {
                VypisMatice(matice1);
                Console.WriteLine("+");
                VypisMatice(matice2);
                Console.WriteLine("=");

                for (int i = 0; i < matice1.GetLength(1); i++)
                {
                    for (int j = 0; j < matice1.GetLength(0); j++)
                    {
                        matice1[j, i] += matice2[j, i];
                    }
                }
                VypisMatice(matice1);
            }
            else
            {
                Console.WriteLine("Matice musí být stejně velké!!");
                Start();
            }
            Start();
        }

        static void Rozdil()
        {
            bool direction = false;
            Console.WriteLine("1. A - B\n2. B - A");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                switch (number)
                {
                    case 1:
                        direction = true;
                        break;
                    case 2:
                        direction = false;
                        break;
                    default:
                        Console.WriteLine("Pouze číslo 1 nebo 2!");
                        Start();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Neplatný vstup, zadej číslo...");
                Start();
            }

            Console.WriteLine("Rozdíl\nPrvní matice");
            int[,] matice1 = new int[VelikostRadek(), VelikostSloupec()];
            matice(matice1);

            Console.WriteLine("Druhá matice");
            int[,] matice2 = new int[VelikostRadek(), VelikostSloupec()];
            matice(matice2);

            if (matice1.GetLength(0) == matice2.GetLength(0) && matice1.GetLength(1) == matice2.GetLength(1))
            {
                if(direction)
                {
                    VypisMatice(matice1);
                    Console.WriteLine("-");
                    VypisMatice(matice2);
                    Console.WriteLine("=");

                    for (int i = 0; i < matice1.GetLength(0); i++)
                    {
                        for (int j = 0; j < matice1.GetLength(1); j++)
                        {
                            matice1[i, j] += matice2[i, j];
                        }
                    }
                    VypisMatice(matice1);
                }
                else
                {
                    VypisMatice(matice2);
                    Console.WriteLine("-");
                    VypisMatice(matice1);
                    Console.WriteLine("=");

                    for (int i = 0; i < matice2.GetLength(0); i++)
                    {
                        for (int j = 0; j < matice2.GetLength(1); j++)
                        {
                            matice2[i, j] += matice1[i, j];
                        }
                    }
                    VypisMatice(matice2);
                }
            }
            else
            {
                Console.WriteLine("Matice musí být stejně velké!!");
                Start();
            }
            Start();
        }

        static void Transponovani()
        {
            Console.WriteLine("Matice");
            int[,] matice1 = new int[VelikostRadek(), VelikostSloupec()];
            matice(matice1);
            VypisMatice(matice1);

            Console.WriteLine("Transponovaná matice");

            int[,] resultMatice = new int[matice1.GetLength(1), matice1.GetLength(0)];
            for (int i = 0; i < matice1.GetLength(1); i++)
            {
                for (int j = 0; j < matice1.GetLength(0); j++)
                {
                    resultMatice[i, j] = matice1[j, i];
                }
            }
            VypisMatice(resultMatice);
            Start();
        }

        static void NasobeniCislem()
        {
            Console.Write("Zadej číslo pro násobení: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Matice");
            int[,] matice1 = new int[VelikostRadek(), VelikostSloupec()];
            matice(matice1);
            VypisMatice(matice1);
            Console.WriteLine($"*\n{number}\n=");
            for (int i = 0; i < matice1.GetLength(0); i++)
            {
                for (int j = 0; j < matice1.GetLength(1); j++)
                {
                    matice1[i, j] *= number;
                }
            }
            VypisMatice(matice1);
            Start();
        }

        static void Nasobeni()
        {
            Console.WriteLine("Násobení\nPrvní matice");
            int[,] matice1 = new int[VelikostRadek(), VelikostSloupec()];
            matice(matice1);

            Console.WriteLine("Druhá matice");
            int[,] matice2 = new int[VelikostRadek(), VelikostSloupec()];
            matice(matice2);

            if(matice1.GetLength(1) != matice2.GetLength(0))
            {
                Console.WriteLine("Matice 1 musí mít stejný počet sloupců jako matice 2 řádků!!");
                Start();
            }

            VypisMatice(matice1);
            Console.WriteLine("*");
            VypisMatice(matice2);
            Console.WriteLine("=");

            int AR = matice1.GetLength(0);
            int AC = matice1.GetLength(1);
            int BC = matice2.GetLength(1);
            int[,] result = new int[AR, BC];

            for (int i = 0; i < AR; i++)
            {
                for (int j = 0; j < BC; j++)
                {
                    for (int k = 0; k < AC; k++)
                    {
                        result[i, j] += matice1[i, k] * matice2[k, j];
                    }
                }
            }

            VypisMatice(result);
            Start();
        }

        //funkcni metody
        static int VelikostRadek()
        {
            //row
            Console.Write("Zadej velikost matice řádek = ");
            int row = Convert.ToInt32(Console.ReadLine());
            try
            {
                if(row <= 0)
                {
                    throw new Exception("Číslo nemuže být nula ani záporné!!");
                }               
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Start();
            }
            return row;
        }
        static int VelikostSloupec()
        {
            //colum
            Console.Write("Zadej velikost matice sloupec = ");
            int colum = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (colum <= 0)
                {
                    throw new Exception("Číslo nemuže být nula ani záporné!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Start();
            }
            return colum;
        }
        static void matice(int[,] arr)
        {
            Random rnd = new Random();

            //sloupec
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                //radek
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(-101, 101);
                }
            }
        }
        static void VypisMatice(int[,] arr)
        {
            //sloupec
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                //radek
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
