using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public static class MatrixIO
{


    //данный метод для записи матрицы в текстовом виде в поток асинхронно
    public static async Task WriteMatrixToTextStreamAsync(double[][] matrix, Stream stream, char sep = ' ')
    {
      using var writer = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true);
      int rows = matrix.Length;
      int cols = matrix[0].Length;
      await writer.WriteLineAsync($"{rows}{sep}{cols}");

      foreach(var row in matrix)
      {
        await writer.WriteLineAsync(string.Join(sep, row));
      }
    }


    //данный метод для чтения матрицы из текстового потока
    public static async Task<double[][]> ReadMatrixFromTextStreamAsync(Stream stream, char sep = ' ')
    {
      using var reader = new StreamReader(stream, Encoding.ITF8, leaveOpen: true);
      var sizeLine = await reader.ReadLineAsync();
      var sizeParts = sizeLine.Split(sep);
      int rows = int.Parse(sizeParts[0]);
      int cols = int.Parse(sizeParts[1]);

      var matrix = new double[rows][];
      for(int i = 0; i < rows; i++)
      {
        var line  = await reader.ReadLineAsync();
        var parts = line.Split(sep);
        matrix[i] = Array.ConvertAll(parts, double.Parse);
      }

      return matrix;
    }

    //данный метод для записи матрицы в бинарном виде в пот
    public static void WriteMatrixToBinaryStream(double[][] matrix, Stream stream)
    {
      using var writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen: true);
      int rows = matrix.Length;
      int cols = martix[0].Length;
      writer.Write(rows);
      writer.Write(cols);

      foreach(var row in matrix)
      {
        foreach(var item in row)
        {
          writer.Write(item);
        }
      }
    }


    //данный метод для чтения матрицы из бинарного потока

    public static double[][] ReadMatrixFromBinaryStream(Stream stream)
    {
      using var reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen: true);
      int rows = reader.ReadInt32();
      int cols = reader.ReadInt32();
      var matrix = new double[rows][];

      for(int i = 0; i < rows; i++)
      {
        matrix[i] new double[cols];
        for(int j = 0; j < cols; j++)
        {
          matrix[i][j] = reader.ReadDouble();
        }
      }

      return matrix;
    }

    //данный метод для записи матрицы в JSON в поток асинх

    public static async Task WriteMatrixToJsonStreamAsync(double[][] matrix, Stream stream)
    {
      await JsonSerializer.SerializeAsync(stream, matrix);
    }

    //данный метод для чтения матрицы из JSON в поток асинхронно
    public static async Task<double[][]> ReadMatrixFromJsonStreamAsync(Stream stream)
    {
      return await JsonSerializer.DeserializeAsync<double[][]>(stream);
    }


    //синхронный метод для записи матрицы в текстовый файл
    public static void WriteMatrixToFile(string directory, string fileName, double[][] matrix, Action<double[][], Stream> writeMethod)
    {
      string filePath = Path.Combine(directory, fileName);
      using var stream = new FileStream(filePath, System.FileMode.Create, FileAccess Write);
      writeMethod(matrix, stream);
    }

    //асинхроннный метод для записи матрицы из текстового файла
    public static async Task WriteMatrixToFileAsync(string directory, string fileName, double[][] matrix, Func<double[][], Stream, Task>  writeMethod)
    {
      string filePath = Path.Combine(directory, fileName);
      using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
      await writeMethod(matrix, stream);
    }


    //синхронный метод для чтения матрицы из текстового файла
    public static double[][] ReadMatrixFromFile(string filePath, Func<Stream, double[][]> readMethod)
    {
      using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
      return readMethod(stream);
    }

    //асинхронный метод для чтения матрицы из текстов
    public static async Task<double[][]> ReadMatrixFileAsync(string filePath, Func<Stream, Task<double[][]>> readMethod)
  {
    using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
    return await readMethod(stream);
  }
}