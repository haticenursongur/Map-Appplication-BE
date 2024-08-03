using System.ComponentModel.DataAnnotations;

namespace MapApi1.Model
{
    public class PointModel
    {
        [Key, Required]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string wkt { get; set; } = string.Empty;
    }
}

