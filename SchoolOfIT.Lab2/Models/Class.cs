using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolOfIT.Lab2.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string? ClassName { get; set; }
        public virtual ICollection<RelationTable>? Relations { get; set; }
    }
}
