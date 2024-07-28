using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_2_Protocol_console_SERVER
{
    public class MyDbContext: DbContext
    {
        public MyDbContext() : base("name=MyDbConnectionString")
        {
        }

        public DbSet<Region> Regions { get; set; }
        static MyDbContext()
        {
            Database.SetInitializer(new MyDbInitializer());
        }
        public string GetAreaByCode(string code)
        {
            int Code = Convert.ToInt32(code);
            var region = Regions.SingleOrDefault(r => r.Code == Code);
            return region?.Area ?? "Region not found";
        }
        public string GetCodeByArea(string area)
        {
            var region = Regions.SingleOrDefault(r => r.Area == area);
            return Convert.ToString(region?.Code) ?? "Code not found";
        }

    }
}
