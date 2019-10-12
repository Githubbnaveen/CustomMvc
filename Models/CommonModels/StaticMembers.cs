using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Models.CommonModels
{
    public static class StaticMembers
    {
        public static readonly string FormTablePrefix = System.Configuration.ConfigurationManager.AppSettings["TablePrefix"];
        public static readonly string SharedFolderName = System.Configuration.ConfigurationManager.AppSettings["SharedFolderName"];
    }
}