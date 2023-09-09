using LiveChartsCore;
using MainClientVibration.Repositories;

namespace MainClientVibration;

public partial class App : Application
{
    public static CustomerRepository CustomerRepo { get; private set; }
    public static MachineRepository MachineRepo { get; private set; }
    public static DataRepository DataRepo { get; private set; }

    public App(CustomerRepository customerRepository, MachineRepository machineRepo, DataRepository dataRepo)
	{
		InitializeComponent();

        CustomerRepo = customerRepository;

        MachineRepo = machineRepo;

        DataRepo = dataRepo;

		MainPage = new AppShell();
	}

    protected override void OnStart()
    {
        UserAppTheme = AppTheme.Light;
        base.OnStart();
    }

}
