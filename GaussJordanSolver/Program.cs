using GaussJordanSolverPackage;
public class Program 
{
    public static void Main(String[] args)
    {
        GaussJordanSolver g = new GaussJordanSolver();
        double[][] matrix =
        {
                [ 3.0,  2.0, -4.0, 3.0 ],
                [ 2.0,  3.0,  3.0, 15.0 ],
                [5.0, -3.0,  1.0, 14.0 ],
        };
        g.printSolve(g.Solve(matrix));
    }
}