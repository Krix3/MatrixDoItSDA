using System;

class MatrixOperations
{
    static void Main()
    {
        Console.WriteLine("Выберите операцию:");
        Console.WriteLine("1. Умножение матрицы на число");
        Console.WriteLine("2. Сложение матриц");
        Console.WriteLine("3. Произведение матриц");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                MultiplyMatrixByNumber();
                break;
            case 2:
                AddMatrices();
                break;
            case 3:
                MultiplyMatrices();
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }
    }

    static void MultiplyMatrixByNumber()
    {
        Console.WriteLine("Введите размер матрицы (строки и столбцы):");
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        double[,] matrix = new double[rows, cols];
        Console.WriteLine("Введите элементы матрицы:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = double.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Введите число для умножения:");
        double number = double.Parse(Console.ReadLine());

        double[,] result = MultiplyByNumber(matrix, number);
        Console.WriteLine("Результат умножения матрицы на число:");
        PrintMatrix(result);
    }

    static void AddMatrices()
    {
        Console.WriteLine("Введите размер матриц (строки и столбцы):");
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        double[,] matrix1 = new double[rows, cols];
        double[,] matrix2 = new double[rows, cols];

        Console.WriteLine("Введите элементы первой матрицы:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix1[i, j] = double.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Введите элементы второй матрицы:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix2[i, j] = double.Parse(Console.ReadLine());
            }
        }

        double[,] result = AddMatrices(matrix1, matrix2);
        Console.WriteLine("Результат сложения матриц:");
        PrintMatrix(result);
    }

    static void MultiplyMatrices()
    {
        Console.WriteLine("Введите размеры первой матрицы (строки и столбцы):");
        int rows1 = int.Parse(Console.ReadLine());
        int cols1 = int.Parse(Console.ReadLine());

        double[,] matrix1 = new double[rows1, cols1];
        Console.WriteLine("Введите элементы первой матрицы:");
        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols1; j++)
            {
                matrix1[i, j] = double.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Введите размеры второй матрицы (строки и столбцы):");
        int rows2 = int.Parse(Console.ReadLine());
        int cols2 = int.Parse(Console.ReadLine());

        if (cols1 != rows2)
        {
            Console.WriteLine("Матрицы нельзя перемножить (количество столбцов первой матрицы не равно количеству строк второй матрицы).");
            return;
        }

        double[,] matrix2 = new double[rows2, cols2];
        Console.WriteLine("Введите элементы второй матрицы:");
        for (int i = 0; i < rows2; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                matrix2[i, j] = double.Parse(Console.ReadLine());
            }
        }

        double[,] result = MultiplyMatrices(matrix1, matrix2);
        Console.WriteLine("Результат умножения матриц:");
        PrintMatrix(result);
    }

    static double[,] MultiplyByNumber(double[,] matrix, double number)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] * number;
            }
        }

        return result;
    }

    static double[,] AddMatrices(double[,] matrix1, double[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    static double[,] MultiplyMatrices(double[,] matrix1, double[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int cols2 = matrix2.GetLength(1);
        double[,] result = new double[rows1, cols2];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < cols1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return result;
    }

    static void PrintMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}