using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo2 {

  class Program {
        
     
        static void Main(string[] args) {

     
      string newId;
    
   

     
      using (var context = new orderContext()) {
        var post = new orderdetails() { ordernumber= "001",
          buyname = "table", cost = "1.12"
        };
        context.Entry(post).State = EntityState.Added;
        context.SaveChanges();
        newId =post.ordernumber;
      }

      using (var context = new orderContext()) {
        var blog = context.ordertable
            .SingleOrDefault(b => b.ordernumber == newId);
        if(blog!=null) 
                    Console.WriteLine(blog.buyname);
                Console.WriteLine(blog.cost);
            }


     

      
  


     
      using (var context = new orderContext()) {
        var post = context.ordertable.FirstOrDefault(p => p.ordernumber == newId);
        if (post != null) {
          post.buyname = "table";
          post.cost = "9.98";
          context.SaveChanges();
        }
      }


    
      using (var context = new orderContext()) {
        var post = context.ordertable.FirstOrDefault(p => p.ordernumber == newId);
        if (post != null) {
          context.ordertable.Remove(post);
          context.SaveChanges();
        }
      }

     


     

    }
  }



}
