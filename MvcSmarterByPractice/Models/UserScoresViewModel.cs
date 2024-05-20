using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcSmarterByPractice.Models
{
    public class UserScoresViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Input Date")]
        public DateTime InputDate { get; set; }


        [Required]
        [DisplayName("Reaction Time")]
        public int ReactionTime { get; set; }

        [Required]
        [DisplayName("Sequence Memory")]
        public int SequenceMemory { get; set; }

        [Required]
        [DisplayName("Aim Trainer")]
        public int AimTrainer { get; set; }

        [Required]
        [DisplayName("Number Memory")]
        public int NumberMemory { get; set; }

        [Required]
        [DisplayName("Verbal Memory")]
        public int VerbalMemory { get; set; }

        [Required]
        [DisplayName("Chimp Test")]
        public int ChimpTest { get; set; }

        [Required]
        [DisplayName("Visual Memory")]
        public int VisualMemory { get; set; }

        [Required]
        [DisplayName("Typing Test")]
        public int TypingTest { get; set; }

        [DisplayName("Time To Complete")]
        public int Time { get; set; }
    }
}
