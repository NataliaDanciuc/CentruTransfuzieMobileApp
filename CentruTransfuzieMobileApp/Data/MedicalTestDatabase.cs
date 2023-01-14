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
        }
        public Task<List<MedicalTest>> GetMedicalTestsAsync()
        {
            return _database.Table<MedicalTest>().ToListAsync();
        }
        public Task<MedicalTest> GetMedicalTestAsync(int id)
        {
            return _database.Table<MedicalTest>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveMedicalTestAsync(MedicalTest mlist)
        {
            if (mlist.ID != 0)
            {
                return _database.UpdateAsync(mlist);
            }
            else
            {
                return _database.InsertAsync(mlist);
            }
        }
        public Task<int> DeleteMedicalTestAsync(MedicalTest mlist)
        {
            return _database.DeleteAsync(mlist);
        }

    }
}
