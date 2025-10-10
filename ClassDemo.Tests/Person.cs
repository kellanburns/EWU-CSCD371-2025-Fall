namespace ClassDemo;

public class Person
{
    string _lastName = "Montoya";
    private string _firstName;

    public string FirstName
    {
        get => _firstName!;
        set
        {
            _firstName = value.ToLower() ?? throw new ArgumentException(nameof(value));
        }
    }
    public string LastName { get; set; }

    public string GetFullName() => $"{FirstName} {LastName}";

    public Person(string firstName)
    {
        ArgumentException.ThrowIfNullOrEmpty(firstName);
        FirstName = firstName;
    }


    public void ChangeName(string newFirstName)
    {
        FirstName = newFirstName;
    }
}






public class Employee
{
}
