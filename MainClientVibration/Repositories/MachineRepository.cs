using MainClientVibration.MVVM.Models;
using SQLite;

namespace MainClientVibration.Repositories
{
    public class MachineRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public MachineRepository()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            Console.WriteLine(Constants.DatabasePath);
            connection.CreateTable<Machine>();
        }

        public void AddOrUpdate(Machine machine)
        {
            var result = 0;

            try
            {
                if (machine.Id != 0)
                {
                    result = connection.Update(machine);
                    StatusMessage = $"{result} row(s) updated";
                }
                else
                {
                    result = connection.Insert(machine);
                    StatusMessage = $"{result} row(s) added";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error:{ex.Message}";
            }
        }
    }
}
