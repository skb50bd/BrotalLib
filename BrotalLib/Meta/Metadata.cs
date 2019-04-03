using System;

using Brotal.Extensions;

namespace Brotal
{
    public class Metadata
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public string CreationSummary => 
            $"Created {CreatedAt.Natural()} by {CreatedBy}";

        public string ModificationSummary => 
            $"Updated {UpdatedAt.Natural()} by {UpdatedBy}";

        public string Summary
            => CreatedAt.Subtract(UpdatedAt) < TimeSpan.FromSeconds(5)
                ? CreationSummary
                : ModificationSummary;
        

        private Metadata(
            string creator, 
            DateTimeOffset? creationTime = null)
        {
            CreatedBy = creator;
            CreatedAt = creationTime ?? DateTimeOffset.Now;
        }

        public static Metadata Created(
            string username, 
            DateTimeOffset creationTime) => 
            new Metadata(username, creationTime);

        public Metadata Updated(
            string username,
            DateTimeOffset? updateTime = null)
        {
            UpdatedBy = username;
            UpdatedAt = updateTime ?? DateTimeOffset.Now;

            return this;
        }
    }
}
