
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace biblioteca.importacao
{
    public static class Xml
    {

        public static T LerArquivoXml<T>(T nota, string caminho)
        {

            try
            {

                XmlSerializer ser = new XmlSerializer(typeof(T));
                TextReader textReader = (TextReader)new StreamReader(caminho);
                XmlTextReader reader = new XmlTextReader(textReader);
                reader.Read();

                nota = (T)ser.Deserialize(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();

            }

            return nota;

        }

        public static XElement ConvertStringToXmlElement(string xml)
        {
            XElement doc = XElement.Parse(xml);

            return doc;
        }

        public static string IdentXML(string xml)
        {
            string result = "";

            MemoryStream mStream = new MemoryStream();
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(mStream, Encoding.Unicode);
            System.Xml.XmlDocument document = new System.Xml.XmlDocument();

            try
            {
                // Load the XmlDocument with the XML.
                document.LoadXml(xml);

                writer.Formatting = System.Xml.Formatting.Indented;

                // Write the XML into a formatting XmlTextWriter
                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                // Have to rewind the MemoryStream in order to read
                // its contents.
                mStream.Position = 0;

                // Read MemoryStream contents into a StreamReader.
                StreamReader sReader = new StreamReader(mStream);

                // Extract the text from the StreamReader.
                string formattedXml = sReader.ReadToEnd();

                result = formattedXml;
            }
            catch (System.Xml.XmlException)
            {
                // Handle the exception
            }

            mStream.Close();
            writer.Close();

            return result;
        }

        public static bool GerarArquivoXML(out Exception erro, string arquivo, XElement texto)
        {
            erro = new Exception();

            try
            {
                texto.Save(arquivo, SaveOptions.DisableFormatting);
                return true;
            }
            catch (Exception e)
            {
                erro = e;

                return false;

            }
        }

    }
}
