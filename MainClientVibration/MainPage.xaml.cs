using MainClientVibration.MVVM.Models;
using MainClientVibration.MVVM.ViewModel;

namespace MainClientVibration;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();
    }

    private async void MenuOpen_Clicked(object sender, EventArgs e)
    {
        var csvFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
        {
            { DevicePlatform.WinUI, new[] { ".csv" } },
        });

        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Select a .csv file",
            FileTypes = csvFileType
        });

        if (result != null)
        {
            await DisplayAlert("File selected: ", result.FileName, "OK");
            List<RawTimeSeries> rawTimeSeries = File.ReadAllLines(result.FullPath.ToString())
                .Skip(2)
                .Select(v => RawTimeSeries.FromCsv(v, separator: ";"))
                .ToList();

            this.UpdateRawDataChart(rawTimeSeries.GetRange(0, 4096));
        }
    }

    private void MenuExit_Clicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }

    public void UpdateRawDataChart(List<RawTimeSeries> rawTimeSeries)
    {
        var amplitudeArray = rawTimeSeries
            .Select(x => x.Amplitude).ToArray();

        var fftArray = readfft();

        BindingContext = new MainPageViewModel(amplitudeArray, fftArray);
    }

    private double[] readfft()
    {
        string[] rawFftSeries = File.ReadAllLines("C:\\Git\\MainClient\\MainClient2\\MainClient2\\Resources\\DataFiles\\fft.csv");
        List<string> list = new List<string>(rawFftSeries);

        var fftArray = list.Select(x => double.Parse(x)).ToArray();

        return fftArray;
    }

}

