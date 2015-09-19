using Microsoft.Win32;

namespace SMITEAPI_DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class SMITEAPIModel : DbContext
    {
        // Your context has been configured to use a 'SMITEAPIModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SMITEAPI_DAL.SMITEAPIModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SMITEAPIModel' 
        // connection string in the application configuration file.
        public SMITEAPIModel()
            : base("name=SMITEAPIModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        public DbSet<APISession> Sessions { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class APISession
    {
        public string ret_msg { get; set; }
        [Key]
        public string session_id { get; set; }
        public DateTime timestamp { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}