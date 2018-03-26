using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GestionAlumnos
{
    class GestorConf
    {
        public string GetFormato()
        {
            string formatoDoc = ConfigurationManager.AppSettings["Formato"];

            return formatoDoc;
        }

        public void SetFormato(string formato)
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
    }
}
