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



static bool searchMatrix(string[,] mat, string target)
{

    for (int i = 0; i < mat.GetLength(0); i++)
    {

        for (int j = 0; j < mat.GetLength(1); j++)
        {

            if (mat[i, j] == target)
            {
                return true;
            }
        }
    }

    return false;
}



static int[] CordsInput(int[] cor, int size)
{
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
            return cor;
        }
        catch
        {
            Console.WriteLine("Neplatný vstup. Zadej dvě celá čísla oddělená mezerou.");
        }
    }
    ///
}



static string CountAdjacentMines(int[] cor, int size, string[,] field)
{
    int count = 0;
    for (int dx = -1; dx <= 1; dx++)
    {
        for (int dy = -1; dy <= 1; dy++)
        {
            if (dx == 0 && dy == 0)
                continue;

            int nx = cor[0] + dx; // open ai helped me make this work
            int ny = cor[1] + dy;

            if (nx >= 0 && nx < size && ny >= 0 && ny < size)
            {
                if (field[nx, ny] == "*")
                    count++;
            }
        }
    }
    return count.ToString();
}


void InitField()
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
            if (field[a, b] == "*")

            //(cor[0] != a && cor[1] != b)
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

void PlaceMines()
{
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
}


/// PLACING MINES


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


PlaceMines();

while (true)
{

    /// PLAYING FIELD
    InitField();


    cor = CordsInput(cor, size);


    if (field[cor[0], cor[1]] == "*")
    {
        Console.WriteLine("Prohrál jste! Našlapal jste na minu!");
        FinalField(size, field);
        break;
    }
    
    field[cor[0], cor[1]] = CountAdjacentMines(cor, size, field);


    if (!searchMatrix(field, "."))
    {
        Console.WriteLine("Vyhrál jste! Odhalil jste všechna pole bez min!");
        FinalField(size, field);
        break;
    }
}


/// TESTING FIELD -- used if you need to see where mines are placed
/*
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
*/