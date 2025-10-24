namespace Logger;

public record Book(Guid Id, string inputName): BaseEntity(Id)
{
    // Name is implemented implicitly because name should be an obvious functionality of Book
    // Though Id is not being directly implemented in this class, it is using BaseEntities implicit implementation
    public override string Name =>
        string.IsNullOrWhiteSpace(inputName) ? string.Empty : inputName;
}