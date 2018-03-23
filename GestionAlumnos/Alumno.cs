using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAlumnos
{
    public class Alumno :IAlumno
    {
        public string Apellido(string apellido)
        {
            return apellido;
        }

        public string Dni(string dni)
        {
            return dni;
        }

        public string Id(string id)
        {
            return id;
        }

        public string Nombre(string nombre)
        {
            return nombre;
        }
    }
}
