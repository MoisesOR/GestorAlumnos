using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAlumnos
{
    class GestorDocumento
    {
        public StreamWriter SetDocumento(string nombreDoc)
        {
            GestorConf gestionConfiguracionSet = new GestorConf();
            FileStream fileStream = new FileStream(nombreDoc + "." + gestionConfiguracionSet.GetFormato(), FileMode.Create, FileAccess.Write);
            StreamWriter documento = new StreamWriter(fileStream);

            return documento;
        }

        public StreamWriter AppendDocumento(string nombreDoc)
        {
            GestorConf gestionConfiguracionRead = new GestorConf();
            FileStream fileStream = new FileStream(nombreDoc + "." + gestionConfiguracionRead.GetFormato(), FileMode.Append, FileAccess.Write);
            StreamWriter documento = new StreamWriter(fileStream);

            return documento;
        }

        public StreamWriter ReadDocumento(string nombreDoc)
        {
            GestorConf gestionConfiguracionRead = new GestorConf();
            FileStream fileStream = new FileStream(nombreDoc + "." + gestionConfiguracionRead.GetFormato(), FileMode.Open, FileAccess.Read);
            StreamWriter documento = new StreamWriter(fileStream);

            return documento;
        }

        public string GetPath(string nombreDoc)
        {
            GestorConf gestorConf = new GestorConf();
            var path = nombreDoc + "." + gestorConf.GetFormato();
            return path;
        }

        public bool IsDocumento(string nombreDoc)
        {
            if (File.Exists(GetPath(nombreDoc)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DocumentoTxt(string nombreDoc)
        {
            Funcionalidades funcionalidades = new Funcionalidades();

            if (!File.Exists(GetPath(nombreDoc)))
            {
                var doc = SetDocumento(nombreDoc);
                var alumno = funcionalidades.SetAlumno();
                doc.WriteLine(alumno.Id + "," + alumno.Nombre + "," + alumno.Apellido + "," + alumno.Dni);
                doc.Close();
            }
            else
            {
                var doc = AppendDocumento(nombreDoc);
                var alumno = funcionalidades.SetAlumno();
                doc.WriteLine(alumno.Id + "," + alumno.Nombre + "," + alumno.Apellido + "," + alumno.Dni);
                doc.Close();
            }
        }

        public void DocumentoJson(string nombreDoc)
        {
            Funcionalidades funcionalidades = new Funcionalidades();

            if (!File.Exists(GetPath(nombreDoc)))
            {
                var alumnos = funcionalidades.SetAlumno();

                List<Alumno> alumnosLista = new List<Alumno>
                {
                    alumnos
                };

                using (StreamWriter doc = File.CreateText(GetPath(nombreDoc)))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(doc, alumnosLista);
                }
            }
            else
            {
                var alumnosListaSerializada = System.IO.File.ReadAllText(GetPath(nombreDoc));
                var alumnosLista = JsonConvert.DeserializeObject<List<Alumno>>(alumnosListaSerializada);
                var alumnos = funcionalidades.SetAlumno();

                alumnosLista.Add(alumnos);
                alumnosListaSerializada = JsonConvert.SerializeObject(alumnosLista, Formatting.Indented);
                File.WriteAllText(GetPath(nombreDoc), alumnosListaSerializada);
            }
        }
    }
}
