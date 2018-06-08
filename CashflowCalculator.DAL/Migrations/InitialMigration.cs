namespace CashflowCalculator.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loans",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Term = c.Int(nullable: false),
                    Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Loans");
        }
    }
}
