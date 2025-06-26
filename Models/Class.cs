﻿namespace Report_Card_System.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public string AcademicYear { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
