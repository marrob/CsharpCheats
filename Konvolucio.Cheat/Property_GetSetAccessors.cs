using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konvolucio.Cheat
{
    class Property_GetSetAccessors
    {
        class TimePeriod_OldStyle
        {
            private double _seconds;

            public double Seconds
            {
                get { return _seconds; }
                set { _seconds = value; }
            }
        }

        class TimePeriod_NewStyle
        {
            private double _seconds;

            public double Seconds
            {
                get => _seconds;
                set => _seconds = value;
            }
        }
    }
}
