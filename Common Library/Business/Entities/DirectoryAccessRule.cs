using System;

namespace Common_Library.Business.Entities
{
    public enum Access { Allow, Deny };

    public class DirectoryAccessRule
    {

        public Access   Access      { get; set; }
        public string   Right       { get; set; }
        public string   UserName    { get; set; }
        public string   SAM         { get; set; }
        public bool     Enabled     { get; set; }
        public DateTime LastLogon   { get; set; }
    }
}