int[] cor = new int[2];
int size = 10;
int mines = 20;

string[,] field = new string[size, size];
Random rnd = new Random();

static void FinalField(int size, string[,] field)
{
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
            if (field[a, b] != "*")
            {
                Console.Write("  ");
            }
            else
            {
                Console.Write(field[a, b] + " ");
            }

        }
        Console.WriteLine();
    }
}

/// PLACING MINES
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

/// FILL THE REST WITH DOTS
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


while (true)
{

    /// PLAYING FIELD
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
    /// TESTING FIELD
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

    /// handling the input
    while (true)
    {
        Console.Write("Zadej číslo a sloupec (form. sloupec řádek): ");
        string corStr = Console.ReadLine();
        string[] parts = corStr.Split(' ');

        if (parts.Length != 2)
        {
            Console.WriteLine("Neplatný vstup. Zadej dvě čísla oddělená mezerou.");
            continue;
        }

        try
        {
            cor = Array.ConvertAll(parts, int.Parse);

            if (cor[0] < 0 || cor[0] >= size || cor[1] < 0 || cor[1] >= size)
            {
                Console.WriteLine("Souřadnice mimo rozsah pole. Zkus to znovu.");
                continue;
            }

            break;
        }
        catch
        {
            Console.WriteLine("Neplatný vstup. Zadej dvě celá čísla oddělená mezerou.");
        }
    }
    ///



    if (field[cor[0], cor[1]] == "*")
    {
        Console.WriteLine("Prohrál jsi!");
        FinalField(size, field);
        break;
    }
}
