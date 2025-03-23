using System.ComponentModel.Design;
using System.IO.IsolatedStorage;
using System.Runtime.InteropServices;

namespace GaussJordanSolverPackage; 

class GaussJordanSolver 
{
    public GaussJordanSolver() {}
    public double[] Solve(double[][] matrix) 
    {
        double[] solvedArray = new double[matrix.Length];
        if (!IsSingular(CalculateDeterminant(matrix))) 
        {
            for (int i = 0; i < matrix.Length; i++) 
            {
                if (matrix[i][i] == 0)
                {
                    for (int j = 0; j < matrix[i].Length - 1; j++)
                    {
                        if (matrix[j][i] != 0)
                            SwapMatrix(matrix, i, j);
                        else throw new Exception("Singular Matrix");

                    }
                }
                // Ln < -Ln / matrix[i][i]
                if (matrix[i][i] != 1) 
                {
                    double coef = matrix[i][i];
                    for (int j = 0; j < matrix[i].Length - 1; j++)
                        matrix[i][j] /= coef;
                }
                // Ln <- Ln - matrix[i][j]*Ln
                for (int j = 0; j < matrix.Length - 1; j++) 
                {
                    if (i != j)
                    {
                        double coef = matrix[j][i];
                        for (int k = 0; k < matrix[i].Length - 1; k++)
                        {
                            matrix[j][k] -= coef * matrix[i][k];
                        }
                    }
                }
            }
            for (int j = 0; j < matrix.Length ; j++)
                solvedArray[j] = matrix[j][matrix.Length];
        }
        printSolveMatrix(matrix);
        return solvedArray;
    }
    public void printSolveMatrix(double[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++) 
        {
            Console.Write(" | ");
            for (int j = 0; j < matrix[i].Length; j++)
            {
                Console.Write($"{matrix[i][j]}, ");
            }
            Console.WriteLine(" | ");        
        }

    }

    public void printSolve(double[] matrix)
    {
        Console.Write("| ");
        for (int i = 0; i < matrix.Length; i++)
            Console.Write($"{matrix[i]}, ");
        Console.Write(" |");

    }
    private double CalculateDeterminant(double[][] matrix)  
    {
        double[][] _matrix = matrix;
        double determinant = 1.0;
        for (int i = 0; i < _matrix.Length; i++)
        {
            if (_matrix[i][i] == 0)
            {
                for (int j = 1; j < _matrix.Length; j++)
                {
                    if (_matrix[j][i] != 0)
                    {
                        double[] mainBucket = _matrix[j];
                        SwapMatrix(_matrix, i, j);
                    }
                    else throw new Exception("Singular Matrix");
                }
            }
            for (int j = i+1; j < _matrix.Length; j ++)
            {
                double coef = _matrix[j][i] / _matrix[i][i];
                for (int k = 0; k < _matrix[j].Length;)
                {
                    for (int l = 0; l < _matrix[j].Length; l++)
                    _matrix[j][l] = _matrix[j][l] - coef * _matrix[i][l];
                    break;
                }
            }
        }
        for (int i = 0; i< _matrix.Length; i++)
            determinant *= _matrix[i][i];
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
