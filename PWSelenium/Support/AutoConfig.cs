using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescribeWellness.Support
{
    public static class AutoConfig
    {
        //Urls
        public static string PWBusinessPage => ConfigurationManager.AppSettings["PWBusinessPage"];

        public static string PWContactPage => ConfigurationManager.AppSettings["PWContactPage"];

        public static string webdev => ConfigurationManager.AppSettings["webdev"];

        public static string staging => ConfigurationManager.AppSettings["staging"];

        public static string prod => ConfigurationManager.AppSettings["prod"];


        
    }
}
