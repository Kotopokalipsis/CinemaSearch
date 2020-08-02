using System.ComponentModel.DataAnnotations;

namespace SharedKernel
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}