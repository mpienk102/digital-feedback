﻿namespace DotNetBoilerplate.Api;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}