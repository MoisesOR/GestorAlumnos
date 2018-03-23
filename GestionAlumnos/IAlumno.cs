using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAlumnos
{
    public interface IAlumno
    {
        string Id(string id);
        string Nombre(string nombre);
        string Apellido(string apellido);
        string Dni(string dni);
    }
}
