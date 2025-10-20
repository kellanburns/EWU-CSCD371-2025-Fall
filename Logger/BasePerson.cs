namespace Logger;

public abstract record BasePerson(Guid Id, FullName fullName) : BaseEntity(Id)
{
    public override string Name =>
        string.IsNullOrWhiteSpace(fullName.ToString()) ? string.Empty : fullName.ToString();
}