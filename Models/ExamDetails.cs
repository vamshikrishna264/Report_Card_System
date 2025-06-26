namespace Report_Card_System.Models
{
    public class ExamDetails
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }

        public List<SubjectDetails> Subjects { get; set; }

        public int TotalMarksObtained => Subjects.Sum(s => s.MarksObtained);
        public int TotalMaxMarks => Subjects.Sum(s => s.MaxMarks);
        public double Percentage => TotalMaxMarks == 0 ? 0 : (double)TotalMarksObtained / TotalMaxMarks * 100;
    }
}
