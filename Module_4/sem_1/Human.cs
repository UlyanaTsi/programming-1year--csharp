using System;
using System.Xml.Serialization;

namespace sem_1
{
    [Serializable]
    [XmlInclude(typeof(Student))]
    public class Human
    {
        public string Name { get; set; }
        public Human() { }
        public Human(string name) { Name = name; }
        public override string ToString()
        {
            return $"Human {Name}";
        }
    }
}
