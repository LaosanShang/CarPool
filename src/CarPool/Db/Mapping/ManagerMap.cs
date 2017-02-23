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
    public class ManagerMap : BaseEntityTypeConfiguration<Manager>
    {
        public ManagerMap()
        {
            ToTable("Managers");
            this.Property(x => x.UserName)
                .HasMaxLength(50)
                .IsRequired();
            this.Property(x => x.Password)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}