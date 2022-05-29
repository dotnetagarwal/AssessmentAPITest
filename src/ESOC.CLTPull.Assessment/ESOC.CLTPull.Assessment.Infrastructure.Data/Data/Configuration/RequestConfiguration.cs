using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ESOC.CLTPull.Assessment.Core.Entities;

namespace ESOC.CLTPull.Assessment.Infrastructure.Data.Data.Configuration
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(e => e.RequestId)
                    .HasName("PK_Request_RequestId");

            builder.ToTable("Request", "dbo");

            builder.Property(e => e.ActualFinishDate).HasColumnType("datetime");

            builder.Property(e => e.ActualStartDate).HasColumnType("datetime");

            builder.Property(e => e.CancelDate).HasColumnType("datetime");

            builder.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.CustomerInfo)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.FundingSource)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.InitialRequestDate).HasColumnType("datetime");

            builder.Property(e => e.LineOfBusinessId)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ModifiedDate).HasColumnType("datetime");

            builder.Property(e => e.Notes).IsUnicode(false);

            builder.Property(e => e.PrjidorServiceNowTicket)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PRJIDOrServiceNowTicket");

            builder.Property(e => e.Prjname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PRJName");

            builder.Property(e => e.RequestDescription)
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.RequestDocumentation)
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.RequestLead)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.RequestTitle)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.TargetFinishDate).HasColumnType("datetime");

            builder.Property(e => e.TargetStartDate).HasColumnType("datetime");

            builder.Property(e => e.AssessmentTargetFinishDate).HasColumnType("datetime");

            builder.Property(e => e.AssessmentActualFinishDate).HasColumnType("datetime");

            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            
            builder.Property(e => e.ProgramName)
               .HasMaxLength(150)
               .IsUnicode(false);

            builder.Property(e => e.ProgramManager)
              .HasMaxLength(100)
              .IsUnicode(false);

            builder.Property(e => e.EsocAnalyst)
             .HasMaxLength(100)
             .IsUnicode(false);

            builder.Property(e => e.AssessmentTc)
            .HasMaxLength(100)
            .IsUnicode(false);

            builder.Property(e => e.RequestServiceSlo)
           .HasMaxLength(100)
           .IsUnicode(false);

            //builder.HasOne(d => d.Program)
            //    .WithMany(p => p.AssesmentRequests)
            //    .HasForeignKey(d => d.ProgramId)
            //    .HasConstraintName("FK_Request_ProgramId");

            //builder.HasOne(d => d.RequestAssessment)
            //    .WithMany(p => p.AssesmentRequests)
            //    .HasForeignKey(d => d.RequestAssessmentId)
            //    .HasConstraintName("FK_Request_RequestAssessmentId");

            builder.HasOne(d => d.RequestChannel)
                .WithMany(p => p.AssesmentRequests)
                .HasForeignKey(d => d.RequestChannelId)
                .HasConstraintName("FK_Request_RequestChannelId");

            builder.HasOne(d => d.RequestService)
                .WithMany(p => p.AssesmentRequests)
                .HasForeignKey(d => d.RequestServiceId)
                .HasConstraintName("FK_Request_RequestServiceId");

            builder.HasOne(d => d.RequestState)
                .WithMany(p => p.AssesmentRequests)
                .HasForeignKey(d => d.RequestStateId)
                .HasConstraintName("FK_Request_RequestStateId");

            builder.HasOne(d => d.RequestType)
                .WithMany(p => p.AssesmentRequests)
                .HasForeignKey(d => d.RequestTypeId)
                .HasConstraintName("FK_Request_RequestId");

            builder.HasOne(d => d.AssessmentScope)
                   .WithMany(p => p.Request)
                   .HasForeignKey(d => d.AssessmentScopeId)
                   .HasConstraintName("FK_Request_AssessmentScope");

            builder.HasOne(d => d.AssessmentStatus)
                .WithMany(p => p.Request)
                .HasForeignKey(d => d.AssessmentStatusId)
                .HasConstraintName("FK_Request_AssessmentStatus");

            builder.HasOne(d => d.LineOfBusiness)
                .WithMany(p => p.Request)
                .HasForeignKey(d => d.LineOfBusinessId)
                .HasConstraintName("FK_Request_LineOfBusiness");
        }
    }
}
