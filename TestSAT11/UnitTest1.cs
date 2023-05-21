using SAT;

namespace TestSAT;

public class Tests
{
    [Test]
     public void Test1()
     {
         var path = "..//..//..//TestSatFiles//unsat01.txt";
         var clauses = ParseDimacs.Parse(path);
         var solution = new List<int>();
         var (answerBool, _) = Dpll.AlgorithmDpll(solution, clauses);
         Assert.That(answerBool, Is.EqualTo(false));
     }
     
     [Test]
     public void Test2()
     {
         var path = "..//..//..//TestSatFiles//unsat02.txt";
         var clauses = ParseDimacs.Parse(path);
         var solution = new List<int>();
         var (answerBool, _) = Dpll.AlgorithmDpll(solution, clauses);
         Assert.That(answerBool, Is.EqualTo(false));
     }

    [Test]
    public void Test3()
    {
        var sat = new Sat("..//..//..//TestSatFiles//01.txt");
        sat.SatMethod();
        var answer = sat.Solution;
        var waiting = new List<int> { 1, 5, -3 };
        Assert.That(answer, Is.EqualTo(waiting));
    }
    
    [Test]
    public void Test4()
    {
        var sat = new Sat("..//..//..//TestSatFiles//02.txt");
        sat.SatMethod();
        var answer = sat.Solution;
        var waiting = new List<int> { 2, 1 };
        Assert.That(answer, Is.EqualTo(waiting));
    }
    
    [Test]
    public void Test5()
    {
        var sat = new Sat("..//..//..//TestSatFiles//03.txt");
        sat.SatMethod();
        var answer = sat.Solution;
        var waiting = new List<int> { 1, 4, -5, 2 };
        Assert.That(answer, Is.EqualTo(waiting));
    }
    
    [Test]
    public void Test6()
    {
        var sat = new Sat("..//..//..//TestSatFiles//04.txt");
        sat.SatMethod();
        var answer = sat.Solution;
        var waiting = new List<int> { 1, 3, 12, 13, -2, -4, -11, 5, 6, 7, 16, 8, 9, -15, -14 };
        Assert.That(answer, Is.EqualTo(waiting));
    }
}