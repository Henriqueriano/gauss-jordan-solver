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
                    for (int j = 0; j < matrix.GetLength(0); j++)
                        if (matrix[j, i] != 0)
                            SwapLine(matrix, i, j);
                        else throw new Exception("singular matrix");
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
                            matrix[j, k] -= coef * matrix[i, k];
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
                solvedArray[i] = matrix[i, matrix.GetLength(1) - 1];
        }
        return solvedArray;
    }
    public void PrintSolvedMatrix(double[,] matrix)
    {
        // Mimic Matrix:
        double[,] _matrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
        Array.Copy(matrix, _matrix, matrix.Length);
        // In this case, the result is despised, I only need the result:
        Solve(_matrix);
        Console.WriteLine("Solved Matrix:");
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            Console.Write("| ");
            for (int j = 0; j < _matrix.GetLength(1); j++)
                Console.Write($"{_matrix[i, j]}, ");
            Console.WriteLine("|");
        }
    }
    public void PrintSolution(double[] solvedMatrix)
    {
        Console.WriteLine("Rounded Solution:");
        Console.Write("| ");
        for (int i = 0; i < solvedMatrix.Length; i++)
            Console.Write($"{Math.Round(solvedMatrix[i])}, ");
        Console.WriteLine("|");
    }
    private double CalculateDeterminant(double[,] matrix)
    {
        // Mimic Matrix:
        double[,] _matrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
        Array.Copy(matrix, _matrix, matrix.Length);
        double determinant = 1.0;
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            if (_matrix[i, i] == 0)
                throw new Exception("Singular Matrix.");
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
    private void SwapLine(double[,] matrix, int indexOne, int indexTwo)
    {
        //https://stackoverflow.com/questions/5375233/swap-elements-in-a-2d-array-c-sharp
        for (int i = 0; i <= matrix.GetUpperBound(1); ++i)
        {
            var t = matrix[indexOne, i];
            matrix[indexOne, i] = matrix[indexTwo, i];
            matrix[indexTwo, i] = t;
        }
    }
}