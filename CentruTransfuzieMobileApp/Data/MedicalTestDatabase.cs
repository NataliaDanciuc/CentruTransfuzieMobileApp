using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentruTransfuzieMobileApp.Models;
using SQLite;

namespace CentruTransfuzieMobileApp.Data
{
    public class MedicalTestDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public MedicalTestDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<MedicalTest>().Wait();
            _database.CreateTableAsync<Service>().Wait();
            _database.CreateTableAsync<ListService>().Wait();
        }
        public Task<int> SaveServiceAsync(Service service)
        {
            if (service.ID != 0)
            {
                return _database.UpdateAsync(service);
            }
            else
            {
                return _database.InsertAsync(service);
            }
        }
        public Task<int> DeleteServiceAsync(Service service)
        {
            return _database.DeleteAsync(service);
        }
        public Task<List<Service>> GetServicesAsync()
        {
            return _database.Table<Service>().ToListAsync();
        }

        public Task<int> SaveListServiiceAsync(ListService lists)
        {
            if (lists.ID != 0)
            {
                return _database.UpdateAsync(lists);
            }
            else
            {
                return _database.InsertAsync(lists);
            }
        }
        public Task<List<Service>> GetListServicesAsync(int medicaltestid)
        {
            return _database.QueryAsync<Service>(
            "select S.ID, S.Description from Service S"
            + " inner join ListService LS"
            + " on S.ID = LS.ServiceID where LS.MedicalTestID = ?",
            medicaltestid);
        }


    }
}
