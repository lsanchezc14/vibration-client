using MainClientVibration.Repositories;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace MainClientVibration;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseSkiaSharp(true)
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<CustomerRepository>();
        builder.Services.AddSingleton<MachineRepository>();
        builder.Services.AddSingleton<DataRepository>();

        return builder.Build();
	}
}
