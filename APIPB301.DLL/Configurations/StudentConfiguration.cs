using APIPB301.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPB301.DLL.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(g => g.Name).IsRequired(true).HasMaxLength(20);
            builder
                .HasOne(s=>s.Groups)
                .WithMany(g=>g.Students)
                .HasForeignKey(s=>s.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(g => g.CreatedDate).IsRequired(true).HasDefaultValueSql("getdate()");
            builder.Property(g => g.UpdateDate).IsRequired(true).HasDefaultValueSql("getdate()");
        }
    }
}
