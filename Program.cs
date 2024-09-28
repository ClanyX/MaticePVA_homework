using System;

namespace MaticePVA
{
    class Program
    {
        static void Main(string[] args)
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
            Console.WriteLine("Vyber operaci\n1. soušet\n2. rozdíl\n3. Transponování\n4. Vynásobení jedné matice číslem\n5.součin");
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
            VelikostMat(x, y);
            int[,] matice1 = new int[x, y];
            matice(matice1);

            Console.WriteLine("Druhá matice");
            VelikostMat(x, y);
            int[,] matice2 = new int[x, y];
            matice(matice2);

            if (matice1.GetLength(0) == matice2.GetLength(1) && matice1.GetLength(1) == matice2.GetLength(1))
            {
                Console.WriteLine("True");
            }

        }

        static void Rozdil()
        {

        }

        static void VelikostMat(int radek, int sloupec)
        {
            //row
            Console.Write("Zadej velikost matice řádkek = ");
            radek = Convert.ToInt32(Console.ReadLine());

            //colum
            Console.Write("Zadej velikost matice sloupec = ");
            sloupec = Convert.ToInt32(Console.ReadLine());
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
                    arr[i, j] = rnd.Next(-101, 101);
                }
            }
        }
    }
}
