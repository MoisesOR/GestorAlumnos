using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GestionAlumnos
{
    class Funcionalidades
    {
        public void Menu()
        {
            var opc = 1;
            GestorConf gestorConf = new GestorConf();
            var getFormato = gestorConf.GetFormato();

            Console.Clear();
            Console.WriteLine("Gestion de alumnos" + getFormato);
            Console.WriteLine("Elija una opcion:");
            Console.WriteLine("1 - Crear nuevo alumno");
            Console.WriteLine("2 - Text");
            Console.WriteLine("3 - Json");
            Console.WriteLine("4 - Salir");
            opc = Convert.ToInt32(Console.ReadLine());

            switch (opc)
            {
                case 1:
                    GestorDocumento gestorDocumento = new GestorDocumento();
                    var nombreDoc = "DocumentoAlumnos";
                    var isDoc = gestorDocumento.IsDocumento(nombreDoc);

                    if (getFormato == "txt")
                    {
                        gestorDocumento.DocumentoTxt(nombreDoc);
                        Menu();
                    }
                    else
                    {
                        gestorDocumento.DocumentoJson(nombreDoc);
                        Menu();
                    }
                    break;
                case 2:
                    gestorConf.SetFormato("txt");
                    Menu();
                    break;
                case 3:
                    gestorConf.SetFormato("json");
                    Menu();
                    break;
                case 4:
                    break;
            }
        }

        public Alumno SetAlumno()
        {
            Alumno alumno = new Alumno();

            Console.Write("Identificador: ");
            int id = Convert.ToInt32(Console.ReadLine());
            alumno.Id = id;

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            alumno.Nombre = nombre;

            Console.Write("Apellidos: ");
            string apellido = Console.ReadLine();
            alumno.Apellido = apellido;

            Console.Write("DNI: ");
            string dni = Console.ReadLine();
            alumno.Dni = dni;

            return alumno;
        }
    }
}
