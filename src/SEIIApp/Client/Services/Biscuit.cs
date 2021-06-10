using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Client.Services
{

    /// <summary>
    /// This represents a "singelton" class to store the usercontent in it. 
    /// needs to be filled to work properly.
    /// </summary>
    // IMPORTANT: Pls use the BiscuitService instead of this class!!!
    public sealed class Biscuit
    {
        private static readonly Biscuit instance = new Biscuit();

        public static UserDefinitionDto User { get; set; }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Biscuit()
        {
        }

        private Biscuit()
        {
        }

        public static Biscuit Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
