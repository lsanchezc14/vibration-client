using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using MainClientVibration.MVVM.Models;
using PropertyChanged;
using SkiaSharp;
using System.Windows.Input;

namespace MainClientVibration.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        public ICommand AddOrUpdateCommand { get; set; }
        public ISeries[] Series { get; set; }
        public ISeries[] SeriesZoomed { get; set; }
        public ISeries[] SeriesPolar { get; set; }
        public ISeries[] SeriesFft { get; set; }
        public Axis[] XAxes { get; set; } = new Axis[]
        {
            new Axis
            {
                Name = "Tiempo (ms)",
                NamePaint = new SolidColorPaint(SKColors.Black),
                LabelsPaint = new SolidColorPaint(SKColors.Blue),
                TextSize = 20,
                SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 2 },
            }
        };

        public Axis[] YAxes { get; set; } = new Axis[]
        {
            new Axis
            {
                Name = "Amplitud (mm/s)",
                NamePaint = new SolidColorPaint(SKColors.Black),
                LabelsPaint = new SolidColorPaint(SKColors.Blue),
                TextSize = 20,
                SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 2 }
            }
        };

        public Axis[] XAxesFft { get; set; } = new Axis[]
        {
            new Axis
            {
                Name = "Frecuencia (Hz)",
                NamePaint = new SolidColorPaint(SKColors.Black),
                LabelsPaint = new SolidColorPaint(SKColors.Blue),
                TextSize = 20,
                SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 2 },
                MaxLimit = 500,
                MinLimit = 0
            }
        };

        public Axis[] YAxesFft { get; set; } = new Axis[]
        {
            new Axis
            {
                Name = "Amplitud (mm/s)",
                NamePaint = new SolidColorPaint(SKColors.Black),
                LabelsPaint = new SolidColorPaint(SKColors.Blue),
                TextSize = 20,
                SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 2 },
                MaxLimit = 1000,
                MinLimit = 0

            }
        };

        public PolarAxis[] AngleAxes { get; set; } =
        {
            new PolarAxis
            {
                LabelsRotation = LiveCharts.TangentAngle,
                Labels = new[] { "Normal", "Cavitación", "Desalineamiento", "Soltura", "Otros" }
            }
        };


        public MainPageViewModel(double[] amplitudeArray, double[] fftArray)
        {
            this.Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = amplitudeArray,
                    Fill = null,
                    GeometrySize = 0,
                    LineSmoothness = 1,
                }
            };

            this.SeriesZoomed = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = amplitudeArray,
                    Fill = null,
                    LineSmoothness = 1,
                }
            };

            this.SeriesFft = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = fftArray,
                    Fill = null,
                    GeometrySize = 0,
                    LineSmoothness = 1,
                }
            };

            this.SeriesPolar = new ISeries[]
            {
                new PolarLineSeries<int>
                {
                    Values = new[] { 96, 1, 1, 1, 1 },
                    LineSmoothness = 0,
                    GeometrySize= 0,
                    Fill = new SolidColorPaint(SKColors.Blue.WithAlpha(90))
                },
            };

            AddOrUpdateCommand = new Command(async () =>
            {
                
                App.CustomerRepo.AddOrUpdate(this.CreateCustomer());
                App.MachineRepo.AddOrUpdate(this.CreateMachine());
                App.DataRepo.AddOrUpdate(this.CreateData(amplitudeArray, fftArray));
            });
        }

        private Customer CreateCustomer()
        {
            var customer = new Customer();
            customer.Name = "Empresa1";
            customer.Country = "Costa Rica";

            return customer;
        }

        private Machine CreateMachine()
        {
            var machine = new Machine();
            machine.CustomerId = 1;
            machine.Type = "Bomba Centrifuga";

            return machine;
        }

        private Data CreateData(double[] rawData, double[] fftData)
        {
            var data = new Data();
            data.MachineId = 1;
            data.Prediction = "[96, 1, 1, 1, 1]";
            data.RawData = rawData.SelectMany(value => BitConverter.GetBytes(value)).ToArray();
            data.FftData = fftData.SelectMany(value => BitConverter.GetBytes(value)).ToArray();

            return data;
        }
    }
}
