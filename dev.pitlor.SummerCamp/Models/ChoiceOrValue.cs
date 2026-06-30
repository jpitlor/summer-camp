namespace dev.pitlor.SummerCamp.Models;

public record ChoiceOrValue<T>(bool IsChoice, T? InternalValue, List<T>? ValidValues)
{
    public static ChoiceOrValue<T> Choice(List<T>? validValues = null) => new(true, default, validValues);
    public static ChoiceOrValue<T> Value(T value) => new(false, value, null);
}