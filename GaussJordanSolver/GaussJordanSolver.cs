namespace GaussJordanSolverPackage;
class GaussJordanSolver
{
    public GaussJordanSolver() { }
    public double[] Solve(double[,] matrix)
    {
        double[] solvedArray = new double[matrix.GetLength(0)];
        if (!IsSingular(CalculateDeterminant(matrix)))
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        //if (matrix[j, i] != 0)
                        //    SwapMatrix(matrix, i, j);
                        //else throw new Exception("Singular Matrix");
                        continue;
                    }
                }
                // Ln < -Ln / matrix[i][i]
                if (matrix[i, i] != 1)
                {
                    double coef = matrix[i, i];
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        matrix[i, j] /= coef;
                }
                // Ln <- Ln - matrix[i][j]*Ln
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (i != j)
                    {
                        double coef = matrix[j, i];
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            matrix[j, k] -= coef * matrix[i, k];
                        }
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
                solvedArray[i] = matrix[i, matrix.GetLength(1) - 1];
        }
        //printSolveMatrix(matrix);
        return solvedArray;
    }
    public void printSolveMatrix(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write(" | ");
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]}, ");
            }
            Console.WriteLine(" | ");
        }
    }
    public void printSolve(double[] solvedMatrix)
    {
        Console.WriteLine("Rounded Solution:");
        Console.Write("| ");
        for (int i = 0; i < solvedMatrix.Length; i++)
            Console.Write($"{Math.Round(solvedMatrix[i])}, ");
        Console.Write(" |");

    }
    private double CalculateDeterminant(double[,] matrix)
    {
        double[,] _matrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
        Array.Copy(matrix, _matrix, matrix.Length);
        double determinant = 1.0;
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            if (_matrix[i, i] == 0)
            {
                for (int j = 1; j < _matrix.GetLength(1); j++)
                {
                    //if (_matrix[j,i] != 0)
                    //{
                    //    double[] mainBucket = _matrix[j];
                    //    SwapMatrix(_matrix, i, j);
                    //}
                    //else throw new Exception("Singular Matrix");
                    continue;
                }
            }
            for (int j = i + 1; j < _matrix.GetLength(0); j++)
            {
                double coef = _matrix[j, i] / _matrix[i, i];
                for (int k = 0; k < _matrix.GetLength(1);)
                {
                    for (int l = 0; l < _matrix.GetLength(1); l++)
                        _matrix[j, l] = _matrix[j, l] - coef * _matrix[i, l];
                    break;
                }
            }
        }
        for (int i = 0; i < _matrix.GetLength(0); i++)
            determinant *= _matrix[i, i];
        return determinant;
    }
    private bool IsSingular(double determinant)
    {
        if (determinant != 0)
            return false;
        return true;
    }
    private double[][] SwapMatrix(double[][] matrix, int iIndex, int jIndex)
    {
        double[] bucket = matrix[iIndex];
        matrix[iIndex] = matrix[jIndex];
        matrix[jIndex] = bucket;
        return matrix;
    }
}