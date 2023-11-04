using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Serialization;
using static practos6.Program;

namespace practos6
{
    public class ReadWrite
    {
        static public void ReadTxt(string path)
        {
            string[] clientBase = File.ReadAllLines(path);
            Console.WriteLine(clientBase.Length);
            
            for (int i = 0; i < clientBase.Length; i++)
            {
                string[] temp = clientBase[i].Split('#');
                humans[i].Client = temp[0];
                humans[i].WeekDay = temp[1];
            }
            Print();
        }
        static public void ReadJson(string path)
        {
            string json = File.ReadAllText(path);
            Daisy[] humans = JsonConvert.DeserializeObject<Daisy[]>(json);
            Print();
        }
        static public void ReadXml(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Daisy[]));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                humans = (Daisy[])xml.Deserialize(fs);
            }
            Print();
        }
        static public void WriteTxt(string path)
        {
            CheckFile(path);
            for (int i = 0; i < humans.Length; i++)
            {
                string content = $"{humans[i].Client}#{humans[i].WeekDay}\n";
                File.AppendAllText(path, content);
            }
        }
        static public void WriteJson(string path)
        {
            CheckFile(path);
            string json = JsonConvert.SerializeObject(humans);
            Console.WriteLine(json);
            File.WriteAllText(path, json);
        }
        static public void WriteXml(string path)
        {
            CheckFile(path);
            XmlSerializer xml = new XmlSerializer(typeof(Daisy[]));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, humans);
            }
        }
        static  void CheckFile(string path)
        {
            if (File.Exists(path))
            {
                Console.WriteLine("Файл уже сущесвует!! \n1.Перезаписать\n2.Ввести другой путь");
                switch(Console.ReadLine())
                {
                    case "1": File.Delete(path); break; 
                    case "2": CheckExt(); break;

                }
            }
        }

    }
}

