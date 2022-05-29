using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ESOC.CLTPull.Assessment.Core.Entities;

namespace ESOC.CLTPull.Infrastructure.Data
{
    public partial class CLTPULLContext : DbContext
    {
        public CLTPULLContext()
        {
        }

        public CLTPULLContext(DbContextOptions<CLTPULLContext> options)
            : base(options)
        {
           // this.Database.SetCommandTimeout(0);
        }

        public virtual DbSet<AssessmentScope>AssessmentScope { get; set; }
        public virtual DbSet<AssessmentStatus>AssessmentStatus { get; set; }
        public virtual DbSet<DestinationService>DestinationService { get; set; }
        public virtual DbSet<FrequencyInterval> FrequencyInterval { get; set; }
        public virtual DbSet<InstancesPerFrequencyInterval> InstancesPerFrequencyInterval { get; set; }
        public virtual DbSet<InteractionMechanism> InteractionMechanism { get; set; }
        public virtual DbSet<InteractionSpan> InteractionSpan { get; set; }
        public virtual DbSet<InteractionStatus> InteractionStatus { get; set; }
        public virtual DbSet<InteractionTriggerType> InteractionTriggerType { get; set; }
        public virtual DbSet<NonServiceDataDestination> NonServiceDataDestination { get; set; }
        public virtual DbSet<NonServiceDataSource> NonServiceDataSource { get; set; }
        public virtual DbSet<ObjectDataFormat> ObjectDataFormat { get; set; }
        public virtual DbSet<ObjectofInteraction> ObjectofInteraction { get; set; }
        public virtual DbSet<RequestInteraction> RequestInteraction { get; set; }
        public virtual DbSet<RequestInteractionHistory> RequestInteractionHistory { get; set; }
        public virtual DbSet<SourceService> SourceService { get; set; }
        public virtual DbSet<HelperAppOrTeam> HelperAppOrTeam { get; set; }
        public virtual DbSet<InteractionAction> InteractionAction { get; set; }
        public virtual DbSet<Request>Request { get; set; }     
        public virtual DbSet<RequestChannel>RequestChannel { get; set; }
        public virtual DbSet<RequestService>RequestService { get; set; }
        public virtual DbSet<RequestState>RequestState { get; set; }
        public virtual DbSet<RequestType>RequestType { get; set; }
        public virtual DbSet<LineOfBusiness> LineOfBusiness { get; set; }
        public virtual DbSet<CompanionFileType> CompanionFileType { get; set; }
        public virtual DbSet<InteractionReviewStatus> InteractionReviewStatus { get; set; }
        public virtual DbSet<AssessmentDesigners> AssessmentDesigners { get; set; }

        public virtual DbSet<EsocaideData> EsocaideData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
