using MainClientVibration.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainClientVibration.Repositories
{
    public class CustomerRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public CustomerRepository()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            Console.WriteLine(Constants.DatabasePath);
            connection.CreateTable<Customer>();
        }

        public void AddOrUpdate(Customer customer)
        {
            var result = 0;

            try
            {
                if (customer.Id != 0)
                {
                    result = connection.Update(customer);
                    StatusMessage = $"{result} row(s) updated";
                }
                else
                {
                    result = connection.Insert(customer);
                    StatusMessage = $"{result} row(s) added";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error:{ex.Message}";
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
                return connection.Table<Customer>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error:{ex.Message}";
            }

            return null;
        }

        public Customer GetCustomer(int id)
        {
            try
            {
                return connection.Table<Customer>().FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error:{ex.Message}";
            }

            return null;
        }

        public void Delete(int id)
        {
            try
            {
                var customer = GetCustomer(id);
                connection.Delete(customer);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error:{ex.Message}";
            }
        }
    }
}
