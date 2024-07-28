using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Web
    {
        private string name;
        private string url;
        private string description;
        static private int IP = 0;
        private int ip_real;
        public Web() { 
            name = string.Empty;
            url = string.Empty;
            description = string.Empty;
            IP++;
            ip_real = IP;
        }
        public Web(string name, string url, string description)
        {
            this.name = name;
            this.url = url;
            this.description = description;
            IP++;
            ip_real = IP;
        }
        public string Name { get { return name; } set { name = value; } }
        public string Url { get { return url; } set { url = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int ip_static { get { return IP; } }
        public override string ToString()
        {
            return $"IP : {ip_real}\nWeb title {Name}\nPath : {url}\nDescription {description}\n";
        }
    }
}
