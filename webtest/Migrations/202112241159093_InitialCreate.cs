namespace webtest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "nguyengc0801.Account",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "nguyengc0801.Categories",
                c => new
                    {
                        cat_id = c.Int(nullable: false),
                        cat_name = c.String(nullable: false, maxLength: 50),
                        descriptions = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.cat_id);
            
            CreateTable(
                "nguyengc0801.Courses",
                c => new
                    {
                        course_id = c.Int(nullable: false),
                        course_name = c.String(nullable: false, maxLength: 1),
                        course_toeic = c.String(),
                        cat_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.course_id)
                .ForeignKey("nguyengc0801.Categories", t => t.cat_id)
                .Index(t => t.cat_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("nguyengc0801.Courses", "cat_id", "nguyengc0801.Categories");
            DropIndex("nguyengc0801.Courses", new[] { "cat_id" });
            DropTable("nguyengc0801.Courses");
            DropTable("nguyengc0801.Categories");
            DropTable("nguyengc0801.Account");
        }
    }
}
