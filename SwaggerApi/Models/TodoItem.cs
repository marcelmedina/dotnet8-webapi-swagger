using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SwaggerApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [DefaultValue(false)]
        public bool IsComplete { get; set; }
    }
}
