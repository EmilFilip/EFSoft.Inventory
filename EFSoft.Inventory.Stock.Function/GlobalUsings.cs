global using System;
global using System.Diagnostics.CodeAnalysis;
global using System.Text.Json;
global using System.Threading.Tasks;

global using EFSoft.Orders.Application.Commands.Parameters;
global using EFSoft.Orders.Application.Events;
global using EFSoft.Orders.Infrastructure.Configuration;
global using EFSoft.Shared.Cqrs.Command;

global using Microsoft.Azure.Functions.Extensions.DependencyInjection;
global using Microsoft.Azure.WebJobs;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Logging;
