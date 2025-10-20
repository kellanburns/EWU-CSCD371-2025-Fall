namespace Logger;

public record Book (Guid Id, string Title, string? Author): BaseEntity(Id)
{
    public override string Name =>
        string.IsNullOrWhiteSpace(Author) ? Title : $"{Title} by {Author}";
}