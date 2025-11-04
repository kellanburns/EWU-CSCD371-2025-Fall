using System.Numerics;
using System.Xml;

namespace Calculate.Tests;

[TestClass]
public sealed class ProgramTests
{
    [TestMethod]
    public void Run_DelegateInjection_FunctionsProperly()
    {
        var writeList = new List<string?>();
        var inputs = new Queue<string?>(new[] { "6 + 7", "" });
        var prog = new Program(
            writeLine: s => writeList.Add(s),
            readLine: () => inputs.Count > 0 ? inputs.Dequeue() : null
        );
        var calc = new Calculator<int>();

        var exit = prog.Run(calc);

        Assert.AreEqual<int>(0, exit);
        Assert.AreEqual<string>("13", writeList[1]);
    }

    [TestMethod]
    public void Run_InvalidInput_AsksForInputAgain()
    {
        var writeList = new List<string?>();
        var inputs = new Queue<string?>(new[] { "6+ 7", "6 + 7", "" });
        var prog = new Program(
            writeLine: s => writeList.Add(s),
            readLine: () => inputs.Count > 0 ? inputs.Dequeue() : null
        );
        var calc = new Calculator<int>();

        var exit = prog.Run(calc);

        Assert.AreEqual<int>(0, exit);
        Assert.AreEqual<string>("Invalid input. Try again.", writeList[1]);
        Assert.AreEqual<string>("13", writeList[3]);
    }
    
    [TestMethod]
    public void Run_WhitespaceInput_ExitsLoop()
    {
        var writeList = new List<string?>();
        var inputs = new Queue<string?>(new[] { "" });
        var prog = new Program(
            writeLine: s => writeList.Add(s),
            readLine: () => inputs.Count > 0 ? inputs.Dequeue() : null
        );
        var calc = new Calculator<int>();

        var exit = prog.Run(calc);

        Assert.AreEqual<int>(0, exit);
        Assert.AreEqual<string>("Exiting Calculator.", writeList[1]);
    }
}
