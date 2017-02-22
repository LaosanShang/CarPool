using CarPool.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPool.Db.Mapping
{
    /// <summary>
    /// 消息映射
    /// </summary>
    public class MessageMap : BaseEntityTypeConfiguration<Message>
    {
        public MessageMap()
        {
            ToTable("Messages");

            this.Property(x => x.StartName)
                .HasMaxLength(50)
                .IsRequired();
            this.Property(x => x.EndName)
                .HasMaxLength(50)
                .IsRequired();
            this.Property(x => x.Phone).HasMaxLength(50).IsRequired();
        }
    }
}