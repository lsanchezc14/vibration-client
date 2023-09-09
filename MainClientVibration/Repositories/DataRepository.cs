using MainClientVibration.MVVM.Models;
using SQLite;

namespace MainClientVibration.Repositories
{
    public class DataRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public DataRepository()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            Console.WriteLine(Constants.DatabasePath);
            connection.CreateTable<Data>();
        }

        public void AddOrUpdate(Data data)
        {
            var result = 0;

            try
            {
                if (data.Id != 0)
                {
                    result = connection.Update(data);
                    StatusMessage = $"{result} row(s) updated";
                }
                else
                {
                    result = connection.Insert(data);
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
