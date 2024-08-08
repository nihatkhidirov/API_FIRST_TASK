using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APIPB301.DLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = APIPB301.DLL.Entities.Group;

namespace APIPB301.DLL.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(g => g.Name).IsRequired(true).HasMaxLength(10);
            //builder.HasIndex(g => g.Name).IsUnique();
            builder.Property(g => g.Limit).IsRequired(true).HasMaxLength(10);
            builder.Property(g => g.CreatedDate).IsRequired(true).HasDefaultValueSql("getdate()");
            builder.Property(g => g.UpdateDate).IsRequired(true).HasDefaultValueSql("getdate()");


        }

    }
}
