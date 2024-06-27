namespace SoldierFit.Infrastructure.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Comment("AthletesWorkouts map table")]
    public class AthleteWorkout
    {
        [Required]
        [Comment("Athlete identifier")]
        public int AthleteId { get; set; }

        [ForeignKey(nameof(AthleteId))]
        public Athlete Athlete { get; set; } = null!;

        [Required]
        [Comment("Workout identifier")]
        public int WorkoutId { get; set; }

        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; } = null!;
    }
}
