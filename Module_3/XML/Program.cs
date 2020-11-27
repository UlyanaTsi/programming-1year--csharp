using System;
using System.Collections.Generic;
using System.Xml;

/* XML
 *
 *
 */

namespace XML
{
    class Actor
    {
        public string Name { get; set; }
        public string Film { get; set; }
        public string Role { get; set; }

        public override string ToString()
        {
            return $"Имя: {Name}" +
                $"\nФильм: {Film}" +
                $"\nРоль: {Role}\n";
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Actor> actors = new List<Actor>();

            // Создаем объект xmlDoс и загружаем файл
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("users.xml");

            // корневой элемент (users)
            XmlElement xmlElement = xmlDocument.DocumentElement;

            // проход по всем узлам(user)
            foreach(XmlNode xmlNode in xmlElement)
            {
                Actor actor = new Actor();

                if (xmlNode.Attributes.Count != 0)
                {
                    XmlNode atr = xmlNode.Attributes.GetNamedItem("name");
                    if (atr != null)
                        actor.Name = atr.Value;
                }

                foreach(XmlNode child in xmlNode.ChildNodes)
                {
                    if (child.Name == "film")
                        actor.Film = child.InnerText;
                    if (child.Name == "role")
                        actor.Role = child.InnerText;
                }
                actors.Add(actor);
            }

            foreach (Actor act in actors)
                Console.WriteLine((act.ToString()));
        }
    }
}
