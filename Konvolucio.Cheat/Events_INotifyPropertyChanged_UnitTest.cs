namespace Konvolucio.Cheat
{
    using System.ComponentModel;
    using NUnit.Framework;
    using System.Diagnostics;

    [TestFixture]
    class Events_INotifyPropertyChanged_UnitTest
    {
        [Test]
        public void _0001_ChangeTest()
        {
            var instance = new MockDerivedClass();
            instance.PropertyChanged += (sender, e) =>
                 Debug.WriteLine("Changed PropName:" + e.PropertyName);
            instance.FirstName = "Homer";
            instance.LastName = "Simpson";
            instance.FirstName = "Bart";
            instance.LastName = "Simpson";
            /*Changed PropName:FirstName
             *Changed PropName:LastName
             *Changed PropName:FirstName*/
        }

        public class MockBaseItemClass
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class MockDerivedClass : MockBaseItemClass, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            public new string FirstName
            {
                get { return base.FirstName; }
                set
                {
                    if (base.FirstName != value)
                    {
                        base.FirstName = value;
                        OnPropertyChanged(PropertyPlus.GetPropertyName(() => FirstName));
                    }
                }
            }
            public new string LastName
            {
                get { return base.LastName; }
                set
                {
                    if (base.LastName != value)
                    {
                        base.LastName = value;
                        OnPropertyChanged(PropertyPlus.GetPropertyName(() => LastName));
                    }
                }
            }
            public void OnPropertyChanged(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }


    }
}
