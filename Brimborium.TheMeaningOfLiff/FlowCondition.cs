
namespace Brimborium.TheMeaningOfLiff;
public readonly record struct FlowCondition(
        Datum<bool> Condition,
        string Description
    ) {
    public static implicit operator bool(FlowCondition flowCondition) => flowCondition.Condition;
    public static implicit operator FlowCondition(Datum<bool> condition) => new FlowCondition(condition, string.Empty);
    public static implicit operator FlowCondition(bool condition) => new FlowCondition(new Datum<bool>(condition), string.Empty);
}

public interface IFlowDecision<T> {
    FlowCondition Decision(
        T value,
        T comparative
        , string description);
}