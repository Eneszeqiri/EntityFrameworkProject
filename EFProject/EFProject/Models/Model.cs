using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EFProject.Models
{
    public class Model : DbContext
    {
        // Your context has been configured to use a 'Model' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EFProject.Models.Model' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model' 
        // connection string in the application configuration file.
        public Model()
            : base("name=Model")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<RegionClass> Regions { get; set; }
        public virtual DbSet<MunicipalityClass> Municipalities { get; set; }
        public virtual DbSet<SettlementClass> Settlements { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
    public class MunicipalityClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string MunicipalityName { get;  set; }

        [ForeignKey("RegionClass")]
        public int RegionClass_Id { get; set; }

        public virtual RegionClass RegionClass { get; set; }
    }

    public class SettlementClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        
        public int Id { get; set; }
        public string SettlementName { get; set; }

        [ForeignKey("MunicipalityClass")]
        public int Municipality_Id { get; set; }

        public MunicipalityClass MunicipalityClass { get; set; }
    }

    
    public class RegionClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        [Index(nameof(RegionName), IsUnique = true)]
        public string RegionName { get; set; }

    }






    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}