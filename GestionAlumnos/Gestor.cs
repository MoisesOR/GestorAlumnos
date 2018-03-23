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
    class Gestor
    {
        public static void Menu(FileStream fileStream, StreamWriter doc)
        {
            IAlumno iAlumno = new Alumno();

            int opc = 1;
            bool formatoDoc = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Gestion de alumnos");
                Console.WriteLine("Elija una opcion:");
                Console.WriteLine("1 - Crear nuevo alumno");
                Console.WriteLine("2 - Text");
                Console.WriteLine("3 - Json");
                Console.WriteLine("4 - Salir");
                opc = Convert.ToInt32(Console.ReadLine());
            switch(opc)
            {
                    case 1:
                        Console.Write("Identificador: ");
                        string id = iAlumno.Id(Console.ReadLine());

                        Console.Write("Nombre: ");
                        string nombre = iAlumno.Nombre(Console.ReadLine());

                        Console.Write("Apellidos: ");
                        string apellido = iAlumno.Apellido(Console.ReadLine());

                        Console.Write("DNI: ");
                        string dni = iAlumno.Dni(Console.ReadLine());

                        if(formatoDoc == true)
                        {
                            doc.WriteLine(id + "," + nombre + "," + apellido + "," + dni);
                        }
                        else
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Converters.Add(new JavaScriptDateTimeConverter());
                            serializer.NullValueHandling = NullValueHandling.Ignore;

                            using (JsonWriter writer = new JsonTextWriter(doc))
                            {
                                serializer.Serialize(writer, iAlumno);
                            }
                            string serializado = JsonConvert.SerializeObject(iAlumno);
                            Console.WriteLine(serializado);
                            Console.ReadKey();
                        }
                        
                        break;
                    case 2:
                        //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        //config.AppSettings.Settings["Formato"].Value = "txt";
                        //config.Save(ConfigurationSaveMode.Modified, true);
                        //ConfigurationManager.RefreshSection("Formato");
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                        foreach (XmlElement element in xmlDoc.DocumentElement)
                        {
                            if (element.Name.Equals("appSettings"))
                            {
                                foreach (XmlNode node in element.ChildNodes)
                                {
                                    if (node.Attributes[0].Value.Equals("Formato"))
                                    {
                                        node.Attributes[1].Value = "txt";
                                    }
                                }
                            }
                        }
                        xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                        ConfigurationManager.RefreshSection("appSettings");

                        string formatoTxt = ConfigurationManager.AppSettings["Formato"];
                        Console.WriteLine("Formato: " + formatoTxt);
                        Console.WriteLine("Pulse cualqier tecla para volver al menu.");
                        Console.ReadKey();
                        break;
                    case 3:
                        //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        //config.AppSettings.Settings["Formato"].Value = "json";
                        //config.Save(ConfigurationSaveMode.Modified, true);
                        //ConfigurationManager.RefreshSection("Formato");
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
                                        node.Attributes[1].Value = "json";
                                    }
                                }
                            }
                        }
                        xmlDoc1.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                        ConfigurationManager.RefreshSection("appSettings");

                        string formatoJson = ConfigurationManager.AppSettings["Formato"];
                        Console.WriteLine("Formato: " + formatoJson);
                        formatoDoc = false;
                        Console.WriteLine("Pulse cualqier tecla para volver al menu.");
                        Console.ReadKey();
                        break;
                    case 4:
                        doc.Close();
                        fileStream.Close();
                        break;
                    default:
                        Menu(fileStream, doc);
                        break;
                }
            } while (opc != 4);
        }
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream("DocumentoAlumnos.txt", FileMode.Create, FileAccess.Write);
            StreamWriter doc = new StreamWriter(fileStream);
            Menu(fileStream, doc);
        }
    }
}
