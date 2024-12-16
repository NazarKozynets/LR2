namespace laba2;

public partial class MyMatrix
{
    public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.height != matrix2.height || matrix1.width != matrix2.width)
        {
            throw new InvalidOperationException("Матриці повинні мати однаковий розмір для додавання.");
        }

        double[,] result = new double[matrix1.height, matrix1.width];

        for (int i = 0; i < matrix1.height; i++)
        {
            for (int j = 0; j < matrix1.width; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return new MyMatrix(result);
    }

    public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.width != matrix2.height)
        {
            throw new InvalidOperationException("Кількість стовпців першої матриці повинна дорівнювати кількості рядків другої матриці.");
        }

        double[,] result = new double[matrix1.height, matrix2.width];

        for (int i = 0; i < matrix1.height; i++)
        {
            for (int j = 0; j < matrix2.width; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < matrix1.width; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return new MyMatrix(result);
    }

    private double[,] GetTransponedArray()
    {
        double[,] transposed = new double[width, height];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                transposed[j, i] = matrix[i, j];
            }
        }

        return transposed;
    }

    public MyMatrix GetTransponedCopy()
    {
        double[,] transposedArray = GetTransponedArray();
        return new MyMatrix(transposedArray);
    }

    public void TransponeMe()
    {
        double[,] transposedArray = GetTransponedArray();
        matrix = transposedArray;
        height = matrix.GetLength(0);
        width = matrix.GetLength(1);
    }
}