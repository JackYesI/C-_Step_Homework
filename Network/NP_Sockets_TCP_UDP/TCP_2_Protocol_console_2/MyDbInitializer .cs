using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_2_Protocol_console_SERVER
{
    public class MyDbInitializer : DropCreateDatabaseIfModelChanges<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            context.Regions.Add(new Region { Code = 1, Area = "Kyiv" });
            context.Regions.Add(new Region { Code = 2, Area = "Lviv" });
            context.Regions.Add(new Region { Code = 3, Area = "Odessa" });
            context.Regions.Add(new Region { Code = 4, Area = "Ternopil" });
            context.Regions.Add(new Region { Code = 5, Area = "Rivne" });
            context.Regions.Add(new Region { Code = 6, Area = "Vinytsa" });

            base.Seed(context);
        }
    }
}
