using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace xmlserialize
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Group bpi1910 = new Group("BPI1910", new Student("1"), new Student("2"));

            // binary
            using (FileStream fs = new FileStream("serialization.bin", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, bpi1910);
            }

            using (FileStream fs = new FileStream("serialization.bin", FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Group serializedbpi1910 = bf.Deserialize(fs) as Group;
                Console.WriteLine($"Binnary: {serializedbpi1910}");
            }

            // xml
            using (FileStream fs = new FileStream("serialization.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(bpi1910.GetType());
                xmlSerializer.Serialize(fs, bpi1910);
            }

            using (FileStream fs = new FileStream("serialization.bin", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(bpi1910.GetType());
                Group serializedbpi1910 = xmlSerializer.Deserialize(fs) as Group;
                Console.WriteLine($"XML: {serializedbpi1910}");
            }
        }
    }

    [Serializable]
    public class Student
    {
        public string Name { get; }
        public Student() { }
        public Student(string name){ Name = name;}
        public override string ToString() => $"Student: {Name}";
        
    }

    [Serializable]
    public class Group
    {
        public string smth;
        public string Name { get; }
        public Group() { }
        public List<Student> Students { get; } = new List<Student>();
        public Group(string name, params Student[] students)
        {
            smth = name.Length.ToString();
            Name = name;
            Students = new List<Student>(students);
        }
        public override string ToString() => $"Name: {Name}, Students: {string.Join(",", Students)}";
    }
}
