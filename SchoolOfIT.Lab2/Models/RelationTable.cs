using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolOfIT.Lab2.Models
{
    public class RelationTable
    {
        //
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Students")]
        public int FK_StudentId { get; set; }
        public virtual Student Students { get; set; }
        [ForeignKey("Teachers")]
        public int FK_TeacherId { get; set; }
        public virtual Teacher Teachers { get; set; }
        [ForeignKey("Courses")]
        public int FK_CourseId { get; set; }
        public virtual Course Courses { get; set; }
        [ForeignKey("Classes")]
        public int FK_ClassId { get; set; }
        public virtual Class Classes { get; set; }

    }
}
