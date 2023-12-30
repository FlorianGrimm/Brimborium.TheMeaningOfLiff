namespace Brimborium.TheMeaningOfLiff;

public record class Meaning(
    string Context,
    string Name
    );


public class MeaningPool {
    private static MeaningPool? _Instance;
    public static MeaningPool Instance => _Instance ??= new MeaningPool();

    public static Meaning Get(string context, string name) => Instance.GetMeaning(context, name);

    private static Meaning? _Empty;

    public static Meaning Empty => _Empty ??= Get(string.Empty, string.Empty);

    private ImmutableDictionary<string, ImmutableDictionary<string, Meaning>> _Meaning = ImmutableDictionary<string, ImmutableDictionary<string, Meaning>>.Empty;

    public MeaningPool() {
    }

    public Meaning GetMeaning(string context, string name) {
        {
            var oldMeaning = this._Meaning;
            if (TryGet(oldMeaning, context, name, out var result)) {
                return result;
            }

            lock (this) {
                if (!ReferenceEquals(oldMeaning, this._Meaning)) {
                    if (TryGet(oldMeaning, context, name, out result)) {
                        return result;
                    }
                }
                result = new Meaning(context, name);
                var nextMeaning = Add(this._Meaning, context, name, result);
                System.Threading.Interlocked.MemoryBarrier();
                this._Meaning = nextMeaning;
            }
            return result;
        }

        static bool TryGet(
            ImmutableDictionary<string, ImmutableDictionary<string, Meaning>> dict,
            string context, string name,
            [MaybeNullWhen(false)] out Meaning result) {
            if (dict.TryGetValue(context, out var meaningReadContext)) {
                if (meaningReadContext.TryGetValue(name, out result)) {
                    return true;
                }
            }
            result = default;
            return false;
        }

        static ImmutableDictionary<string, ImmutableDictionary<string, Meaning>> Add(
            ImmutableDictionary<string, ImmutableDictionary<string, Meaning>> dict,
            string context, string name,
            Meaning value) {
            if (!dict.TryGetValue(context, out var dictContext)) {
                return dict.Add(context, ImmutableDictionary<string, Meaning>.Empty.Add(name, value));
            } else {
                return dict.SetItem(context, dictContext.Add(name, value));
            }
        }
    }
}
