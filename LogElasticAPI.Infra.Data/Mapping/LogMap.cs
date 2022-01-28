using LogElasticAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogElasticAPI.Infra.Data.Mapping
{
    public class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            //builder.ToTable("Log");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.ApplicationName)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired();
            //.HasColumnName("Name")
            //.HasColumnType("varchar(100)");

            builder.Property(prop => prop.Message)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired();
            //.HasColumnName("Email")
            //.HasColumnType("varchar(100)");

            builder.Property(prop => prop.InnerMessage)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired();
            //.HasColumnName("Password")
            //.HasColumnType("varchar(100)");

            builder.Property(prop => prop.Stacktrace)
             .HasConversion(prop => prop.ToString(), prop => prop)
             .IsRequired();
            //.HasColumnName("Password")
            //.HasColumnType("varchar(100)");
        }
    }
}
