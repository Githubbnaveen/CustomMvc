using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc
{
    public static class DynamicModule
    {

        public static string getVal(object item,string MemberName)
        {
            System.Reflection.PropertyInfo pi = item.GetType().GetProperty(MemberName);
            if (pi != null)
            {
                string value = (string)(pi.GetValue(item, null));
                return value;
            }
            else
            {
                return "";
            }
            

        }
    }

    
}