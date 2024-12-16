using Xunit;

namespace laba2;

public class MatrixTests
{
    [Fact]
    public void CreateMatrixFromJaggedArray()
    {
        //Спочатку створю цей масив, потім перевірю кожний елемент матриці на рівність з відповідним елементом масива
        double[][] jaggedArray = new double[][]
        {
            new double[] {1, 2, 3, 4},
            new double[] {5, 6, 7, 8}
        };

        MyMatrix matrix = new MyMatrix(jaggedArray);

        for (int i = 0; i < matrix.GetHeight(); i++)
        {
            for (int j = 0; j < matrix.GetWidth(); j++)
            {
                //для отримання елемента матриці використаю індексатори
                Assert.Equal(jaggedArray[i][j], matrix[i, j]);
            }
        }
    }
    
    [Fact]
    public void CreateMatrixFromAnotherMatrix()
    {
        MyMatrix anotherMatrix = new MyMatrix(new double[][]
        {
            new double[] {1, 2, 3},
            new double[] {3, 4, 9},
            new double[] {8, 7, 9},
            new double[] {3, 9, 9},
        });

        MyMatrix newMatrix = new MyMatrix(anotherMatrix);
        
        //первірка чи дорвнює оригінальна матриця новій
        Assert.Equal(anotherMatrix.GetHeight(), newMatrix.GetHeight());
        Assert.Equal(anotherMatrix.GetWidth(), newMatrix.GetWidth());

        for (int i = 0; i < anotherMatrix.GetHeight(); i++)
        {
            for (int j = 0; j < anotherMatrix.GetWidth(); j++)
            {
                Assert.Equal(anotherMatrix.GetElement(i, j), newMatrix.GetElement(i, j));
            }
        }
    }

    [Fact]
    public void AddMatrix()
    {
        double[,] jaggedArray = new double[,]
        {
            {1, 2, 3, 4},
            {5, 6, 7, 8}
        };

        double[][] twoDimens = new double[][]
        {
            new double[] {3, 2, 2, 0},
            new double[] {5, 2, 7, 8}
        };

        double[][] expectedResultOfSum = new double[][]
        {
            new double[] { 4, 4, 5, 4 },
            new double[] { 10, 8, 14, 16 }
        };

        MyMatrix matrixOne = new MyMatrix(jaggedArray);
        MyMatrix matrixTwo = new MyMatrix(twoDimens);

        MyMatrix resultOfSum = matrixOne + matrixTwo;

        for (int i = 0; i < resultOfSum.GetHeight(); i++)
        {
            for (int j = 0; j < resultOfSum.GetWidth(); j++)
            {
                Assert.Equal(expectedResultOfSum[i][j], resultOfSum[i, j]);
            }
        }
    }

    [Fact]
    public void MultriplyMatrix()
    {
        double[,] jaggedArray = new double[,]
        {
            {1, 2, 3, 4},
            {5, 6, 7, 8}
        };

        double[][] twoDimens = new double[][]
        {
            new double[] {3, 2, 2, 0},
            new double[] {5, 2, 7, 8},
            new double[] {3, 2, 2, 0},
            new double[] {5, 2, 7, 8}
        };
        
        double[][] expectedResultOfMultiply = new double[][]
        {
            new double[] { 42, 20, 50, 48 },
            new double[] { 106, 52, 122, 112 }
        };
        
        MyMatrix matrixOne = new MyMatrix(jaggedArray);
        MyMatrix matrixTwo = new MyMatrix(twoDimens);

        MyMatrix result = matrixOne * matrixTwo;
        
        for (int i = 0; i < result.GetHeight(); i++)
        {
            for (int j = 0; j < result.GetWidth(); j++)
            {
                Assert.Equal(expectedResultOfMultiply[i][j], result[i, j]);
            }
        }
    }
}