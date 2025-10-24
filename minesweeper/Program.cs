int[] cor = new int[2];
int size = 10;
int mines = 20;

string[,] field = new string[size, size];
Random rnd = new Random();
/*
static void FinalField()
{
    int size = 10;
    string[,] field = new string[size, size]; // ts gurt yo
    for (int a = 0; a < size; a++)
    {
        // NUMBERS
        if (a == 0)
        {
            Console.Write(" ");
            for (int b = 0; b < size; b++)
            {
                Console.Write(" " + b);
            }
            Console.WriteLine();
        }
        Console.Write(a + " ");
        ///////


        for (int b = 0; b < size; b++)
        {
            if (field[a, b] == "*" && (cor[0] != a && cor[1] != b))
            {
                Console.Write(". ");
            }
            else
            {
                Console.Write(field[a, b] + " ");
            }

        }
        Console.WriteLine();
    }
}
*/

for (int m = 0; m < mines; m++)
{
    int x = rnd.Next(0, size);
    int y = rnd.Next(0, size);
    if (field[x, y] != "*")
    {
        field[x, y] = "*";
    }
    else
    {
        m--;
    }
}
while (true)
{
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {

            if (field[i, j] != "*")
            {
                field[i, j] = ".";
            }
        }
    }

    for (int a = 0; a < size; a++)
    {
        // NUMBERS
        if (a == 0)
        {
            Console.Write(" ");
            for (int b = 0; b < size; b++)
            {
                Console.Write(" " + b);
            }
            Console.WriteLine();
        }
        Console.Write(a + " ");
        ///////
        

        for (int b = 0; b < size; b++)
        {
            if (field[a, b] == "*" && (cor[0] != a && cor[1] != b))
            {
                Console.Write(". ");
            }
            else
            {
                Console.Write(field[a, b] + " ");
            }

        }
        Console.WriteLine();
    }

    for (int a = 0; a < size; a++)
    {
        if (a == 0)
        {
            Console.Write(" ");
            for (int b = 0; b < size; b++)
            {
                Console.Write(" " + b);
            }
            Console.WriteLine();
        }
        Console.Write(a + " ");
        for (int b = 0; b < size; b++)
        {
            Console.Write(field[a, b] + " ");
        }
        Console.WriteLine();
    }

    Console.Write("Zadej číslo a sloupec (form. sloupec řádek): ");

    string corStr = Console.ReadLine();
    string[] parts = corStr.Split(' ');

    try
    {
        cor = Array.ConvertAll(parts, int.Parse);
    }

    catch (Exception e)
    {
        Console.WriteLine("Neplatný vstup. Ujisti se, že zadáváš dvě čísla oddělená mezerou.");
        Console.WriteLine("Chyba: " + e);
    }

}


/*
while (true)
{
    for (int a = 0; a < 10; a++)
    {

        if (a == 0)
        {
            Console.Write(" ");
            for (int b = 0; b < 10; b++)
            {
                Console.Write(" " + b);
            }
            Console.WriteLine();
        }

        Console.Write(a + " ");

        for (int b = 0; b < 10; b++)
        {
            Console.Write(". ");
        }
        Console.WriteLine();
    }

    Console.Write("Zadej číslo a sloupec: ");

    string corStr = Console.ReadLine();
    string[] parts = corStr.Split(' ');

    try
    {
        int[] cor = Array.ConvertAll(parts, int.Parse);
    }

    catch (Exception e)
    {
        Console.WriteLine("Neplatný vstup. Ujisti se, že zadáváš dvě čísla oddělená mezerou.");
        Console.WriteLine("Chyba: " + e);
    }
    
}

*/

