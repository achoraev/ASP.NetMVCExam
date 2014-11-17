namespace ForumSystem.Data.Models
{    
    using System;
    using System.ComponentModel.DataAnnotations;
    using ForumSystem.Data.Common.Models;

    public class Feedback : AuditInfo, IDeletableEntity
    {
        [Required]
        public int Id { get; set; }

        public ApplicationUser Author { get; set; }

        public string Content { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        
        public DateTime? DeletedOn { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}