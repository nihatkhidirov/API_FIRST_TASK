using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPB301.DLL.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Point { get; set; }
        public int GroupId { get; set; }
        public Group Groups { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }


    }
}
