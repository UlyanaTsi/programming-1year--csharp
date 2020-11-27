using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace sem_1
{
    [Serializable]
    [XmlRoot("Group")]
    public class Group
    {
        private string smth;

        [XmlAttribute]
        public string Name { get; set; }

        [XmlArray("Students")]
        public List<Human> Students { get; set; }
        public Group() { Students = new List<Human>(); }
        public Group(string name, params Student[] students)
        {
            smth = name.Length.ToString();
            Name = name;
            Students = new List<Human>(students);
        }
        public override string ToString() => $"Name: {Name}, Students: {string.Join(", ", Students)}";
    }
}
