﻿using DinnerDDD.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace DinnerDDD.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;