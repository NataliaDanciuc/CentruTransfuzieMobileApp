using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CentruTransfuzieMobileApp.Models
{
    public class MedicalTest
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
