using System;

namespace Common_Library.Business.Entities
{
    public class Software : IComparable
    {
        public string Name { get; set; }
        public string Version { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Software otherSoftware = obj as Software;
            return this.Name.CompareTo(otherSoftware.Name);
        }
    }
}
