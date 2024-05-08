namespace ApiSmarterByPractice.Models
{
    public class UserScores
    {
        public int Id { get; set; }
        public DateTime InputDate { get; set; }

        public int ReactionTime { get; set; }
        public int SequenceMemory { get; set; }
        public int AimTrainer { get; set; }
        public int NumberMemory { get; set; }
        public int VerbalMemory { get; set; }
        public int ChimpTest { get; set; }
        public int VisualMemory { get; set; }
        public int TypingTest { get; set; }
        public int Time { get; set; }
    }
}
