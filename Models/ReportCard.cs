namespace Report_Card_System.Models
{
    public class ReportCard
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
        public string AcademicYear { get; set; }

        public List<ExamDetails> Exams { get; set; }
    }
}
