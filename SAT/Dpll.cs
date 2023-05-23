// <copyright file="Dpll.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;

namespace SAT;

public static class Dpll
{
    public static(bool, List<int> solution) AlgorithmDpll(List<int> solution, List<List<int>> clauses)
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
        var copyClauses = clauses.ToList();

        copyClauses.Add(new List<int> { chooseLiteral });
        clauses.Add(new List<int> { -chooseLiteral });

        var copySolution = solution.ToList();
        (var dpll, copySolution) = AlgorithmDpll(copySolution, copyClauses);
        if (dpll)
        {
            copySolution = copySolution.ToHashSet().ToList();
            return (true, copySolution);
        }

        return AlgorithmDpll(solution, copyClauses);
    }

    private static void UnitPropagate(List<int> solution, List<List<int>> clauses)
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

                foreach (var temporaryLiteral in clause.ToList())
                {
                    if (temporaryLiteral == -literal)
                    {
                        clause.Remove(temporaryLiteral);
                    }
                }
            }
        }

        foreach (var literal in temporarySolution)
        {
            solution.Add(literal);
        }
    }

    private static void PureLiteralAssign(List<int> solution, List<List<int>> clauses)
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
            if (set.Contains(-literal))
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
            solution.Add(literal);
        }
    }

    private static int ChooseLiteral(List<List<int>> clauses)
    {
        return clauses[0][0];
    }
}