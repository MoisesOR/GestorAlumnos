using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionAlumnos;

namespace TestGestorAlumnos
{
    [TestClass()]
    public class GestorConfTest
    {
        GestorConf gestorConf = new GestorConf();

        [DataRow("txt")]
        [DataRow("json")]
        [DataTestMethod]
        public void GetFormato(string res)
        {
            Assert.IsTrue(gestorConf.GetFormato() == res);
        }
    }
}
