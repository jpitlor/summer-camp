namespace dev.pitlor.SummerCamp.Models;

public record ChoiceOrValue<T>(bool IsChoice, T? InternalValue = default)
{
    public static ChoiceOrValue<T> Choice() => new(true);
    public static ChoiceOrValue<T> Value(T value) => new(false, value);
}