namespace NgoProjectk3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                        Role = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        FullName = c.String(),
                        Gender = c.Int(nullable: false),
                        Address = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        AccessToken = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.DonatePrograms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(),
                        Content = c.String(),
                        Amount = c.Long(nullable: false),
                        DonatedMoney = c.Long(),
                        ThumbnailUrl = c.String(),
                        Status = c.Int(nullable: false),
                        StartedAt = c.DateTime(nullable: false),
                        EndedAt = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonorId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        Amount = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        Account_Id = c.Int(),
                        DonateProgram_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.DonatePrograms", t => t.DonateProgram_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.DonateProgram_Id);
            
            CreateTable(
                "dbo.Interesteds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interesteds", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Interesteds", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Donations", "DonateProgram_Id", "dbo.DonatePrograms");
            DropForeignKey("dbo.Donations", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.DonatePrograms", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Credentials", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.Interesteds", new[] { "CategoryId" });
            DropIndex("dbo.Interesteds", new[] { "AccountId" });
            DropIndex("dbo.Donations", new[] { "DonateProgram_Id" });
            DropIndex("dbo.Donations", new[] { "Account_Id" });
            DropIndex("dbo.DonatePrograms", new[] { "CategoryId" });
            DropIndex("dbo.Credentials", new[] { "Account_Id" });
            DropTable("dbo.Interesteds");
            DropTable("dbo.Donations");
            DropTable("dbo.DonatePrograms");
            DropTable("dbo.Credentials");
            DropTable("dbo.Categories");
            DropTable("dbo.Accounts");
        }
    }
}
