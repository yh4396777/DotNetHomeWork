using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo2 {

  public class orderContext : DbContext {
    public orderContext() : base("BlogDataBase") {
      Database.SetInitializer(
        new DropCreateDatabaseIfModelChanges<orderContext>());
    }

    public DbSet<orderdetails> ordertable { get; set; }
   

  }
}
