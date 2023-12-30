namespace Brimborium.TheMeaningOfLiff;

[DebuggerDisplay($"{{{nameof(ToString)}(),nq}}")]
public readonly struct LogicalTimestamp :
    IEquatable<LogicalTimestamp>,
    IComparable<LogicalTimestamp> {
    public readonly long Ticks;

    public LogicalTimestamp(long value, string? name = default) {
        this.Ticks = value;
        this.Name = name;
    }

    public long Value => this.Ticks;

    public string? Name { get; }

    public override int GetHashCode() => this.Ticks.GetHashCode();

    public override bool Equals([AllowNull] object obj)
        => (obj is LogicalTimestamp logicalTimestamp)
        ? (this.Ticks == logicalTimestamp.Ticks)
        : false;

    public bool Equals(LogicalTimestamp other)
        => (this.Ticks == other.Ticks);

    public int CompareTo(LogicalTimestamp other)
        => this.Ticks.CompareTo(other.Ticks);

    public override string ToString() => this.Ticks.ToString();

    public static LogicalTimestamp operator +(LogicalTimestamp that)
        => new LogicalTimestamp(that.Ticks, that.Name);

    public static LogicalTimestamp operator +(LogicalTimestamp a, LogicalTimestamp b)
        => (a.Value >= b.Value)
            ? a
            : b;

    public static LogicalTimestamp operator *(LogicalTimestamp a, LogicalTimestamp b)
        => (a.Value >= b.Value)
            ? new LogicalTimestamp(a.Ticks + 1, a.Name ?? b.Name)
            : new LogicalTimestamp(b.Ticks + 1, b.Name ?? a.Name);

    public static bool operator ==(LogicalTimestamp left, LogicalTimestamp right) => left.Equals(right);

    public static bool operator !=(LogicalTimestamp left, LogicalTimestamp right) => !(left == right);

    public static bool operator <(LogicalTimestamp left, LogicalTimestamp right) => left.CompareTo(right) < 0;

    public static bool operator <=(LogicalTimestamp left, LogicalTimestamp right) => left.CompareTo(right) <= 0;

    public static bool operator >(LogicalTimestamp left, LogicalTimestamp right) => left.CompareTo(right) > 0;

    public static bool operator >=(LogicalTimestamp left, LogicalTimestamp right) => left.CompareTo(right) >= 0;

    public static LogicalTimestamp operator ++(LogicalTimestamp that) => new LogicalTimestamp(that.Ticks + 1, that.Name);
}
