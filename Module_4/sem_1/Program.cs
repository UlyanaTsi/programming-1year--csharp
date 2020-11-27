using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
namespace sem_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Group bpi1910 = new Group("BPI1910", new Student("Beebo"), new Student("Sun"));
            Group otherGroup = new Group("BPI194", new Student("Alex"), new Student("Joy"));
            Group[] groups = { bpi1910, otherGroup };

            // binary
            /* BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream("serialization.bin", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, bpi1910);
            }

            using (FileStream fs = new FileStream("serialization.bin", FileMode.Open, FileAccess.Read))
            {
                Group serializedbpi1910 = bf.Deserialize(fs) as Group;
                Console.WriteLine($"Binnary: {serializedbpi1910}");
            }

            using (FileStream fs = new FileStream("serialization2.bin", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, groups);
            }

            using (FileStream fs = new FileStream("serialization2.bin", FileMode.Open, FileAccess.Read))
            {
                Group[] deserGroups = bf.Deserialize(fs) as Group[];
                foreach (var group in deserGroups)
                {
                    Console.WriteLine($"Binnary array: {group}");
                }
            }
            */
            // xml

            using (FileStream fs = new FileStream("serialization.xml", FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(bpi1910.GetType());
                xmlSerializer.Serialize(fs, bpi1910);
            }

            using (FileStream fs = new FileStream("serialization.xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(bpi1910.GetType());
                Group serializedbpi1910 = xmlSerializer.Deserialize(fs) as Group;
                Console.WriteLine($"XML: {serializedbpi1910}");
            }

            // json
            /*
            var options = new JsonSerializerOptions
            {
                WriteIndented = true

            };

            using (StreamWriter fs = new StreamWriter("serialization.json"))
            {
                //using System.Text.Json;
                string serialized = System.Text.Json.JsonSerializer.Serialize(bpi1910, options);
                fs.WriteLine(serialized);
                Console.WriteLine(serialized);
            }

            using (StreamReader fs = new StreamReader("serialization.json"))
            {
                //using System.Text.Json;
                string serialized = fs.ReadToEnd();
                Group serializedBpi1910 = System.Text.Json.JsonSerializer.Deserialize<Group>(serialized);
                Console.WriteLine($"JsonSer : {serializedBpi1910}");
            }

            //json2

            using (JsonWriter fs = new JsonTextWriter(new StreamWriter("ns_serialization.json")))
            {
                //using Newtonsoft.Json;
                Newtonsoft.Json.JsonSerializer jsonSerializer = new Newtonsoft.Json.JsonSerializer();
                jsonSerializer.Serialize(fs, bpi1910);
            }

            using (JsonReader fs = new JsonTextReader(new StreamReader("ns_serialization.json")))
            {
                //using Newtonsoft.Json;
                Newtonsoft.Json.JsonSerializer jsonSerializer = new Newtonsoft.Json.JsonSerializer();
                Group serializedBpi1910 = jsonSerializer.Deserialize(fs, typeof(Group)) as Group;
                Console.WriteLine($"NsJsonSer : {serializedBpi1910}");
            }
            */
        }
    }
}
