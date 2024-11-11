namespace ADO_EduHub_Project{
    internal class Feedback{
        public  int FeedbackId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public string FeedMessage { get; set; }
        public DateTime Date { get; set; }
    }
}