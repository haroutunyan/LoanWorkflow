using LoanWorkflow.DAL.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasOne(x => x.Partner)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.PartnerId)
                .IsRequired();
        }
    }
}
