using CsvHelper.Configuration.Attributes;
using System.Runtime.Serialization;

namespace l1
{
    [DataContract]
    public class Student
    {
        [DataMember]
        [Name("Фамилия")]
        public string firstName { get; set; }
        [DataMember]
        [Name("Имя")]
        public string lastName { get; set; }
        [DataMember]
        [Name("Отчество")]
        public string rlyLastName { get; set; }
        [Name("Математика")]
        public int mat { get; set; }
        [Name("Физика")]
        public int phy { get; set; }
        [Name("Химия")]
        public int chem { get; set; }
        [Name("Черчение")]
        public int draw { get; set; }
        [Name("Алгоритм")]
        public int al { get; set; }
        [DataMember]
        public double avg { get; set; }
        public void culc() { 
                    avg = (mat + phy + chem + draw + al) / 5 ;
        }
    }
}
