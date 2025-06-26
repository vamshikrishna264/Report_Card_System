namespace Report_Card_System.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ExamSubject> ExamSubjects { get; set; }
    }
}
