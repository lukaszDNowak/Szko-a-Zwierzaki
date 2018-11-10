namespace Pizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnimalGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Animals", "AnimalGroup_Id", c => c.Int());
            CreateIndex("dbo.Animals", "AnimalGroup_Id");
            AddForeignKey("dbo.Animals", "AnimalGroup_Id", "dbo.AnimalGroups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "AnimalGroup_Id", "dbo.AnimalGroups");
            DropIndex("dbo.Animals", new[] { "AnimalGroup_Id" });
            DropColumn("dbo.Animals", "AnimalGroup_Id");
            DropTable("dbo.AnimalGroups");
        }
    }
}
