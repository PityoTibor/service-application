using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    public enum RoleEnum
    {
        admin = 0, handyman = 1, costumer = 2
    }

    [Table("tbl_user")]
    public class User
    {
        [Key]
        public Guid User_id { get; set; }

        public string? Username { get; set; }
        [EmailAddress]
       
        public string? Email { get; set; }
        
        public string? Password { get; set; }
        
        public RoleEnum Role { get; set; }

        [NotMapped]
        public virtual Admin Admin { get; set; }
        [NotMapped]
        public virtual Costumer Costumer { get; set; }
        [NotMapped]
        public virtual Handyman Handyman { get; set; }

        //    [NotMapped]
        //    public Guid Admin_id { get; set; }
        //    [NotMapped]
        //    public virtual Admin Admin { get; set; }

        //    [NotMapped]
        //    public Guid Costumer_id { get; set; }
        //    [NotMapped]
        //    public virtual Costumer Costumer { get; set; }

        //    [NotMapped]
        //    public Guid Handyman_id { get; set; }
        //    [NotMapped]
        //    public virtual Handyman Handyman { get; set; }
    }
    }
