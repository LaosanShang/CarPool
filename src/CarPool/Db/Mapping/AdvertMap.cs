using CarPool.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPool.Db.Mapping
{
    /// <summary>
    /// 广告
    /// </summary>
    public class AdvertMap : BaseEntityTypeConfiguration<Advert>
    {
        public AdvertMap()
        {
            ToTable("Adverts");

            this.Property(x => x.Title)
                .HasMaxLength(50)
                .IsRequired();
            this.Property(x => x.ImageUrl)
                .HasMaxLength(100)
                .IsRequired();
            this.Property(x => x.Description).HasMaxLength(500);
        }
    }
}