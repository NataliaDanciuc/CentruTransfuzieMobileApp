using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentruTransfuzieMobileApp.Models
{
    public class ListService
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(MedicalTest))]
        public int MedicalTestID { get; set; }
        public int ServiceID { get; set; }
    }
}
