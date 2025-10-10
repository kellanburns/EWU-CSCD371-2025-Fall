namespace ClassDemo.Tests;

public class PersonTests
{
    [Fact]
    public void Test1()
    {

        Person person2 = new("Inigo")
        {
            LastName = "Montoya",
            FirstName = "Tom"
        };

    }
}
