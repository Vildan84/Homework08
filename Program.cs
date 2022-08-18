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
Task56();
