namespace dev.pitlor.SummerCamp.Models;

public record Result(bool isSuccess, string? errorMessage = null)
{
    public static Result Success() => new(true);
    public static Result Failure(string errorMessage) => new(false, errorMessage);
}