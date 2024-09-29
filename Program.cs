using System;

namespace MaticePVA
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            int operation = operace();
            switch (operation)
            {
                case 1:
                    Soucet();
                    break;

                case 2:
                    Rozdil();
                    break;

            }
        }

        //vyber operace
        static int operace()
        {
            int ope;
            Console.WriteLine("Vyber operaci\n1. soušet\n2. rozdíl\n3. transponování\n4. vynásobení jedné matice číslem\n5. součin");
            Console.Write("Operace: ");
            ope = Convert.ToInt32(Console.ReadLine());
            if (ope < 1 || ope > 5)
            {
                Console.WriteLine("Špatně zadaná operace...\nZadej novou operaci.");
                ope = operace();
            }
            return ope;
        }

        static void Soucet()
        {
            Console.WriteLine("Soušet");
            Console.WriteLine("První matice");
            int[,] matice1 = new int[VelikostSloupec(), VelikostRadek()];
            matice(matice1);

            Console.WriteLine("Druhá matice");
            int[,] matice2 = new int[VelikostSloupec(), VelikostRadek()];
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
            Console.WriteLine();
            Start();
        }

        static void Rozdil()
        {
            bool direction = false;
            Console.WriteLine("1. A - B\n2. B - A");
            char number = Convert.ToChar(Console.ReadLine());
            if (number == '1')
                direction = true;
            else 
                direction = false;

            Console.WriteLine("Rozdíl");
            Console.WriteLine("První matice");
            int[,] matice1 = new int[VelikostSloupec(), VelikostRadek()];
            matice(matice1);

            Console.WriteLine("Druhá matice");
            int[,] matice2 = new int[VelikostSloupec(), VelikostRadek()];
            matice(matice2);

            if (matice1.GetLength(0) == matice2.GetLength(0) && matice1.GetLength(1) == matice2.GetLength(1))
            {
                if(direction)
                {
                    VypisMatice(matice1);
                    Console.WriteLine("-");
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
                    VypisMatice(matice2);
                    Console.WriteLine("-");
                    VypisMatice(matice1);
                    Console.WriteLine("=");

                    for (int i = 0; i < matice2.GetLength(1); i++)
                    {
                        for (int j = 0; j < matice2.GetLength(0); j++)
                        {
                            matice2[j, i] += matice1[j, i];
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
            Console.WriteLine();
            Start();
        }

        static int VelikostRadek()
        {
            //row
            Console.Write("Zadej velikost matice řádek = ");
            int row = Convert.ToInt32(Console.ReadLine());
            return row;
        }

        static int VelikostSloupec()
        {
            //colum
            Console.Write("Zadej velikost matice sloupec = ");
            int colum = Convert.ToInt32(Console.ReadLine());
            return colum;
        }

        static void matice(int[,] arr)
        {
            Random rnd = new Random();

            //sloupec
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                //radek
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    arr[j, i] = rnd.Next(-101, 101);
                }
            }
        }

        static void VypisMatice(int[,] arr)
        {
            //sloupec
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                //radek
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    Console.Write(arr[j, i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
