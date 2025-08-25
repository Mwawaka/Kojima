namespace FaceId
{
    public class FacialFeatures : IEquatable<FacialFeatures>
    {
        public string EyeColor { get; }
        public decimal PhiltrumWidth { get; }

        public FacialFeatures(string eyeColor, decimal philtrumWidth)
        {
            EyeColor = eyeColor;
            PhiltrumWidth = philtrumWidth;
        }

        public override int GetHashCode() => (EyeColor, PhiltrumWidth).GetHashCode();

        // General Equals for any object
        // Try to treat obj as FacialFeatures. If it can't, it's not equal    
        public override bool Equals(object obj) => Equals(obj as FacialFeatures);

        //Specific Equals just for FacialFeatures
        public bool Equals(FacialFeatures other)
        {
            //If other is null, then not equal
            if (other is null) return false;

            //If it's the exact same object, equal (fast check).
            if (ReferenceEquals(this, other)) return true;

            // Check if runtime types are the same
            if (GetType() != other.GetType()) return false;

            //Compare FacialFeatures Properties
            bool eyeColorsMatch = string.Equals(EyeColor, other.EyeColor, StringComparison.OrdinalIgnoreCase);
            bool philtrumWidthMatch = PhiltrumWidth == other.PhiltrumWidth;

            return eyeColorsMatch && philtrumWidthMatch;
        }

    }

    public class Identity : IEquatable<Identity>
    {
        public string Email { get; }
        public FacialFeatures FacialFeatures { get; }

        public Identity(string email, FacialFeatures facialFeatures)
        {
            Email = email;
            FacialFeatures = facialFeatures;
        }
        public override int GetHashCode() => (Email, FacialFeatures).GetHashCode();
        public override bool Equals(object obj) => Equals(obj as Identity);
        public bool Equals(Identity other)
        {

            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            bool emailsMatch = string.Equals(Email, other.Email, StringComparison.OrdinalIgnoreCase);
            bool facialFeaturesMatch = FacialFeatures.Equals(other.FacialFeatures);

            return emailsMatch && facialFeaturesMatch;

        }

    }

    public class Authenticator
    {
        private static readonly Identity _admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
        private readonly HashSet<Identity> _registeredIdentities = new HashSet<Identity>();

        public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);
        public bool IsAdmin(Identity identity) => identity.Equals(_admin);
        public bool Register(Identity identity) => _registeredIdentities.Add(identity);
        public bool IsRegistered(Identity identity) => _registeredIdentities.Contains(identity);

        public static bool AreSameObject(Identity identityA, Identity identityB) => ReferenceEquals(identityA, identityB);

    }

    /* Notes
    - The Admin field is declared as static because it represents a single, shared, constant administrator identity that should be the same across all instances of the Authenticator.

    Making it static ensures it's tied to the type itself rather than individual objects.
    */
}