namespace CvOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelsJob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Job_Detail", "districts_Id", c => c.Int());
            CreateIndex("dbo.Job_Detail", "districts_Id");
            AddForeignKey("dbo.Job_Detail", "districts_Id", "dbo.Districts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Job_Detail", "districts_Id", "dbo.Districts");
            DropIndex("dbo.Job_Detail", new[] { "districts_Id" });
            DropColumn("dbo.Job_Detail", "districts_Id");
        }
    }
}
