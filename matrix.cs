using System;

class Matrix
{
    private double[,] values;

    public Matrix(int rows, int columns)
    {
        values = new double[rows, columns];
    }

    public Matrix(double[,] data)
    {
        values = (double[,])data.Clone();
    }

    public double this[int i, int j]
    {
        get { return values[i, j]; }
    }

    public int Rows => values.GetLength(0);

    public int Columns => values.GetLength(1);

    public static Matrix Zero(int rows, int columns) => new Matrix(rows, columns);

    public static Matrix Zero(int n) => Zero(n, n);

    public static Matrix Identity(int n)
    {
        var result = Zero(n);
        for (int i = 0; i < n; i++)
        {
            result.values[i, i] = 1;
        }
        return result;
    }

    public Matrix Transpose()
    {
        var result = new Matrix(Columns, Rows);
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                result.values[j, i] = values[i, j];
            }
        }
        return result;
    }

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                sb.Append(values[i, j] + " ");
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Matrix))
            return false;

        Matrix other = (Matrix)obj;
        if (Rows != other.Rows || Columns != other.Columns)
            return false;

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (values[i, j] != other.values[i, j])
                    return false;
            }
        }
        return true;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Rows.GetHashCode();
            hash = hash * 23 + Columns.GetHashCode();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    hash = hash * 23 + values[i, j].GetHashCode();
                }
            }
            return hash;
        }
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
            throw new InvalidOperationException("Матрицы должны быть одной размерности!");

        Matrix result = new Matrix(a.Rows, a.Columns);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Columns; j++)
            {
                result.values[i, j] = a.values[i, j] + b.values[i, j];
            }
        }
        return result;
    }

    public static Matrix operator -(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
            throw new InvalidOperationException("Матрицы должны быть одной размерности!");

        Matrix result = new Matrix(a.Rows, a.Columns);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Columns; j++)
            {
                result.values[i, j] = a.values[i, j] - b.values[i, j];
            }
        }
        return result;
    }

    public static Matrix operator *(Matrix a, double scalar)
    {
        Matrix result = new Matrix(a.Rows, a.Columns);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Columns; j++)
            {
                result.values[i, j] = a.values[i, j] * scalar;
            }
        }
        return result;
    }

    public static Matrix operator *(double scalar, Matrix a)
    {
        return a * scalar;
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.Columns != b.Rows)
            throw new InvalidOperationException("Количество столбцов в первой матрице должно равняться количеству строк во второй матрице.");

        Matrix result = new Matrix(a.Rows, b.Columns);
        for (int i = 0; i < result.Rows; i++)
        {
            for (int j = 0; j < result.Columns; j++)
            {
                for (int k = 0; k < a.Columns; k++)
                {
                    result.values[i, j] += a.values[i, k] * b.values[k, j];
                }
            }
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем матрицу размером 2x3
        double[,] data = { { 1, 2, 3 }, { 4, 5, 6 } };
        Matrix matrix1 = new Matrix(data);

        // Выводим матрицу на экран
        Console.WriteLine("Матрицы 1:");
        Console.WriteLine(matrix1);

        // Создаем нулевую матрицу размером 2x3
        Matrix zeroMatrix = Matrix.Zero(2, 3);
        Console.WriteLine("Нулевая матрица:");
        Console.WriteLine(zeroMatrix);

        // Создаем единичную матрицу размером 3x3
        Matrix identityMatrix = Matrix.Identity(3);
        Console.WriteLine("Единичная матрица:");
        Console.WriteLine(identityMatrix);

        // Сложение матриц
        Matrix matrix2 = new Matrix(new double[,] { { 7, 8, 9 }, { 10, 11, 12 } });
        Console.WriteLine("Матрица 2:");
        Console.WriteLine(matrix2);

        Console.WriteLine("Сумма:");
        Matrix sumMatrix = matrix1 + matrix2;
        Console.WriteLine(sumMatrix);

        // Умножение матриц на скаляр
        double scalar = 2.0;
        Console.WriteLine($"Скалярное произведение {scalar}:");
        Matrix scalarProduct = matrix1 * scalar;
        Console.WriteLine(scalarProduct);

        // Умножение матриц
        Console.WriteLine("Умножение:");
        Matrix productMatrix = matrix1 * matrix2.Transpose();
        Console.WriteLine(productMatrix);

        // Транспонирование матрицы
        Console.WriteLine("Транспонирование:");
        Matrix transposedMatrix = matrix1.Transpose();
        Console.WriteLine(transposedMatrix);

        // Проверка на равенство матриц
        Console.WriteLine("Проверка на равенство:");
        Console.WriteLine(matrix1.Equals(matrix1)); // должно быть true
        Console.WriteLine(matrix1.Equals(matrix2)); // должно быть false

        // Получение хеш-кода матрицы
        Console.WriteLine("Хэш-код:");
        Console.WriteLine(matrix1.GetHashCode());
        Console.WriteLine(matrix2.GetHashCode());

        Console.ReadLine();
    }
}
