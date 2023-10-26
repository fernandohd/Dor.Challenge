using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dor.Challenge.Fernando.Domain.Persistance.Entities
{
    [Table("Authors")]
    public class AuthorEntity
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? Nationality { get; set; }

        [InverseProperty("Author")]
        public ICollection<BlogEntity>? Blogs { get; set; }
    }
}
