using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;
using System.Linq;
using System.IO;
using System.Collections;

namespace OOP_Lab14
{
    static public class CustomSerializer
    {
        public static void TestSerializing(Test test)
        {
            BinaryFormatter BINmatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("D:\\ExtendedData\\Laboratory\\ООТПиСП\\Labl14\\OOP_Lab14\\OOP_Lab14\\test.dat", FileMode.OpenOrCreate))
            {
                BINmatter.Serialize(fs, test);
            }
            using (FileStream fs = new FileStream("D:\\ExtendedData\\Laboratory\\ООТПиСП\\Labl14\\OOP_Lab14\\OOP_Lab14\\test.dat", FileMode.OpenOrCreate))
            {
                Test answer = BINmatter.Deserialize(fs) as Test;
                Console.WriteLine(answer.ToString());
            }

            XmlSerializer XMLmatter = new XmlSerializer(typeof(Test));
            using (FileStream fx = new FileStream("D:\\ExtendedData\\Laboratory\\ООТПиСП\\Labl14\\OOP_Lab14\\OOP_Lab14\\test.xml", FileMode.OpenOrCreate))
            {
                XMLmatter.Serialize(fx, test);
            }
            using (FileStream fx = new FileStream("D:\\ExtendedData\\Laboratory\\ООТПиСП\\Labl14\\OOP_Lab14\\OOP_Lab14\\test.xml", FileMode.OpenOrCreate))
            {
                Test answer = XMLmatter.Deserialize(fx) as Test;
                Console.WriteLine(answer.ToString());
            }

            DataContractJsonSerializer Jmatter = new DataContractJsonSerializer(typeof(Test));
            using (FileStream fj = new FileStream("D:\\ExtendedData\\Laboratory\\ООТПиСП\\Labl14\\OOP_Lab14\\OOP_Lab14\\test.json", FileMode.OpenOrCreate))
            {
                Jmatter.WriteObject(fj, test);
            }
            using (FileStream fj = new FileStream("D:\\ExtendedData\\Laboratory\\ООТПиСП\\Labl14\\OOP_Lab14\\OOP_Lab14\\test.json", FileMode.OpenOrCreate))
            {
                Test answer = Jmatter.ReadObject(fj) as Test;
                Console.WriteLine(answer.ToString());
            }
        }
        public static void TestSerializing(ArrayList test)
        {
            XmlSerializer XMLmatter = new XmlSerializer(typeof(ArrayList));
            using (FileStream fx = new FileStream("D:\\ExtendedData\\Laboratory\\ООТПиСП\\Labl14\\OOP_Lab14\\OOP_Lab14\\arr.xml", FileMode.OpenOrCreate))
            {
                XMLmatter.Serialize(fx, test);
            }
            using (FileStream fx = new FileStream("D:\\ExtendedData\\Laboratory\\ООТПиСП\\Labl14\\OOP_Lab14\\OOP_Lab14\\arr.xml", FileMode.OpenOrCreate))
            {
                ArrayList answer = XMLmatter.Deserialize(fx) as ArrayList;
                foreach (var a in answer)
                    Console.WriteLine(a.ToString());
            }
        }
        public static void TestSerializing(One test)
        {
            XmlSerializer XMLmatter = new XmlSerializer(typeof(One));
            using (FileStream fx = new FileStream("D:\\ExtendedData\\Laboratory\\ООТПиСП\\Labl14\\OOP_Lab14\\OOP_Lab14\\one.xml", FileMode.OpenOrCreate))
            {
                XMLmatter.Serialize(fx, test);
            }
        }
        public static void XMLQuery(One t)
        {
            TestSerializing(t);
            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\ExtendedData\\Laboratory\\ООТПиСП\\Labl14\\OOP_Lab14\\OOP_Lab14\\one.xml");
            XmlElement root = doc.DocumentElement;
            XmlNodeList child1 = root.SelectNodes("//Two");
            XmlNodeList child2 = root.SelectNodes("//Three[num='4']");
            foreach (XmlNode c1 in child1)
                Console.WriteLine(c1.OuterXml);
            foreach (XmlNode c2 in child2)
                Console.WriteLine(c2.OuterXml);
        }
        public static void XMLLINQ()
        {
            XDocument doc = XDocument.Load("D:\\ExtendedData\\Laboratory\\ООТПиСП\\Labl14\\OOP_Lab14\\OOP_Lab14\\book.xml");
            var buks1 = from x1 in doc.Element("Books").Elements("Book")
                        where x1.Element("author").Value == "Volkov"
                        select new Book
                        {
                            name = x1.Attribute("name").Value,
                            price = x1.Element("price").Value
                        };
            foreach (var buk in buks1)
                Console.WriteLine($"{buk.name} - {buk.price}");
            Console.WriteLine("---");
            var buks2 = from x2 in doc.Element("Books").Elements("Book")
                        orderby x2.Element("price").Value descending
                        select new Book
                        {
                            name = x2.Attribute("name").Value,
                            price = x2.Element("price").Value
                        };
            foreach (var buk in buks2)
                Console.WriteLine($"{buk.name} - {buk.price}");
        }
    }
    [Serializable]
    public abstract class Quest
    {
        public readonly int numberOfTries = 1;
        public int numberOfQuestions = 0;
        public abstract bool Result();
        public override string ToString()
        {
            string str = "";
            str += numberOfTries;
            return str;
        }
    }
    [Serializable]
    public class Test : Quest
    {
        public bool isHard;
        [NonSerialized]
        static int one = 1;
        public Test(bool f)
        {
            f = true ? isHard = true : isHard = false;
        }
        public Test()
        {
            isHard = false;
        }
        public override bool Result()
        {
            if (this.isHard == false)
                return true;
            else
                return false;
        }
        public class Question
        {
            static int numberOfAnswers = 1;
            string[] answers = new string[numberOfAnswers];
        }
        public override string ToString()
        {
            string str = "";
            str += numberOfTries + "--->" + isHard;
            return str;
        }
    }

    [Serializable]
    public class One
    {
        
        public Two[] two;
        int counter;
        public One()
        {
            counter = 0;
            two = new Two[5];
        }
        public One(int i)
        {
            counter = 0;
            two = new Two[i];
        }
        public void Add(Two t)
        {
            if (counter < 5)
                two[counter] = t;
            ++counter;
        }
    }
    public class Two
    {
        public Three[] three;
        int counter;
        public Two()
        {
            counter = 0;
            three = new Three[4];
        }
        public void Add(Three t)
        {
            if (counter < 5)
                three[counter] = t;
            ++counter;
        }
    }
    public class Three
    {
        public int num;
        public Three(int n)
        {
            num = n;
        }
        public Three()
        {
            num = 1;
        }
    }

    [Serializable]
    public class Book
    {
        public string name;
        public string price;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test boy1 = new Test(true);
            CustomSerializer.TestSerializing(boy1);//задание 1
            Console.WriteLine("--------");

            ArrayList boy2 = new ArrayList();
            boy2.Add(18);
            boy2.Add("1&8");
            boy2.Add(1.8);
            CustomSerializer.TestSerializing(boy2);//задание 2
            Console.WriteLine("--------");

            One o = new One(2);
            Two t1 = new Two();
            t1.Add(new Three(15));
            t1.Add(new Three(4));
            t1.Add(new Three(-12));
            Two t2 = new Two();
            t2.Add(new Three(0));
            t2.Add(new Three(4));
            o.Add(t1);
            o.Add(t2);
            CustomSerializer.XMLQuery(o);//задание 3
            Console.WriteLine("--------");
            CustomSerializer.XMLLINQ();//задание 4
        }
    }
}
