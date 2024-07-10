﻿namespace DotNetBoilerplate.Shared.Abstractions.Contexts;

public interface IIdentityContext
{
    bool IsAuthenticated { get; }
    public Guid Id { get; }
    string Role { get; }
}