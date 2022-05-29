using ESOC.CLTPull.Assessment.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESOC.CLTPull.Assessment.Infrastructure.Data.Data.Configuration
{
    public class RequestInteractionHistoryConfiguration : IEntityTypeConfiguration<RequestInteractionHistory>
    {
        public void Configure(EntityTypeBuilder<RequestInteractionHistory> builder)
        {
            builder.HasKey(e => e.RequestInteractionHistoryId)
                .IsClustered(false);

            builder.ToTable("RequestInteractionHistory", "dbo");

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

            builder.Property(e => e.InteractionAction).IsUnicode(false);

            builder.Property(e => e.InteractionDescription)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.InteractionFailureModes).IsUnicode(false);

            builder.Property(e => e.IsDataSentOnUsaholidays).HasColumnName("IsDataSentOnUSAHolidays");

            builder.Property(e => e.LastAccessedDate).HasColumnType("datetime");

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

        }
    }
}
