using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;


namespace MatrixClass
{
  public static class MatrixOperations
  {

    //Транспонирование матрицы
    
    public static Matrix Transpose(Matrix matrix)
    {
      double[,] transposedMatrix = new double[matrix.Columns, matrix.Rows];
      for(int i = 0; i < matrix.Rows; i++)
      {
        for(int j = 0; j < matrix.Columns; j++)
        {
          transposed[j, i] = matrix[i, j];
        }
      }
      return new Matrix(transposedMatrix);
    }

    //Умножение на вещественное число
    
    public static Matrix MultiplyByScalar(Matrix matrix, double scalar)
    {
      double[,] scaled = new double [matrix.Rows, matrix.Columns];

      for(int i = 0; i < matrix.Rows; i++)
      {
        for(int j = 0; j < matrix.Columns; j++)
        {
          scaled[i, j] = matrix[i, j] * scalar;
        }
      }
      return new Matrix(scaled);
    }

    //Сложение матриц

    public static Matrix Add(Matrix matrix1, Matrix matrix2)
    {
      if(matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
      {
        throw new InvalidOperationException("Матрицы должны быть одной размерности!");
      }

      double[,] sum = new double[matrix1.Rows, matrix1.Columns];
      for(int i = 0; i < matrix1.Rows; i++)
      {
        for(int j = 0; j < matrix1.Columns; j++)
        {
          sum[i, j] = matrix1[i, j] + matrix2[i, j];
        }
      }
      return new Matrix(sum);
    }

    //Вычитание матриц

    public static Matrix Subtract(Matrix matrix1, Matrix matrix2)
    {
      if(matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
      {
        throw new InvalidOperationException("Матрицы должны быть одной размерности!");
      }

      double[,] difference = new double[matrix1.Rows, matrix1.Columns];
      for(int i = 0; i < matrix1.Rows; i++)
      {
        for(int j = 0; j < matrix1.Columns; j++)
        {
          difference[i, j] = matrix1[i, j] - matrix2[i, j];
        }
      }
      return new Matrix(difference);
    }

    //Умножение матриц
    
    public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
    {
      if(matrix1.Colums != matrix2.Rows)
      {
        throw new InvalidOperationException("Данные разремы недопустимы для умножения.");
      }

      double[,] product = new double[matrix1.Rows, matrix2.Columns];
      for(int i = 0; i < matrix1.Rows; i++)
      {
        for(int j = 0; j < matrix2.Columns; j++)
        {
          for(int k = 0; k < matrix1.Columns; k++)
          {
            product[i, j] += matrix1[i, k] * matrix2[k, j];
          }
        }
      }

      return new Matrix(product);
    }
  }
}