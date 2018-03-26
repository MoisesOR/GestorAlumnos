using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionAlumnos;
using System.IO;
using System.Text;

namespace TestGestorAlumnos
{
    [TestClass()]
    public class GestorDocumentoTest
    {
        GestorDocumento gestionDocumento = new GestorDocumento();

        [DataRow("DocumentoAlumnos.txt")]
        [DataRow("DocumentoAlumnos.txt")]
        [DataTestMethod]
        public void SetDocumentoTest(string path)
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(path))
            {
                var doc = gestionDocumento.SetDocumento(path);

                string actual = Encoding.UTF8.GetString(stream.ToArray());
                Assert.AreEqual(doc, actual);
            }
        }

        [DataRow("DocumentoAlumnos.txt")]
        [DataRow("DocumentoAlumnos.txt")]
        [DataTestMethod]
        public void AppendDocumento(string path)
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(path))
            {
                var doc = gestionDocumento.AppendDocumento(path);

                string actual = Encoding.UTF8.GetString(stream.ToArray());
                Assert.AreEqual(doc, actual);
            }
        }

        [DataRow("DocumentoAlumnos.txt")]
        [DataRow("DocumentoAlumnos.txt")]
        [DataTestMethod]
        public void ReadDocumento(string path)
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(path))
            {
                var doc = gestionDocumento.AppendDocumento(path);

                string actual = Encoding.UTF8.GetString(stream.ToArray());
                Assert.AreEqual(doc, actual);
            }
        }

        [DataRow("DocumentoAlumnos", "DocumentoAlumnos.txt")]
        [DataRow("DocumentoAlumnos", "DocumentoAlumnos.json")]
        [DataTestMethod]
        public void GetPath(string nombreDoc, string res)
        {
            Assert.IsTrue(gestionDocumento.GetPath(nombreDoc) == res);
        }

        //[DataRow("DocumentoAlumnos", true)]
        [DataRow("DocumentoAlumnos", false)]
        [DataTestMethod]
        public void IsDocumento(string nombreDoc, bool res)
        {
            Assert.IsTrue(gestionDocumento.IsDocumento(nombreDoc) == res);
        }
    }
}
