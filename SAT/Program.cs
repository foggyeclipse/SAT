// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SAT;

public static class Program
{
    private static void Main(string[] args)
    {
        Sat sat = new Sat(args[0]);
        sat.SatMethod();
    }
}