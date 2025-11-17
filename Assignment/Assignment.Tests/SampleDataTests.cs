using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Assignment;
using System.Collections.Generic;

[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void SampleData_CreateNewInstance_CsvRowsLoadsData()
    {
        SampleData sampleData = new Assignment.SampleData();
        IEnumerable<string> rows = sampleData.CsvRows;
        Assert.IsNotNull(rows);
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_DefaultInstance_ReturnsListOfDistinctValues()
    {
        SampleData sampleData = new Assignment.SampleData();
        IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
        Assert.IsNotNull(states);
        CollectionAssert.AllItemsAreUnique(states.ToList());
        CollectionAssert.AreEqual(states.ToList(), states.Distinct().ToList());
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_DefaultInstance_ReturnsSortedLists()
    {
        SampleData sampleData = new Assignment.SampleData();
        IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
        CollectionAssert.AreEqual(states.ToList(), states.OrderBy(s => s).ToList());
    }
}