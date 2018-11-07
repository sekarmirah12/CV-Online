namespace CvOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Job_Detail", "Villages_Id", c => c.Int());
            CreateIndex("dbo.Job_Detail", "Villages_Id");
            AddForeignKey("dbo.Job_Detail", "Villages_Id", "dbo.Villages", "Id");
            DropColumn("dbo.Job_Detail", "Provinces");
            DropColumn("dbo.Job_Detail", "Regencies");
            DropColumn("dbo.Job_Detail", "Districts");
            DropColumn("dbo.Job_Detail", "Villages");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Job_Detail", "Villages", c => c.String());
            AddColumn("dbo.Job_Detail", "Districts", c => c.String());
            AddColumn("dbo.Job_Detail", "Regencies", c => c.String());
            AddColumn("dbo.Job_Detail", "Provinces", c => c.String());
            DropForeignKey("dbo.Job_Detail", "Villages_Id", "dbo.Villages");
            DropIndex("dbo.Job_Detail", new[] { "Villages_Id" });
            DropColumn("dbo.Job_Detail", "Villages_Id");
        }
    }
}
