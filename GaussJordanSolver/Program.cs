using GaussJordanSolverPackage;
public class Program 
{
    public static void Main(String[] args)
    {
        GaussJordanSolver g = new GaussJordanSolver();
        double[,] matrix =
        {
                { 3.0,  -4.0, -4.0 },
                { 2.0,  3.0,  3.0},

        };
        g.printSolve(g.Solve(matrix));
    }
}