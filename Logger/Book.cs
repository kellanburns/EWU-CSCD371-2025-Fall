namespace Logger;

public record Book(Guid Id, string name): BaseEntity(Id)
{
    public override string Name =>
        string.IsNullOrWhiteSpace(name) ? string.Empty : name;
}