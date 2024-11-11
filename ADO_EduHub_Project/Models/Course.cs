namespace ADO_EduHub_Project{
    internal class Course{
        public int CourseId {get;set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }
        public int UserId { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
    }
}