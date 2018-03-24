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
        public static void Menu(FileStream fileStream, StreamWriter documento)
        {
            int opc = 1;

                Console.Clear();
                Console.WriteLine("Gestion de alumnos" + GetFormato());
                Console.WriteLine("Elija una opcion:");
                Console.WriteLine("1 - Crear nuevo alumno");
                Console.WriteLine("2 - Text");
                Console.WriteLine("3 - Json");
                Console.WriteLine("4 - Salir");
                opc = Convert.ToInt32(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Alumno alumn = SetAlumno();
                        if (GetFormato() == "txt")
                        {
                            documento.WriteLine(alumn.Id + "," + alumn.Nombre + "," + alumn.Apellido + "," + alumn.Dni);
                            Menu(fileStream, documento);
                        }
                        else
                        {
                            string json = JsonConvert.SerializeObject(alumn);
                            documento.WriteLine(json + ",");
                            Menu(fileStream, documento);
                        }

                        break;
                    case 2:
                        SetFormato("txt");

                        FileStream fileStreamTxt = new FileStream("AdministracionAlumnos." + GetFormato(), FileMode.Create, FileAccess.Write);
                        StreamWriter documentoTxt = new StreamWriter(fileStreamTxt);

                        Console.WriteLine("Formato: " + GetFormato());
                        Console.WriteLine("Pulse cualqier tecla para volver al menu.");
                        Console.ReadKey();

                        Menu(fileStreamTxt, documentoTxt);

                        break;
                    case 3:
                        SetFormato("json");
                        
                        FileStream fileStreamJson = new FileStream("AdministracionAlumnos." + GetFormato(), FileMode.Create, FileAccess.Write);
                        StreamWriter documentoJson = new StreamWriter(fileStreamJson);

                        Console.WriteLine("Formato: " + GetFormato());
                        Console.WriteLine("Pulse cualqier tecla para volver al menu.");
                        Console.ReadKey();
                        documentoJson.WriteLine("[");

                        Menu(fileStreamJson, documentoJson);

                        break;
                    case 4:
                        Console.WriteLine(GetFormato());
                        if (GetFormato() == "txt")
                        {
                            documento.Close();
                            fileStream.Close();
                        }
                        else
                        {
                            documento.Write("]");
                            documento.Close();
                            fileStream.Close();
                        }
                        break;
                }

        }

        public static string GetFormato()
        {
            string formatoDoc = ConfigurationManager.AppSettings["Formato"];

            return formatoDoc;
        }

        public static void SetFormato(string formato)
        {
            XmlDocument xmlDoc1 = new XmlDocument();
            xmlDoc1.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement element in xmlDoc1.DocumentElement)
            {
                if (element.Name.Equals("appSettings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes[0].Value.Equals("Formato"))
                        {
                            node.Attributes[1].Value = formato;
                        }
                    }
                }
            }
            xmlDoc1.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static Alumno SetAlumno()
        {
            Alumno alumno = new Alumno();

            Console.Write("Identificador: ");
            string id = Console.ReadLine();
            alumno.Id = Convert.ToInt32(id);

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
