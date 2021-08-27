using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//importing Entity Framework
using System.Data.Entity;
namespace Mvc_Database_Entity.Models
{
    //Db COnnect will use DbConnection class which will resposible for handling 
    //Communication with the database
    //IT Expect Connection String as Paramert input
    public class ProductsContext : DbContext
    {
        //Products Context Connect With Database after connecting with DB
        public ProductsContext()
            :base("ProductsConnection")
        { 
        }
        //To interact with DB on Particular table we have DBSet called produtsTable
        public DbSet<Product> ProductsTable { get; set;  }

        //Through this ProductsTable we can read/write data into Db Table
    }
}