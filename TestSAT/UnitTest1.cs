using SAT;

namespace TestSAT;

public class Tests
{
    [Test]
    public void Test1()
    {
        var path = "../../../TestSatFiles/unsatTest1.txt";
        var clauses = ParseDimacs.Parse(path);
        var solution = new List<int>();
        var (answerBool, answerList) = Dpll.AlgorithmDpll(solution, clauses);
        Assert.That(answerBool, Is.EqualTo(false));
    }

    [Test]
    public void Test2()
    {
        var sat = new Sat("../../../TestSatFiles/satTest1.txt");
        sat.SatMethod();
        var answer = sat.Solution;
        var waiting = new List<int> { 2, 1 };
        Assert.That(answer, Is.EqualTo(waiting));
    }
    
    [Test]
    public void Test3()
    {
        var sat = new Sat("../../../TestSatFiles//satTest2.txt");
        sat.SatMethod();
        var answer = sat.Solution;
        var waiting = new List<int> { -2, 3, 1 };
        Assert.That(answer, Is.EqualTo(waiting));
    }
    
    [Test]
    public void Test4()
    {
        var sat = new Sat("../../../TestSatFiles/satTest3.txt");
        sat.SatMethod();
        var answer = sat.Solution;
        var waiting = new List<int> { 1, 5, -3 };
        Assert.That(answer, Is.EqualTo(waiting));
    }
}