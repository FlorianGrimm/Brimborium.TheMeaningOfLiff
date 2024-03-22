namespace Brimborium.TheMeaningOfLiff;

public record class Meaning(
    EventId EventId,
    string Message
    );

// TODO: WEICHEI
//public interface IWithMeaning<T> : IWithMeaning {
//    T Value { get; }
//    // Brimborium.TheMeaningOfLiff.Meaning? Meaning { get; }
//}

//public record class PropertyMeaning<T>(
//    T Value,
//    Brimborium.TheMeaningOfLiff.Meaning? Meaning
//    ) : IWithMeaning;

//public record struct ValueMeaning<T>(
//    T Value,
//    Brimborium.TheMeaningOfLiff.Meaning? Meaning 
//    ): IWithMeaning;