using MediatR;
using Banking.Application.Interfaces;
using System.Net;

namespace Banking.Application.Features.Accounts.Commands.CreateAccount;

public record CreateAccountCommand(string Owner, decimal InitialAmount, string Currency) : IRequest<Guid>;

