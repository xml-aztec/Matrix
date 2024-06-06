using System;
using System.IO;
using System.Threading.Tasks;
//были проблемы с vs

class Program
{
    static void Main(string[] args)
    {
        // Примеры использования методов
        TestCreateRandomMatrix();
        TestMultiplyMatrices();
        TestScalarProduct();
        TestWriteMatricesToDirectory();
        TestReadMatricesFromDirectory();
        TestCompareMatrices();
    }

    // Создать матрицу со случайными значениями
    static void TestCreateRandomMatrix()
    {
        Console.WriteLine("=== Создать матрицу со случайными значениями ===");

        int rows = 3;
        int columns = 4;
        Matrix randomMatrix = MatrixOperations.CreateRandomMatrix(rows, columns, -10, 10);

        Console.WriteLine($"Сгенерированная матрица {rows}x{columns}:");
        Console.WriteLine(randomMatrix);
    }

    // Перемножить массивы матриц поочередно
    static void TestMultiplyMatrices()
    {
        Console.WriteLine("\n=== Перемножить массивы матриц поочередно ===");

        double[,] data1 = { { 1, 2 }, { 3, 4 } };
        double[,] data2 = { { 5, 6 }, { 7, 8 } };
        double[,] data3 = { { 9, 10 }, { 11, 12 } };

        Matrix matrix1 = new Matrix(data1);
        Matrix matrix2 = new Matrix(data2);
        Matrix matrix3 = new Matrix(data3);

        try
        {
            Matrix result = MatrixOperations.MultiplyMatrices(matrix1, matrix2, matrix3);
            Console.WriteLine("Результат умножения матриц:");
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // Вычислить скалярное произведение двух массивов матриц
    static void TestScalarProduct()
    {
        Console.WriteLine("\n=== Вычислить скалярное произведение двух массивов матриц ===");

        double[,] data1 = { { 1, 2 }, { 3, 4 } };
        double[,] data2 = { { 5, 6 }, { 7, 8 } };

        Matrix matrix1 = new Matrix(data1);
        Matrix matrix2 = new Matrix(data2);

        try
        {
            double scalarProduct = MatrixOperations.ScalarProduct(matrix1, matrix2);
            Console.WriteLine($"Скалярное произведение матриц: {scalarProduct}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // Записать массив матриц в директорию
    static void TestWriteMatricesToDirectory()
    {
        Console.WriteLine("\n=== Записать массив матриц в директорию ===");

        Matrix[] matrices = {
            new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }),
            new Matrix(new double[,] { { 5, 6 }, { 7, 8 } }),
            new Matrix(new double[,] { { 9, 10 }, { 11, 12 } })
        };

        string directory = "./Matrices";
        string prefix = "matrix";
        string extension = "txt";

        MatrixIO.WriteMatricesToDirectory(matrices, directory, prefix, extension, MatrixIO.WriteMatrixToTextFile);

        Console.WriteLine("Матрицы успешно записаны в директорию.");
    }

    // Прочитать массив матриц из директории
    static void TestReadMatricesFromDirectory()
    {
        Console.WriteLine("\n=== Прочитать массив матриц из директории ===");

        string directory = "./Matrices";
        string prefix = "matrix";
        string extension = "txt";

        Matrix[] matrices = MatrixIO.ReadMatricesFromDirectory(directory, prefix, extension, MatrixIO.ReadMatrixFromTextFile);

        foreach (var matrix in matrices)
        {
            Console.WriteLine("Прочитана матрица:");
            Console.WriteLine(matrix);
        }
    }

    // Сравнить два массива матриц на равенство
    static void TestCompareMatrices()
    {
        Console.WriteLine("\n=== Сравнить два массива матриц на равенство ===");

        double[,] data1 = { { 1, 2 }, { 3, 4 } };
        double[,] data2 = { { 1, 2 }, { 3, 4 } };

        Matrix matrix1 = new Matrix(data1);
        Matrix matrix2 = new Matrix(data2);

        bool isEqual = MatrixOperations.CompareMatrices(matrix1, matrix2);
        if (isEqual)
        {
            Console.WriteLine("Матрицы равны.");
        }
        else
        {
            Console.WriteLine("Матрицы не равны.");
        }
    }
}
