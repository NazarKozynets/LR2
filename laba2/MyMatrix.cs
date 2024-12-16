namespace laba2;

public partial class MyMatrix
{
    private double[,] matrix;
    private int height;
    private int width;
    
    public MyMatrix(MyMatrix anotherMatrix)
    {
        this.height = anotherMatrix.height;
        this.width = anotherMatrix.width;

        this.matrix = new double[height, width];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                this.matrix[i, j] = anotherMatrix.GetElement(i, j);
            }
        }
    }

    public MyMatrix(double[,] anotherMatrix)
    {
        this.matrix = anotherMatrix;
        this.height = anotherMatrix.GetLength(0);
        this.width = anotherMatrix.GetLength(1);
    }

    public MyMatrix(double[][] jaggedArray)
    {
        if (jaggedArray.Length == 0 || jaggedArray.Any(row => row.Length != jaggedArray[0].Length))
        {
            throw new ArgumentException("Зубчастий масив не є прямокутним.");
        }

        height = jaggedArray.Length;
        width = jaggedArray[0].Length;

        matrix = new double[height, width];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                matrix[i, j] = jaggedArray[i][j];
            }
        }
    }

    public MyMatrix(string[] rows)
    {
        if (rows.Length == 0)
        {
            throw new ArgumentException("Масив рядків не може бути порожнім.");
        }

        string[] firstRow = rows[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        width = firstRow.Length;
        height = rows.Length;

        matrix = new double[height, width];

        for (int i = 0; i < height; i++)
        {
            string[] currentRow = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (currentRow.Length != width)
            {
                throw new ArgumentException("Кількість чисел у кожному рядку повинна бути однаковою.");
            }

            for (int j = 0; j < width; j++)
            {
                if (!double.TryParse(currentRow[j], out matrix[i, j]))
                {
                    throw new FormatException($"Не вдалося перетворити \"{currentRow[j]}\" у число.");
                }
            }
        }
    }

    public MyMatrix(string input)
    {
        string[] rows = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        if (rows.Length == 0)
        {
            throw new ArgumentException("Вхідний рядок не може бути порожнім або складатися лише з переведень рядка.");
        }

        string[] firstRow = rows[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        width = firstRow.Length;

        height = rows.Length;
        matrix = new double[height, width];

        for (int i = 0; i < height; i++)
        {
            string[] currentRow = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (currentRow.Length != width)
            {
                throw new ArgumentException("Усі рядки повинні містити однакову кількість чисел.");
            }

            for (int j = 0; j < width; j++)
            {
                if (!double.TryParse(currentRow[j], out matrix[i, j]))
                {
                    throw new FormatException($"Не вдалося перетворити \"{currentRow[j]}\" у число.");
                }
            }
        }
    }
    
    public int Height => height;

    public int Width => width;

    public int GetHeight()
    {
        return height;
    }

    public int GetWidth()
    {
        return width;
    }

    public double this[int row, int col]
    {
        get => matrix[row, col];
        set => matrix[row, col] = value;
    }
    
    public double GetElement(int row, int col)
    {
        if (row < 0 || row >= height || col < 0 || col >= width)
            throw new IndexOutOfRangeException("Індекс виходить за межі матриці.");
        return matrix[row, col];
    }

    public void SetElement(int row, int col, double value)
    {
        if (row < 0 || row >= height || col < 0 || col >= width)
            throw new IndexOutOfRangeException("Індекс виходить за межі матриці.");
        matrix[row, col] = value;
    }
    
    public override string ToString()
    {
        var builder = new System.Text.StringBuilder();

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                builder.Append(matrix[i, j].ToString("F2")); 
                if (j < width - 1)
                    builder.Append("\t"); 
            }
            builder.AppendLine(); 
        }

        return builder.ToString();
    }
}