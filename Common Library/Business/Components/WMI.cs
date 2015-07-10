using Common_Library.Data.Access.WMI;
using System;
using System.Collections.Generic;
using System.Management;
using KeyValueList = System.Collections.Generic.Dictionary<string, string>;

namespace Common_Library.Business.Components
{
    class WMI
    {
        WQL wql = new WQL();
        Classes classes = new Classes();

        public WMI() { }

        public WMI(string Computername) {
            wql.SetRemoteComputer(Computername);
        }

        public WMI(string Computername, string Username, string Password)
        {
            wql.SetRemoteComputer(Computername);
            wql.SetCredentials(Username, Password);
        }

        public IEnumerable<KeyValueList> GetWQLResults(string WQLQuery)
        {
            foreach (var result in wql.ExecuteQuery(WQLQuery))
                yield return convertToDictionary(result);
        }


        public IEnumerable<string> GetWMIClasses()
        {
            return classes.GetClasses();
        }

        private string convertToString(object Property)
        {
            if (Property == null)
                return string.Empty;
            else if (Property.GetType().IsArray)
                return convertArrayToString(Property as object[]);
            else
                return Property.ToString();
        }

        private string convertArrayToString(object[] array)
        {
            if (array != null)
                return string.Format("[{0}]", string.Join(", ", array));
            else
                return "[]";
        }

        private KeyValueList convertToDictionary(PropertyDataCollection properties)
        {
            KeyValueList results = new KeyValueList();

            foreach (var property in properties)
                results.Add(property.Name, convertToString(property.Value));

            return results;
        }
    }
}
