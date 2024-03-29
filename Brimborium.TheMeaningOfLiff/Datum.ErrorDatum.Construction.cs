namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {
// generated 4 Construction

    public static ErrorDatum AsErrorDatum(
        this System.Exception Exception,
        System.Runtime.ExceptionServices.ExceptionDispatchInfo? ExceptionDispatchInfo = default,
        Brimborium.TheMeaningOfLiff.Meaning? Meaning = default,
        System.Int64 LogicalTimestamp = default,
        System.Boolean IsLogged = default
    ) {
        return new ErrorDatum(Exception, ExceptionDispatchInfo, Meaning, LogicalTimestamp, IsLogged);
    }
}

// generated 4
