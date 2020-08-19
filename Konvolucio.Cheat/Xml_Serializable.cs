namespace Konvolucio.Cheat
{
    using System;   
    using System.ComponentModel;
    using System.IO;
    using System.Xml.Serialization;
    using NUnit.Framework;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class Xml_Serializable
    {
        string pth = @"D:\test.xml";

        public class MockPersonItem : ICloneable
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public object Clone()
            {
                return new MockPersonItem() { FirstName = this.FirstName, LastName = this.LastName, Age = this.Age };
            }

            public override string ToString()
            {
                return FirstName + " " + LastName;
            }
        }
        public class MockPersonCollection : BindingList<MockPersonItem> { }

        public class MockCarItem
        {
            public string Type { get; set; }
            public string Color { get; set; }
            public MockCarItem() { }
            public MockCarItem(string type, string color)
            {
                Type = type;
                Color = color;
            }
            public override string ToString()
            {
                return Type + " " + Color;
            }
        }

        public class MockCarCollection : BindingList<MockCarItem> { }



        public class MockStorage
        {
            public UniCollection UniCollection { get; set; }

            public MockStorage()
            {
                UniCollection = new UniCollection();
            }
        }


        public class UniCollection : BindingList<object> { }

        public class MockManager
        {
            const string XmlRootElement = "mcanxProject";
            const string XmlNamespace = @"http://www.konvolucio.hu/mcanx/2016/project/content";

            private static Type[] SupportedTypes
            {
                get
                {
                    return new Type[]
                    {
                        typeof(string),
                        typeof(MockStorage),
                        typeof(MockPersonCollection),
                        typeof(MockCarItem),
                        typeof(MockCarCollection),
                        typeof(MockPersonItem),
                    };
                }
            }

            static MockStorage _instance = new MockStorage();
            public static MockStorage Instance { get => _instance; }

            #region SaveLoad
            public static void SaveToFile(string path)
            {
                var xmlFormat = new XmlSerializer(typeof(MockStorage), null, SupportedTypes, new XmlRootAttribute(XmlRootElement), XmlNamespace);
                using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xmlFormat.Serialize(fStream, Instance);
                }
            }

            public static void LoadFromFile(string path)
            {
                var xmlFormat = new XmlSerializer(typeof(MockStorage), null, SupportedTypes, new XmlRootAttribute(XmlRootElement), XmlNamespace);
                MockStorage instance;
                using (Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    instance = (MockStorage)xmlFormat.Deserialize(fStream);
                Instance.UniCollection.Clear();
                foreach (object item in instance.UniCollection)
                    Instance.UniCollection.Add(item);
            }
        }

        #endregion

        [Test]
        public void SaveAndLoad()
        {
            var persons = new MockPersonCollection()
            {

                new MockPersonItem() {FirstName = "Homer", LastName = "Simpson", Age = 20},
                new MockPersonItem() {FirstName = "Bart", LastName = "Simpson", Age = 20},
                new MockPersonItem() {FirstName = "Lisa", LastName = "Simposn", Age = 25}
            };

            var cars = new MockCarCollection()
            {
                new MockCarItem("Suzuki", "Orage"),
                new MockCarItem("BMW", "Black"),
                new MockCarItem("Audi", "Green")
            };

            foreach (var item in persons)
                MockManager.Instance.UniCollection.Add(item);

            foreach (var item in cars)
                MockManager.Instance.UniCollection.Add(item);

            MockManager.SaveToFile(pth);

             MockManager.LoadFromFile(pth);
        }

        [Test]
        public void LoadOnly()
        {
            MockManager.LoadFromFile(pth);
            Assert.AreEqual(6, MockManager.Instance.UniCollection.Count);
        }
    }
}
