namespace Konvolucio.Cheat
{
    using System.ComponentModel;
    using NUnit.Framework;
    using System.Diagnostics;

    [TestFixture]
    class Colletction_GetChangedPropertyName
    {
        [Test]
        public void _0001_ChangeTest()
        {

            var people = new MockManCollection();
            people.Add(new MockPersonItem("Homer", "Simpson"));
            people.Add(new MockPersonItem("Bart", "Simpson"));
            people.Add(new MockPersonItem("Burns", "Montgomery"));

            people.ListChanged += People_ListChanged;

            people[1].FirstName = "Bart2";
         }


        private void People_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                if (e.PropertyDescriptor != null)
                {
                    var bindingList = sender as IBindingList;
                    if (bindingList != null)
                    {
                        var item = bindingList[e.NewIndex];
                        Debug.WriteLine(
                            "Poroperty Name:" + e.PropertyDescriptor.DisplayName + ", " +
                            "New Value:" + e.PropertyDescriptor.GetValue(item) as string);
                    }
                }
            }
        }

        public class MockManCollection : BindingList<MockPersonItem>
        {
            
        }

        public class MockPersonItem :  INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            public string FirstName
            {
                get { return _firstName; }
                set
                {
                    if (_firstName != value)
                    {
                        _firstName = value;
                        OnPropertyChanged(PropertyPlus.GetPropertyName(() => FirstName));
                    }
                }
            }
            string _firstName;
            public string LastName
            {
                get { return _lastName; }
                set
                {
                    if (_lastName != value)
                    {
                        _lastName = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyPlus.GetPropertyName(() => LastName)));
                    }
                }
            }
            public string _lastName;

            public MockPersonItem(string firstName, string lastName)
            {
                _firstName = firstName;
                _lastName = lastName;
            }

            public void OnPropertyChanged(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
