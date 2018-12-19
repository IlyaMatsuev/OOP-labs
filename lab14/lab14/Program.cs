using System;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            Port port = new Port(5);
            port[0] = new Ship(123F, "Vitya");
            port[1] = new Ship(34.3, "Ilya");
            port[2] = new Ship(5.3, "Max");
            port[3] = new Ship(38.6, "Olya");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream file = new FileStream("port.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, port);
            }
            using (FileStream file = new FileStream("port.dat", FileMode.Open))
            {
                Port newPort = (Port)formatter.Deserialize(file);
                foreach (var s in newPort.GetShips())
                    if(s != null)
                        s.GetVehicleInf();
            }
            Console.WriteLine("Binary serialize/deserialize was succesfully complete\n");



            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream file = new FileStream("port.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(file, port);
            }
            using (FileStream file = new FileStream("port.soap", FileMode.Open))
            {
                Port newPort = (Port)soapFormatter.Deserialize(file);
                foreach (var s in newPort.GetShips())
                    if (s != null)
                        s.GetVehicleInf();
            }
            Console.WriteLine("SOAP serialize/deserialize was succesfully complete\n");



            XmlSerializer xmlFormatter = new XmlSerializer(typeof(Port));
            using (FileStream file = new FileStream("port.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, port);
            }
            using (FileStream file = new FileStream("port.xml", FileMode.Open))
            {
                Port newPort = (Port)xmlFormatter.Deserialize(file);
                foreach (var s in newPort.GetShips())
                    if (s != null)
                        s.GetVehicleInf();
            }
            Console.WriteLine("XML serialize/deserialize was succesfully complete\n");



            TestJSONSerialize json = new TestJSONSerialize();
            json.IntProperty = 123;
            json.StrProperty = "hello world";
            DataContractJsonSerializer jsonParser = new DataContractJsonSerializer(typeof(TestJSONSerialize));
            using (FileStream file = new FileStream("port.json", FileMode.OpenOrCreate))
            {
                jsonParser.WriteObject(file, json);
            }
            using (FileStream file = new FileStream("port.json", FileMode.Open))
            {
                TestJSONSerialize newJson = (TestJSONSerialize)jsonParser.ReadObject(file);
                Console.WriteLine($"Json obj int prop: {json.IntProperty}, str prop: {newJson.StrProperty}");
            }
            Console.WriteLine("JSON serialize/deserialize was succesfully complete\n");
            Console.WriteLine("=====================================================\n");



            jsonParser = new DataContractJsonSerializer(typeof(List<TestJSONSerialize>));
            List<TestJSONSerialize> listjson = new List<TestJSONSerialize>()
            {
                json, json, json
            };
            using (FileStream file = new FileStream("collection.json", FileMode.OpenOrCreate))
            {
                jsonParser.WriteObject(file, listjson);
            }
            using (FileStream file = new FileStream("collection.json", FileMode.Open))
            {
                List<TestJSONSerialize> newJson = (List<TestJSONSerialize>)jsonParser.ReadObject(file);
                foreach(var j in newJson)
                    Console.WriteLine($"Json obj int prop: {j.IntProperty}, str prop: {j.StrProperty}");
            }
            Console.WriteLine("=====================================================\n");



            XmlDocument xml = new XmlDocument();
            xml.Load("port.xml");
            XmlElement element = xml.DocumentElement;
            XmlNodeList xmlList = element.SelectNodes("//shipsArr/Ship[@Carrying]");
            Console.WriteLine("Attribute carrying in Ship elements: ");
            foreach (XmlNode x in xmlList)
                Console.WriteLine(x.SelectSingleNode("@Carrying").Value);

            XmlNode node = element.SelectSingleNode("maxIndex");
            Console.WriteLine("MaxIndex value: " + node.InnerText);
            Console.WriteLine("=====================================================\n");


            XDocument xdoc = new XDocument(new XElement("phones",
                                            new XElement("phone",
                                                new XAttribute("name", "iPhone 6"),
                                                new XElement("company", "Apple")),
                                            new XElement("phone",
                                                new XAttribute("name", "iPhone 7"),
                                                new XElement("company", "Apple")),
                                            new XElement("phone",
                                                new XAttribute("name", "iPhone 8"),
                                                new XElement("company", "Apple")),
                                            new XElement("phone",
                                                new XAttribute("name", "Samsung Galaxy S5"),
                                                new XElement("company", "Samsung"),
                                                new XElement("price", "33000"))));
            xdoc.Save("phones.xml");
            var phones = from xe in xdoc.Element("phones").Elements("phone") where xe.Element("company").Value == "Apple" select xe;
            foreach (XElement el in phones)
                Console.WriteLine($"Name: {el.Attribute("name").Value}, company: {el.Element("company").Value}");
            Console.WriteLine("=====================================================\n");



            //SynchronousSocketListener.StartListening();
            //SynchronousSocketClient.StartClient();
            
        }
    }
}
