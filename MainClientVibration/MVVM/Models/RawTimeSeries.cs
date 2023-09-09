using System.ComponentModel;

namespace MainClientVibration.MVVM.Models
{
    public class RawTimeSeries
    {
        public float Time { get; set; }
        public double Amplitude { get; set; }

        public static RawTimeSeries FromCsv(string csv, string separator = ",")
        {
            string[] values = csv.Split(separator);
            RawTimeSeries rawTimeSeries = new RawTimeSeries();
            rawTimeSeries.Time = float.Parse(values[0]);
            rawTimeSeries.Amplitude = double.Parse(values[1]);

            return rawTimeSeries;
        }
    }
}
