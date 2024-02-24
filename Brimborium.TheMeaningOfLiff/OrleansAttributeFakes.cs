#if !Orleans
namespace Orleans {

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    internal class ImmutableAttribute : System.Attribute { }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    internal class GenerateSerializerAttribute : System.Attribute {
        public bool IncludePrimaryConstructorParameters { get; init; }
        public GenerateFieldIds GenerateFieldIds { get; init; } = GenerateFieldIds.None;
    }
    internal enum GenerateFieldIds { None, PublicProperties }


    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class IdAttribute : System.Attribute {
        public IdAttribute(uint id) {
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    internal class AliasAttribute : System.Attribute {
        public AliasAttribute(string alias) {
        }
    }
    [AttributeUsage(AttributeTargets.Constructor)]
    internal sealed class OrleansConstructorAttribute : System.Attribute {
        public OrleansConstructorAttribute() {
        }
    }
}

namespace Brimborium.BaseMethods {
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class EquatableAttribute : System.Attribute {
        public EquatableAttribute() {
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class IgnoreEqualityAttribute : System.Attribute {
        public IgnoreEqualityAttribute() {
        }
    }
}
#endif
