using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Client.Services
{

    /// <summary>
    /// This represents a "singelton" class to store the usercontent in it. 
    /// needs to be filled to work properly
    /// I dnot know yet, why the singelton concept doesnt work here,
    /// stay tuned to find out!
    /// </summary>
    public class BiscuitService
    {
        UserDefinitionBackendService UserDefinitionBackendService { get; set; }

        public BiscuitService(UserDefinitionBackendService userDefinitionBackendService)
        {
            this.UserDefinitionBackendService = userDefinitionBackendService;
        }

        public  UserDefinitionDto User { get; set; }  //<-- This forbis a reload of the page, soon or sooner we have to adjust it

    }
}
