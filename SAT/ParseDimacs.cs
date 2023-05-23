// <copyright file="ParseDimacs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;

namespace SAT;

public static class ParseDimacs
{
    public static List<List<int>> Parse(string? path)
    {
        var clauses = new List<List<int>>();
        using var streamReader = new StreamReader(path!);
        while (streamReader.ReadLine() is { } line)
        {
            switch (line[0])
            {
                case 'c':
                    continue;
                case 'p':
                    continue;
            }

            var clause = new List<int>();
            var splitLine = line.Split(' ');
            foreach (var variableString in splitLine)
            {
                if (variableString == string.Empty || variableString == "0")
                {
                    continue;
                }

                var variableInt = Convert.ToInt32(variableString);
                clause.Add(variableInt);
            }

            clauses.Add(clause);
        }

        return clauses;
    }
}