using SAT;

namespace TestSAT;

public class Tests
{
    // [Test]
    // public void Test1()
    // {
    //     var path = "/Users/macbook/Desktop/unsatTest1.txt";
    //     var clauses = ParseDimacs.Parse(path);
    //     var solution = new List<int>();
    //     var answer = Dpll.AlgorithmDpll(solution, clauses);
    //     var waiting = new List<int>() {-1, 2, -2, -2 };
    //     Assert.That((false, answer), Is.EqualTo(false, waiting));
    // }

    [Test]
    public void Test2()
    {
        var sat = new Sat("/Users/macbook/Desktop/satTest1.txt");
        sat.SatMethod();
        var answer = sat.Solution;
        var waiting = new List<int> { 2, 1 };
        Assert.That(answer, Is.EqualTo(waiting));
    }
    
    [Test]
    public void Test3()
    {
        var sat = new Sat("/Users/macbook/Desktop/satTest2.txt");
        sat.SatMethod();
        var answer = sat.Solution;
        var waiting = new List<int> { -2, 3, 1 };
        Assert.That(answer, Is.EqualTo(waiting));
    }
    
    [Test]
    public void Test4()
    {
        var sat = new Sat("/Users/macbook/Desktop/satTest3.txt");
        sat.SatMethod();
        var answer = sat.Solution;
        var waiting = new List<int> { 1, 5, -3 };
        Assert.That(answer, Is.EqualTo(waiting));
    }
}