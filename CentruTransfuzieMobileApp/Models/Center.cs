using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentruTransfuzieMobileApp.Models
{
    public class Center
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CenterName { get; set; }
        public string Adress { get; set; }
        public string CenterDetails
        {
            get
            {
                return CenterName + " "+Adress;} }
        [OneToMany]
        public List<MedicalTest> MedicalTests { get; set; }
    }
}
