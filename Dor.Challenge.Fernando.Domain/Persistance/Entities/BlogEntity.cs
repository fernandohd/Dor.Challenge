using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dor.Challenge.Fernando.Domain.Persistance.Entities
{
    [Table("Blogs")]
    public class BlogEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? Title { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? Content { get; set; }

        [Column(TypeName = "int")]
        public int AuthorID { get; set; }

        [ForeignKey(nameof(AuthorID))]
        public AuthorEntity? Author { get; set; }
    }
}
