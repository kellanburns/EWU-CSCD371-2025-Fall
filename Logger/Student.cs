namespace Logger;

public record Student(Guid Id, FullName fullName) : BasePerson(Id, fullName);