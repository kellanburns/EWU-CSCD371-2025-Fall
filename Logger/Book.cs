namespace Logger;

public record Book(Guid Id, string inputName): BaseEntity(Id)
{
    public override string Name =>
        string.IsNullOrWhiteSpace(inputName) ? string.Empty : inputName;
}