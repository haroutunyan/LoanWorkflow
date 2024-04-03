using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.PersonalInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class PersonalInfoBaseConfiguration : IEntityTypeConfiguration<PersonalInfoBase>
    {
        public void Configure(EntityTypeBuilder<PersonalInfoBase> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type)
                .HasConversion(x => x.ToString(), m => (PersonalInfoType)Enum.Parse(typeof(PersonalInfoType), m))
                .IsRequired();
        }
    }
}
