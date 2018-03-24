using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAlumnos
{
    class Gestor : Funcionalidades
    {
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream("AdministracionAlumnos." + GetFormato(), FileMode.Create, FileAccess.Write);
            StreamWriter documento = new StreamWriter(fileStream);
            Menu(fileStream, documento);
        }
    }
}
