namespace Logger;

public abstract record class BaseEntity(Guid Id) : IEntity
{
    public Guid Id { get; init; } = Id;
    public abstract string Name { get; }
}