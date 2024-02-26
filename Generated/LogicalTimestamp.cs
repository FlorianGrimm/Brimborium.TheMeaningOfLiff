namespace Brimborium.TheMeaningOfLiff;

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(ToString)}(),nq}}")]
public readonly struct NamedLogicalTimestamp :
    IEquatable<NamedLogicalTimestamp>,
    IComparable<NamedLogicalTimestamp> {
    public readonly long Ticks;

    public NamedLogicalTimestamp(long value, string? name = default) {
        this.Ticks = value;
        this.Name = name;
    }

    public long Value => this.Ticks;

    public string? Name { get; }

    public override int GetHashCode() => this.Ticks.GetHashCode();

    public override bool Equals([AllowNull] object obj)
        => (obj is NamedLogicalTimestamp logicalTimestamp)
        ? (this.Ticks == logicalTimestamp.Ticks)
        : false;

    public bool Equals(NamedLogicalTimestamp other)
        => (this.Ticks == other.Ticks);

    public int CompareTo(NamedLogicalTimestamp other)
        => this.Ticks.CompareTo(other.Ticks);

    public override string ToString() => this.Ticks.ToString();

    public static NamedLogicalTimestamp operator +(NamedLogicalTimestamp that)
        => new NamedLogicalTimestamp(that.Ticks, that.Name);

    public static NamedLogicalTimestamp operator +(NamedLogicalTimestamp a, NamedLogicalTimestamp b)
        => (a.Value >= b.Value)
            ? a
            : b;

    public static NamedLogicalTimestamp operator *(NamedLogicalTimestamp a, NamedLogicalTimestamp b)
        => (a.Value >= b.Value)
            ? new NamedLogicalTimestamp(a.Ticks + 1, a.Name ?? b.Name)
            : new NamedLogicalTimestamp(b.Ticks + 1, b.Name ?? a.Name);

    public static bool operator ==(NamedLogicalTimestamp left, NamedLogicalTimestamp right) => left.Equals(right);

    public static bool operator !=(NamedLogicalTimestamp left, NamedLogicalTimestamp right) => !(left == right);

    public static bool operator <(NamedLogicalTimestamp left, NamedLogicalTimestamp right) => left.CompareTo(right) < 0;

    public static bool operator <=(NamedLogicalTimestamp left, NamedLogicalTimestamp right) => left.CompareTo(right) <= 0;

    public static bool operator >(NamedLogicalTimestamp left, NamedLogicalTimestamp right) => left.CompareTo(right) > 0;

    public static bool operator >=(NamedLogicalTimestamp left, NamedLogicalTimestamp right) => left.CompareTo(right) >= 0;

    public static NamedLogicalTimestamp operator ++(NamedLogicalTimestamp that) => new NamedLogicalTimestamp(that.Ticks + 1, that.Name);
}

public static class LogicalTimestampUtility { 
    [System.Runtime.CompilerServices.MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long Next(long thatLogicalTimestamp, long argLogicalTimestamp)
        => (argLogicalTimestamp == 0) ? thatLogicalTimestamp : argLogicalTimestamp;
}