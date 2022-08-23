namespace Controller.Api.ServiceInterface.Contracts;

public record User(string Id, string FirstName, string Surname) : ContractBase(Id);