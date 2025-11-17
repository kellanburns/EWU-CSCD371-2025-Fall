using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Scope = ExecutionScope.ClassLevel)]

[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void TestCsvRowsNotEmpty()
    {
        var sampleData = new Assignment.SampleData();
        var rows = sampleData.CsvRows;
        Assert.IsNotNull(rows);
    }
}