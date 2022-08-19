void Task54()
{
    Random rand = new Random();
    int rows = rand.Next(4, 8);
    int columns = rand.Next(4, 8);
    int[,] array = new int[rows, columns];
    fillMatrix(array, rows, columns, 1, 10);
    PrintMatrix(array);
    int temp = 0;


    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            int max_i = i;
            int max_j = j;

            for (int k = j + 1; k < columns; k++)
            {
                if (array[i, k] > array[max_i, max_j])
                {
                    max_i = i;
                    max_j = k;
                }
            }
            temp = array[i, j];
            array[i, j] = array[max_i, max_j];
            array[max_i, max_j] = temp;
        }
    }
    PrintMatrix(array);
}

void Task56()
{
    int rows = 3;
    int columns = 4;
    int[,] array = new int[rows, columns];
    fillMatrix(array, rows, columns, 1, 10);
    PrintMatrix(array);
    int minSum = 1000;
    int minRow = 0;

    for (int i = 0; i < rows; i++)
    {
        int sum = 0;
        for (int j = 0; j < columns; j++)
        {
            sum += array[i, j];
        }
        if (sum < minSum) 
        {
            minSum = sum;
            minRow = i;
        }

    }
    Console.WriteLine($"Min sum digits = {minSum}; in {minRow} row");    
}

void FillSnail()
{
    int size = 4;
    int[,] array = new int[size, size];

    int row = 0;
    int col = 0;
    int dx = 1;
    int dy = 0;
    int dirChanges = 0;
    int visits = size;

    for (int i = 0; i < array.Length; i++) 
    {
        array[row, col] = i + 1;
        if (--visits == 0) 
        {
            visits = size * (dirChanges %2) + size * ((dirChanges + 1) %2) - (dirChanges/2 - 1) - 2;
            int temp = dx;
            dx = -dy;
            dy = temp;
            dirChanges++;
        }
        col += dx;
        row += dy;
    }
    PrintMatrix(array);
}

void MatrixMultiply()
{
    Random rand = new Random();
    int rows = rand.Next(3, 5);
    int columns = rand.Next(3, 5);
    int[,] array = new int[rows, columns];
    int[,] matrix = new int[rows, columns];
    fillMatrix(array, rows, columns, 1, 5);
    fillMatrix(matrix, rows, columns, 1, 5);
    PrintMatrix(array);
    PrintMatrix(matrix);
    int row = array.GetLength(0);
    int col = matrix.GetLength(1);
    int[,] resMatrix = new int[row, col];

    if (row == col)
    {
        for(int i = 0; i < row; i++)
        {
                        
            for(int j = 0; j < col; j++)
            {
                for (int k = 0; k < col; k++)
                {
                    resMatrix[i, j]  += array[i, k] * matrix[k, j];
                }
            }
        }
        Console.WriteLine("Result matrix: ");
        PrintMatrix(resMatrix);
    }
    else Console.WriteLine("Matrix can't multiply");
}

void Extra01()
{
    int rows = 5;
    int columns = 5;
    int[,] array = new int[rows, columns];
    fillMatrix(array, rows, columns, 1, 10);
    PrintMatrix(array);
    int row = rows - 1;
    int col = columns - 1;
    int temp = 0;

    for (int i = 1; i < rows; i++)
    {
        for (int j = 1; j < col; j++)
        {
            if (i == j)
            {
                array[0, j] = array[i, j];
                array[row, col - j] = array[i, col - j];
            }
        }

    }
    temp = array[0, col];
    array[0, col] = array[row, col];
    array[row, col] = temp;
    PrintMatrix(array);
}

void Extra02()
{
    int rows = 4;
    int columns = 4;
    int[,] array = new int[rows, columns];
    fillMatrix(array, rows, columns, -9, 9);
    PrintMatrix(array);
    Dictionary<int, int> dict = new Dictionary<int, int>();
        
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if (dict.ContainsKey(array[i, j]))
            {
                dict[array[i, j]]++;
            }
            else
            {
                dict[array[i, j]] = 1;
            }
        }
    }
    PrintDictionary(dict);
}



void PrintDictionary(Dictionary<int, int> dict)
{
    foreach (KeyValuePair<int, int> kvp in dict)
    {
        Console.WriteLine("Key = {0}, Value = {1}",
        kvp.Key, kvp.Value);
    }
}

void fillMatrix(int[,] array, int row, int col, int start, int end)
{
    Random rand = new Random();

    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            array[i, j] = rand.Next(start, end);
        }
    }
}

void PrintMatrix(int[,] matrix)
{
    int rowSize = matrix.GetLength(0);
    int colSize = matrix.GetLength(1);
    for (int i = 0; i < rowSize; i++)
    {
        Console.Write("[");
        for (int j = 0; j < colSize; j++)
        {
            Console.Write($"{matrix[i, j]}, \t");
        }
        Console.WriteLine("\b\b]");
    }
    Console.WriteLine();
}

// Task54();
// Task56();
// MatrixMultiply();
// FillSnail();
// Extra01();
Extra02();

