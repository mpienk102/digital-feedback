﻿using DotNetBoilerplate.Shared.Abstractions.Commands;
using static DotNetBoilerplate.Core.Projects.Project;

namespace DotNetBoilerplate.Application.Projects.Update;

public sealed record UpdateProjectStatusCommand(Guid Id, ProjectStatus Status) : ICommand;