using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Api.DatabaseMappings.Entities;

namespace WebApp.Api.DatabaseMappings.Configurations
{
    public class DataConfiguration: IEntityTypeConfiguration<Data>
    {
        public void Configure(EntityTypeBuilder<Data> builder)
        {
            builder.ToTable("Data");
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.UserName).HasColumnName("UserName");
        }
    }
    
}