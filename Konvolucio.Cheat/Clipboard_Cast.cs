namespace Konvolucio.Cheat
{
    using System;   
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using NUnit.Framework;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class UintTest_Cast
    {
        [Serializable]
        class MockPersonItem : ICloneable
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public object Clone()
            {
                return new MockPersonItem() { FirstName = this.FirstName, LastName = this.LastName, Age = this.Age };
            }
        }

        class MockPersonCollection : BindingList<MockPersonItem>
        {

        }



        [Test]
        [STAThread]
        public void _0003_()
        {
            System.Windows.Forms.Clipboard.Clear();

            var data = new DataObject();

            var sourcePersonItem = new MockPersonCollection()
            {
                new MockPersonItem(){FirstName= "Homer", LastName = "Simpson", Age = 40},
                new MockPersonItem(){FirstName= "Bart", LastName = "Simpson", Age = 10},
                new MockPersonItem(){FirstName= "Lisa", LastName = "Simpson", Age = 15},
            };

            data.SetData(typeof(MockPersonItem), sourcePersonItem[0]);
            System.Windows.Forms.Clipboard.SetDataObject(data);
            Assert.IsTrue(typeof(MockPersonItem).IsSerializable);

            var retviredDataObj = System.Windows.Forms.Clipboard.GetDataObject();
            Assert.IsTrue(retviredDataObj != null);

            Assert.IsTrue(retviredDataObj.GetDataPresent(typeof(MockPersonItem)));
            var person = retviredDataObj.GetData(typeof(MockPersonItem)) as MockPersonItem;
            Assert.AreEqual("Homer", person.FirstName);

        }

        [Test]
        [STAThread]
        public void _0004_()
        {
            System.Windows.Forms.Clipboard.Clear();
            var data = new DataObject();
            var items = new MockPersonCollection()
            {
                new MockPersonItem(){FirstName= "Homer", LastName = "Simpson", Age = 40},
                new MockPersonItem(){FirstName= "Bart", LastName = "Simpson", Age = 10},
                new MockPersonItem(){FirstName= "Lisa", LastName = "Simpson", Age = 15},
            };


            var objects = new object[items.Count];

            for (var i = 0; i < items.Count; i++)
                objects[i] = ((ICloneable)items[i]).Clone();


            data.SetData(typeof(object[]), objects);
            System.Windows.Forms.Clipboard.SetDataObject(data);
            Assert.IsTrue(typeof(object[]).IsSerializable);

            var retviredDataObj = System.Windows.Forms.Clipboard.GetDataObject();
            Assert.IsTrue(retviredDataObj != null);

            Assert.IsTrue(retviredDataObj.GetDataPresent(typeof(object[])));
            var retvireArray = retviredDataObj.GetData(typeof(object[]));

            var target = new MockPersonCollection();

            foreach (var item in (Array)retvireArray)
            {
               var person = item;
               if(person!=null)
                    ((IBindingList)target).Add(person);
            }
        }
    }
}
