namespace Logger;

public record Employee(Guid Id, FullName fullName) : BasePerson(Id, fullName);