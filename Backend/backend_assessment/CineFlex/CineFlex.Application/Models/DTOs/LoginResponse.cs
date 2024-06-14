namespace CineFlex.Application.Models.DTOs;

public sealed record LoginResponse(bool Success, string Message, string? AccessToken,
    bool PasswordChanged);