using System;

namespace sem_1
{
    [Serializable]
    public class Student : Human
    {
        public Student() : base() { }
        public Student(string name) : base(name) { }
        public override string ToString() => $"Student: {Name}";

    }
}
