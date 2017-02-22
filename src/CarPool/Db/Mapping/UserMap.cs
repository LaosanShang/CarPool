using CarPool.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPool.Db.Mapping
{
    /// <summary>
    /// 用户映射
    /// </summary>
    public class UserMap : BaseEntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");

            this.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            this.Property(x => x.Sex)
                .HasMaxLength(50)
                .IsRequired();
            this.Property(x => x.Phone).HasMaxLength(50).IsRequired();
        }
    }
}