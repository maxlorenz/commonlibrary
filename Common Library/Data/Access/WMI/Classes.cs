using System.Collections.Generic;
using System.Management;

namespace Common_Library.Data.Access.WMI
{
    class Classes
    {
        public IEnumerable<string> GetClasses()
        {
            var scope = @"root\cimv2";
            var options = new EnumerationOptions() { ReturnImmediately = true, Rewindable = false };
            var searcher = new ManagementObjectSearcher(scope, "SELECT * FROM meta_class", options);

            foreach (var wmiClass in searcher.Get())
                yield return wmiClass["__Class"].ToString();
        }
    }
}
