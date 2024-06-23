namespace SoldierFit.Infrastructure.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SoldierFit.Infrastructure.Constants.DataConstraints;

    /// <summary>
    /// Represents an athlete registered in the application.
    /// </summary>
    [Index(nameof(PhoneNumber), IsUnique = true)]
    [Comment("Athletes table")]
    public class Athlete
    {
        /// <summary>
        /// Gets or sets the unique identifier for the athlete.
        /// </summary>
        [Key]
        [Comment("Athlete identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the athlete.
        /// </summary>
        [Required]
        [MaxLength(AthleteNamesMaxLength)]
        [Comment("Athlete first name")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the middle name of the athlete.
        /// </summary>
        [Required]
        [MaxLength(AthleteNamesMaxLength)]
        [Comment("Athlete middle name")]
        public string MiddleName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the athlete.
        /// </summary>
        [Required]
        [MaxLength(AthleteNamesMaxLength)]
        [Comment("Athlete last name")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the age of the athlete.
        /// </summary>
        [Required]
        [Comment("Athlete age")]
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the athlete.
        /// </summary>
        [Required]
        [MaxLength(AthletePhoneMaxLength)]
        [Phone]
        [Comment("Athlete phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the athlete.
        /// </summary>
        [Required]
        [MaxLength(AthleteEmailMaxLength)]
        [EmailAddress]
        [Comment("Athlete email address")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the identifier of the user associated with this athlete.
        /// </summary>
        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user associated with this athlete.
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of workouts associated with this athlete.
        /// </summary>
        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    }
}
