﻿namespace DinnerDDD.Contracts.Authentication;

public record SignInRequest(
    string Email,
    string Password);