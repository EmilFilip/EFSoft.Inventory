global using System.Diagnostics.CodeAnalysis;
global using System.Text.Json;
global using System.Threading.Tasks;

global using EFSoft.Inventory.Application.Commands.DecreaseInventory;
global using EFSoft.Inventory.Application.Events;
global using EFSoft.Inventory.Infrastructure.Configuration;
global using EFSoft.Shared.Cqrs.Configuration;

global using MediatR;

global using Microsoft.Azure.Functions.Extensions.DependencyInjection;
global using Microsoft.Azure.WebJobs;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Logging;
