namespace SMITEAPI_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAPISession : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.APISessions",
                c => new
                    {
                        session_id = c.String(nullable: false, maxLength: 128),
                        ret_msg = c.String(),
                        timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.session_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.APISessions");
        }
    }
}
