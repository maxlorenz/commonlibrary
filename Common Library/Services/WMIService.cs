using Common_Library.Business.Components;
using Common_Library.Data.Access.WMI;
using System.Collections.Generic;
using System.Threading.Tasks;
using KeyValuePairList = System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>>;

namespace Common_Library.Services
{
    public class WMIService
    {
        WMI wmi;
        Classes classes = new Classes();

        public WMIService()
        {
            wmi = new WMI();
        }

        public WMIService(string Computername, string Username, string Password)
        {
            wmi = new WMI(Computername, Username, Password);            
        }

        public IEnumerable<KeyValuePairList> GetWQLResults(string Query)
        {
            return wmi.GetWQLResults(Query);
        }

        public async Task<IEnumerable<KeyValuePairList>> GetWQLResultsAsync(string Query)
        {
            return await Task.Run(() => wmi.GetWQLResults(Query));
        }

        public IEnumerable<string> GetWMIClasses()
        {
            return classes.GetClasses();
        }
    }
}
