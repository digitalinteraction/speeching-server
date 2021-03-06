﻿using System.Data.Entity;
using Crowd.Model.Data;

namespace Crowd.Model
{
    public class CrowdContext : DbContext
    {
        public CrowdContext()
            : base("name=CrowdScience")
        {
            System.Console.WriteLine("*****start******");
            Database.SetInitializer<CrowdContext>(new CustomDBInitializer());
            //this.Database.Initialize(true);
        }

        public DbSet<ActivityHelper> ActivityHelpers { get; set; }
        public DbSet<ParticipantActivityCategory> ParticipantActivityCategories { get; set; }
        public DbSet<ParticipantActivity> ParticipantActivities { get; set; }
        public DbSet<ParticipantTask> ParticipantTasks { get; set; }
        public DbSet<ParticipantTaskContent> ParticipantTaskContents { get; set; }
        public DbSet<ParticipantTaskResponse> ParticipantTaskResponses { get; set; }
        public DbSet<ParticipantPage> ParticipantPages { get; set; }
        public DbSet<ParticipantResult> ParticipantResults { get; set; }

        public DbSet<ParticipantAssessmentTask> ParticipantAssessmentTasks { get; set; }
        public DbSet<ParticipantAssessmentTaskPrompt> ParticipantAssessmentTaskPrompts { get; set; }

        public DbSet<CrowdJudgementData> CrowdJudgementDatas { get; set; }
        public DbSet<CrowdRowResponse> CrowdRowResponses { get; set; }
        public DbSet<CrowdJudgement> CrowdJudgements { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<ParticipantFeedItem> ParticipantFeedItems { get; set; }

        public DbSet<DebugMessage> DebugMessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParticipantTask>()
            .HasOptional(l => l.ParticipantTaskContent)
            .WithRequired(r => r.ParticipantTask);

            modelBuilder.Entity<ParticipantTask>()
            .HasOptional(l => l.ParticipantTaskResponse)
            .WithRequired(r => r.ParticipantTask);

            modelBuilder.Entity<ParticipantTask>()
            .HasOptional(s => s.ParticipantActivity)
            .WithMany()
            .WillCascadeOnDelete(false);
        }
    }
}