namespace Brimborium.TheMeaningOfLiff;

[Orleans.Alias(nameof(UninitializedException))]
[Orleans.Immutable]
[Orleans.GenerateSerializer]
[Serializable]
[DebuggerNonUserCode]
public sealed class UninitializedException : Exception
{
    private static UninitializedException? _Instance;
    public static UninitializedException Instance => _Instance ??= new UninitializedException();
    public UninitializedException() : base("Uninitialized") { }
    [Obsolete]
    private UninitializedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

[Orleans.Alias(nameof(NoValueAccessingException))]
[Orleans.Immutable]
[Orleans.GenerateSerializer]
[Serializable]
[DebuggerNonUserCode]
public sealed class NoValueAccessingException : Exception
{
    public NoValueAccessingException() : base("NoValueAccessing") { }
    [Obsolete]
    private NoValueAccessingException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

[Orleans.Alias(nameof(InvalidCaseException))]
[Orleans.Immutable]
[Orleans.GenerateSerializer]
[Serializable]
[DebuggerNonUserCode]
public sealed class InvalidCaseException : Exception {
    public InvalidCaseException() : base("InvalidCase") { }
    [Obsolete]
    private InvalidCaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

[Orleans.Alias(nameof(InvalidPreconditionException))]
[Orleans.Immutable]
[Orleans.GenerateSerializer]
[Serializable]
[DebuggerNonUserCode]
public sealed class InvalidPreconditionException : Exception {
    public InvalidPreconditionException() : base("Invalid Condition") { }
    public InvalidPreconditionException(string mesage) : base(mesage) { }

    [Obsolete]
    private InvalidPreconditionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}