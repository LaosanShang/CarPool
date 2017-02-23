namespace CarPool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _addPublishTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "PublishTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "PublishTime");
        }
    }
}
