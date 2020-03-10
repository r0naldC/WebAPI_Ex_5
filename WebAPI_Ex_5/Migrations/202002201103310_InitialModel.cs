namespace WebAPI_Ex_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.TaskTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Tasks",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Complete = c.Boolean(nullable: false),
                    CreateDate = c.DateTime(nullable: false),
                    ModifiedDate = c.DateTime(nullable: false),
                    Type_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaskTypes", t => t.Type_Id)
                .Index(t => t.Type_Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Type_Id", "dbo.TaskTypes");
            DropIndex("dbo.Tasks", new[] { "Type_Id" });
            DropTable("dbo.TaskTypes");
            DropTable("dbo.Tasks");
        }
    }
}
