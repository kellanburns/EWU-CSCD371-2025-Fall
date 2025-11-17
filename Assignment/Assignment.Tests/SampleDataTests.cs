using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;

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
        Assert.IsTrue(IsNonDecreasingList(states));
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_DefaultInstance_ReturnsSingleString()
    {
        SampleData sampleData = new Assignment.SampleData();
        string aggregatedStates = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
        Console.WriteLine(aggregatedStates);
        Assert.IsNotNull(aggregatedStates);
        Assert.Contains(",", aggregatedStates);
    }

    //We are not testing to make sure that GetAggregateSortedListOfStatesUsingCsvRows is returning
    //Distinct states because that is being tested by GetUniqueSortedListOfStatesGivenCsvRows which 
    //GetAggregateSortedListOfStatesUsingCsvRows is using. Therefore we can assume that GetAggregateSortedListOfStatesUsingCsvRows
    //is distinct.

    bool IsNonDecreasingList(IEnumerable<string> input)
    {
        return input
            .Zip(input.Skip(1), (prev, next) => string.Compare(next, prev, StringComparison.Ordinal) >= 0)
            .All(result => result);
    }
}