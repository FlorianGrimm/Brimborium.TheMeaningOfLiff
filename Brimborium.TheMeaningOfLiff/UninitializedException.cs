namespace Brimborium.TheMeaningOfLiff;

[Serializable]
public sealed class UninitializedException : Exception
{
    private static UninitializedException? _Instance;
    public static UninitializedException Instance => _Instance ??= new UninitializedException();
    public UninitializedException() : base("Uninitialized") { }
    [Obsolete]
    private UninitializedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

[Serializable]
public sealed class NoValueAccessingException : Exception
{
    public NoValueAccessingException() : base("NoValueAccessing") { }
    [Obsolete]
    private NoValueAccessingException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

[Serializable]
public sealed class InvalidCaseException : Exception {
    public InvalidCaseException() : base("InvalidCase") { }
    [Obsolete]
    private InvalidCaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}