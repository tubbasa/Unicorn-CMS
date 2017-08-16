namespace HaberSis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Olustur1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kategori", "Kullanici_ID", "dbo.Kullanici");
            DropIndex("dbo.Kategori", new[] { "Kullanici_ID" });
            DropColumn("dbo.Kategori", "Kullanici_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kategori", "Kullanici_ID", c => c.Int());
            CreateIndex("dbo.Kategori", "Kullanici_ID");
            AddForeignKey("dbo.Kategori", "Kullanici_ID", "dbo.Kullanici", "ID");
        }
    }
}
