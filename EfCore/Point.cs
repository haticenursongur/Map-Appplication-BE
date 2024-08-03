using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapApi1.EfCore
{
    [Table("point")]
    public class Point
    {
        [Key, Required]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string wkt { get; set; } = string.Empty;
    }
}
