namespace AgilePoker.Shared;

public record class UserOptions
{
    public string? Name { get; init; }
    public Role? Role { get; init; }
}
