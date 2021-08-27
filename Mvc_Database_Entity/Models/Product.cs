using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Entity Framewrok
//Scheme for Strcuturing Table and DataAnnotations are for configuring Attributes
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Mvc_Database_Entity.Models
{
    //Attribute Table shoud map with table name
    [Table("tblProducts")]
    public class Product
    {
        //Define Properties to Define table fields
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        //Converting Price into Nullable as per Table Required
    }
}