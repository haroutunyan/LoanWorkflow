using LoanWorkflow.DAL.Entities.PersonalInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Configurations
{
    public class ApplicantPersonalInfoConfiguration : IEntityTypeConfiguration<ApplicantPersonalInfo>
    {
        public void Configure(EntityTypeBuilder<ApplicantPersonalInfo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.PersonalInfo)
                .WithMany(x => x.ApplicantPersonalInfos)
                .HasForeignKey(x => x.PersonalInfoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Applicant)
                .WithMany(x => x.ApplicantPersonalInfos)
                .HasForeignKey(x => x.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
