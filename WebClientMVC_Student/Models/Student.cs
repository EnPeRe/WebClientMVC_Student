using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientMVC_Student.Models
{
    public class Student
    {
        #region Properties
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public Guid Student_Guid { get; set; }
        #endregion

        #region constructors
        public Student()
        {

        }

        public Student(int id, string name, int edad, string datebirth)
        {
            this.IdAlumno = id;
            this.Nombre = name;
            this.Edad = edad;
            this.FechaNacimiento = Convert.ToDateTime(datebirth);
        }

        public Student(string name, int edad, string datebirth)
        {
            this.Nombre = name;
            this.Edad = edad;
            this.FechaNacimiento = Convert.ToDateTime(datebirth);
        }

        public Student(int id, string name, string fechanacimiento, int edad, string st_guid)
        {
            this.IdAlumno = id;
            this.Nombre = name;
            this.FechaNacimiento = Convert.ToDateTime(fechanacimiento);
            this.Edad = edad;
            this.Student_Guid = Guid.Parse(st_guid);
        }
        #endregion

    }
}