using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;

namespace Konvolucio.Cheat
{
    [TestFixture]
    class Method_Action_Func_Lambda
    {
        /// <summary>
        /// (input-parameters) => expression
        /// </summary>
        [Test]
        public void Lambda_Expression_Action()
        {
            Action action = () => Debug.WriteLine("Hello Wrold from Action");
            action();
        }

        /// <summary>
        /// (input-parameters) => expression
        /// </summary>
        [Test]
        public void Lambda_Expression_Func()
        {
            Func<string> func = () => 
            {
                Debug.WriteLine("Hello Wrold from Action"); return "A";
            };
            func();
        }

        /// <summary>
        /// (input-parameters) => expression
        /// </summary>
        [Test]
        public void Lambda_Expression_Func2()
        {
            Func<int, int, bool> testForEquality = (x, y) => x == y;
            if (testForEquality(1, 2))
                Debug.WriteLine("Egyendlo");
            else
                Debug.WriteLine("Nem egyenlo");

        }
    }
}
