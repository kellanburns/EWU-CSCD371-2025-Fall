namespace Logger;

public abstract record BasePerson(Guid Id, FullName fullName) : BaseEntity(Id)
{
    // Name is implemented implicitly because name should be an obvious functionality of base person
    // Though Id is not being directly implemented in this class, it is using BaseEntities implicit implementation
    public override string Name =>
        string.IsNullOrWhiteSpace(fullName.ToString()) ? string.Empty : fullName.ToString();
}