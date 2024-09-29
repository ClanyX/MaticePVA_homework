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
            int x = 0;
            int y = 0;
            Console.WriteLine("Sčítání");
            Console.WriteLine("První matice");
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
            Console.WriteLine();
            Start();
        }

        static void Rozdil()
        {

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
