using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Report_Card_System.Models;
using System.Reflection.Metadata.Ecma335;

namespace Report_Card_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        
        
            private readonly SchoolDbContext _context;

            public ReportController(SchoolDbContext context)
            {
                _context = context;
            }

            [HttpPost("getreportcards")]
            public async Task<ActionResult<List<ReportCard>>> GetReportCards([FromBody] List<int> studentIds)
            {
                var reportCards = await _context.Students.Where(s => studentIds.Contains(s.Id)).Include(s=>s.Class)
            .Select(s => new ReportCard
            {
                StudentId = s.Id,
                StudentName = s.Name,
                ClassName = s.Class.Name,
                Section = s.Class.Section,
                AcademicYear = s.Class.AcademicYear,
                Exams = _context.Exams.Select(exam => new ExamDetails
                {
                    ExamId = exam.Id,
                    ExamName = exam.Name,
                    Subjects = _context.ExamSubjects
                        .Where(es => es.ExamId == exam.Id)
                        .Select(es => new SubjectDetails
                        {
                            SubjectId = es.SubjectId,
                            SubjectName = es.Subject.Name,
                            MaxMarks = es.MaxMarks,
                            MarksObtained = _context.Marks
                                .Where(m => m.StudentId == s.Id && m.ExamSubjectId == es.Id)
                                .Select(m => m.MarksObtained)
                                .FirstOrDefault()
                        }).ToList()
                }).ToList()
            })
            .ToListAsync();
                return reportCards;

            }
        }
    }

