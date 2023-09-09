using SQLite;

namespace MainClientVibration.MVVM.Models
{
    [Table("Data")]
    public class Data
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int MachineId { get; set; }
        public byte[] RawData { get; set; }
        public byte[] FftData { get; set; }
        public string Prediction { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
