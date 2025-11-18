using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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

    [TestMethod]
    public void People_DefaultInstance_PopulatesPeopleProperty()
    {
        SampleData sampleData = new Assignment.SampleData();
        IEnumerable<IPerson> people = sampleData.People;
        Assert.IsNotNull(people);
        Assert.IsTrue(people.Any());
    }

    [TestMethod]
    public void People_DefaultInstance_ContainsAllPeopleData()
    {
        SampleData sampleData = new Assignment.SampleData();
        IEnumerable<string> csvRows = sampleData.CsvRows;
        List<IPerson> peopleList = sampleData.People.ToList(); 

        Assert.IsTrue(
            csvRows
                .Select(row => CreatePerson(row))
                .All(CreatedPerson => peopleList.Any(p =>
                    p.FirstName == CreatedPerson.FirstName &&
                    p.LastName == CreatedPerson.LastName &&
                    p.EmailAddress == CreatedPerson.EmailAddress &&
                    p.Address.City == CreatedPerson.Address.City &&
                    p.Address.State == CreatedPerson.Address.State &&
                    p.Address.Zip == CreatedPerson.Address.Zip
                ))
        );
    }

    [TestMethod]
    public void People_ShouldBeSortedByStateCityZip()
    {
        // Arrange
        SampleData sampleData = new Assignment.SampleData();
        List<IPerson> personList = sampleData.People.ToList();

        // Act

        // Assert:
        Assert.IsTrue(personList.Zip(personList.Skip(1), (prev, next) =>
            string.Compare(prev.Address.State, next.Address.State, StringComparison.Ordinal) <= 0 &&
            (prev.Address.State != next.Address.State ||
             string.Compare(prev.Address.City, next.Address.City, StringComparison.Ordinal) <= 0) &&
            (prev.Address.State != next.Address.State ||
             prev.Address.City != next.Address.City ||
             string.Compare(prev.Address.Zip, next.Address.Zip, StringComparison.Ordinal) <= 0))
        .All(result => result)
        );
    }

    IPerson CreatePerson(string row)
    {
        string[] columns = row.Split(',');
        IAddress address = new Address(
            columns[4],
            columns[5],
            columns[6],
            columns[7]);
        IPerson person = new Person(
            columns[1],
            columns[2],
            address,
            columns[3]);
        return person;
    }

    bool IsNonDecreasingList(IEnumerable<string> input)
    {
        return input
            .Zip(input.Skip(1), (prev, next) => string.Compare(next, prev, StringComparison.Ordinal) >= 0)
            .All(result => result);
    }
}