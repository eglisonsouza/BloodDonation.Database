namespace BloodDonation.Database.Core.Models.Entities.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        protected void Updated()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}
