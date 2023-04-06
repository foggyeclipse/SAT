// <copyright file="Sat.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SAT;

public class Sat
{
    public Sat(string? path)
    {
        Path = path;
        this.Solution = new List<int>();
    }

    public List<int>? Solution { get; set; }

    private static string? Path { get; set; }

    public void SatMethod()
    {
        var clauses = ParseDimacs.Parse(Path);
        (var sol, Solution) = Dpll.AlgorithmDpll(this.Solution, clauses);
        if (sol)
        {
            Console.WriteLine("s SATISFIABLE");
            Console.Write("v ");
            foreach (var literal in this.Solution!)
            {
                Console.Write(literal + " ");
            }

            Console.Write(0);
        }
        else
        {
            Console.WriteLine("UNSAT");
        }
    }
}