// <copyright file="Dpll.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SAT;

public static class Dpll
{
    public static(bool, List<int>) AlgorithmDpll(List<int>? solution, List<List<int>> clauses)
    {
        UnitPropagate(solution, clauses);
        PureLiteralAssign(solution, clauses);

        if (clauses.Count == 0)
        {
            return (true, solution);
        }

        foreach (var clause in clauses)
        {
            if (clause.Count == 0)
            {
                return (false, solution);
            }
        }

        var chooseLiteral = ChooseLiteral(clauses);
        var positiveClauses = new List<List<int>>();
        var negativeClauses = new List<List<int>>();

        foreach (var clause in clauses)
        {
            positiveClauses.Add(clause);
            negativeClauses.Add(clause);
        }

        positiveClauses.Add(new List<int> { chooseLiteral });
        negativeClauses.Add(new List<int> { -chooseLiteral });

        var copyPositiveClauses = new List<List<int>>();
        var copyNegativeClauses = new List<List<int>>();

        List<List<int>> AddLiteralToCopyPositiveClauses(List<List<int>> positiveClauses)
        {
            foreach (var clause in positiveClauses)
            {
                var copyLiteralPositiveClauses = new List<int>();
                foreach (var literal in clause)
                {
                    copyLiteralPositiveClauses.Add(literal);
                }

                copyPositiveClauses.Add(copyLiteralPositiveClauses);
            }

            return copyPositiveClauses;
        }

        List<List<int>> AddLiteralToCopyNegativeClauses(List<List<int>> negativeClauses)
        {
            foreach (var clause in negativeClauses)
            {
                var copyLiteralNegativeClauses = new List<int>();
                foreach (var literal in clause)
                {
                    copyLiteralNegativeClauses.Add(literal);
                }

                copyNegativeClauses.Add(copyLiteralNegativeClauses);
            }

            return copyNegativeClauses;
        }

        var copyPositive = AddLiteralToCopyPositiveClauses(positiveClauses);
        var copyNegative = AddLiteralToCopyNegativeClauses(negativeClauses);

        var copyPositiveSolution = new List<int>();
        var copyNegativeSolution = new List<int>();

        foreach (var literal in solution)
        {
            copyPositiveSolution.Add(literal);
            copyNegativeSolution.Add(literal);
        }

        (bool solved, solution) = AlgorithmDpll(copyPositiveSolution, copyPositive);
        if (solved)
        {
            solution = solution.ToHashSet().ToList();
            return (true, solution);
        }
        // return AlgorithmDpll(copyPositiveSolution, copyPositive) || AlgorithmDpll(copyNegativeSolution, copyNegative);
        return AlgorithmDpll(copyNegativeSolution, copyNegative);
    }

    private static void UnitPropagate(List<int>? solution, List<List<int>> clauses)
    {
        var temporarySolution = new List<int>();
        foreach (var clause in clauses)
        {
            if (clause.Count != 1)
            {
                continue;
            }

            temporarySolution.Add(clause[0]);
        }

        foreach (var clause in clauses.ToList())
        {
            foreach (var literal in temporarySolution)
            {
                if (clause.Contains(literal))
                {
                    clauses.Remove(clause);
                }

                if (clause.Contains(-literal))
                {
                    clause.Remove(-literal);
                }
            }
        }

        foreach (var literal in temporarySolution)
        {
            solution!.Add(literal);
        }
    }

    private static void PureLiteralAssign(List<int>? solution, List<List<int>> clauses)
    {
        var temporarySolution = new List<int>();
        var set = new HashSet<int>();

        foreach (var clause in clauses)
        {
            foreach (var literal in clause)
            {
                set.Add(literal);
            }
        }

        foreach (var literal in set)
        {
            if (!set.Contains(-literal))
            {
                temporarySolution.Add(literal);
            }
        }

        foreach (var clause in clauses.ToList())
        {
            foreach (var literal in temporarySolution)
            {
                if (clause.Contains(literal))
                {
                    clauses.Remove(clause);
                }
            }
        }

        foreach (var literal in temporarySolution)
        {
            solution!.Add(literal);
        }
    }

    private static int ChooseLiteral(List<List<int>> clauses)
    {
        return clauses[0][0];
    }
}