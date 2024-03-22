namespace Brimborium.TheMeaningOfLiff;

public record class Meaning(
    int MessageId,
    string Message
    );

// TODO: WEICHEI
//public interface IWithMeaning<T> : IWithMeaning {
//    T Value { get; }
//    // string? Meaning { get; }
//}

//public record class PropertyMeaning<T>(
//    T Value,
//    string? Meaning
//    ) : IWithMeaning;

//public record struct ValueMeaning<T>(
//    T Value,
//    string? Meaning 
//    ): IWithMeaning;