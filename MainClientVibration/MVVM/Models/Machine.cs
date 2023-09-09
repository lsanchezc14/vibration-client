using SQLite;

namespace MainClientVibration.MVVM.Models
{
    [Table("Machines")]
    public class Machine
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("type"), Indexed, NotNull]
        public string Type { get; set; }
        [Unique]
        public string Series { get; set; }

        public int CustomerId { get; set; }
    }
}
