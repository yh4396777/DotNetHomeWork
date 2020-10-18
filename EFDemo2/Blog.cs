using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo2 {
    public class orderdetails
    {
        [Key, Column(Order = 1)]
        public string ordernumber { get; set; }
        public string buyname { get; set; }

        public string cost { get; set; }

        public orderdetails()
        { }
        public orderdetails(string v1, string v2, string v3)
        {
            this.ordernumber = v1;
            this.buyname = v2;
            this.cost = v3;
        }

        public override bool Equals(object obj)
        {
            orderdetails a = obj as orderdetails;
            return a != null && a.ordernumber == ordernumber && a.buyname == buyname && a.cost == cost;
        }

    }


    public class order
    {
        public string myname = "yh";

        public List<orderdetails> details = new List<orderdetails>();
        







    }

  }


