using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ESOC.CLTPull.Assessment.Core.Entities;

namespace ESOC.CLTPull.Assessment.Infrastructure.Data.Data.Configuration
{
    public class RequestInteractionConfiguration : IEntityTypeConfiguration<RequestInteraction>
    {
        public void Configure(EntityTypeBuilder<RequestInteraction> builder)
        {
            builder.ToTable("RequestInteraction", "dbo");

            //builder.Property(e => e.CompanionFileExists)
            //    .HasMaxLength(100)
            //    .IsUnicode(false);

            builder.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.DailyIntervalDays)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.DataContentType)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.EcgconfigurationId)
                .HasColumnName("ECGConfigurationId")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ExpectedTransmissionStartTimeCst)
                .HasColumnName("ExpectedTransmissionStartTimeCST")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.InteractionDescription)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.InteractionFailureModes).IsUnicode(false);

            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            builder.Property(e => e.IsDataSentOnUsaholidays).HasColumnName("IsDataSentOnUSAHolidays");

            builder.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ModifiedDate).HasColumnType("datetime");

            builder.Property(e => e.MonthlyIntervalMonths)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.NonServiceDataDestinationName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.NonServiceDataSourceName)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.NotesOnDestinationDataArrivalAndValidation).IsUnicode(false);

            builder.Property(e => e.NotesOnDestinationDataLoadingAndFinalLocation).IsUnicode(false);

            builder.Property(e => e.NotesOnFrequency).IsUnicode(false);

            builder.Property(e => e.NotesOnObjectNaming).IsUnicode(false);

            builder.Property(e => e.NotesOnOtherControls).IsUnicode(false);

            builder.Property(e => e.NotesOnReconciliationControls).IsUnicode(false);

            builder.Property(e => e.NotesOnSourceDataCreation).IsUnicode(false);

            builder.Property(e => e.NotesOnThresholdControls).IsUnicode(false);

            builder.Property(e => e.NotesOnTimeRelatedControls).IsUnicode(false);

            builder.Property(e => e.NotesOnTrigger).IsUnicode(false);

            builder.Property(e => e.ReferralToOtherTeams).IsUnicode(false);

            builder.Property(e => e.InteractionAction).IsUnicode(false);

            builder.HasOne(d => d.DestinationService)
                    .WithMany(p => p.RequestInteraction)
                    .HasForeignKey(d => d.DestinationServiceId)
                    .HasConstraintName("FK_RequestInteraction_DestinationServiceId");

            builder.HasOne(d => d.FrequencyInterval)
                .WithMany(p => p.RequestInteraction)
                .HasForeignKey(d => d.FrequencyIntervalId)
                .HasConstraintName("FK_RequestInteraction_FrequencyIntervalId");

            builder.HasOne(d => d.HelperAppOrTeam)
                .WithMany(p => p.RequestInteraction)
                .HasForeignKey(d => d.HelperAppOrTeamId)
                .HasConstraintName("FK_RequestInteraction_HelperAppOrTeamId");

            builder.HasOne(d => d.InstancesPerFrequencyInterval)
                .WithMany(p => p.RequestInteraction)
                .HasForeignKey(d => d.InstancesPerFrequencyIntervalId)
                .HasConstraintName("FK_RequestInteraction_InstancesPerFrequencyIntervalId");

            builder.HasOne(d => d.InteractionMechanism)
                .WithMany(p => p.RequestInteraction)
                .HasForeignKey(d => d.InteractionMechanismId)
                .HasConstraintName("FK_RequestInteraction_InteractionMechanismId");

            builder.HasOne(d => d.InteractionSpan)
                .WithMany(p => p.RequestInteraction)
                .HasForeignKey(d => d.InteractionSpanId)
                .HasConstraintName("FK_RequestInteraction_InteractionSpanId");

            builder.HasOne(d => d.InteractionStatus)
                .WithMany(p => p.RequestInteraction)
                .HasForeignKey(d => d.InteractionStatusId)
                .HasConstraintName("FK_RequestInteraction_InteractionStatusId");

            builder.HasOne(d => d.InteractionTriggerType)
                .WithMany(p => p.RequestInteraction)
                .HasForeignKey(d => d.InteractionTriggerTypeId)
                .HasConstraintName("FK_RequestInteraction_InteractionTriggerTypeId");

            builder.HasOne(d => d.ObjectofInteraction)
                .WithMany(p => p.RequestInteraction)
                .HasForeignKey(d => d.ObjectofInteractionId)
                .HasConstraintName("FK_RequestInteraction_ObjectofInteractionId");

            builder.HasOne(d => d.Request)
                .WithMany(p => p.RequestInteraction)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_RequestInteraction_RequestId");

            builder.HasOne(d => d.SourceService)
                .WithMany(p => p.RequestInteraction)
                .HasForeignKey(d => d.SourceServiceId)
                .HasConstraintName("FK_RequestInteraction_SourceServiceId");

            builder.HasOne(d => d.CompanionFileType)
                .WithMany(p => p.RequestInteraction)
                .HasForeignKey(d => d.CompanionFileTypeId)
                .HasConstraintName("FK_RequestInteraction_CompanionFileTypeId");

            builder.HasOne(d => d.InteractionReviewStatus)
                   .WithMany(p => p.RequestInteraction)
                   .HasForeignKey(d => d.InteractionReviewStatusId)
                   .HasConstraintName("FK__RequestIn__Inter__511AFFBC");

            builder.HasOne(d => d.ObjectDataFormat)
                    .WithMany(p => p.RequestInteraction)
                    .HasForeignKey(d => d.ObjectDataFormatId)
                    .HasConstraintName("FK__RequestIn__Objec__5303482E");

        }
    }
}
