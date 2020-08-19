

namespace Konvolucio.Cheat
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using NUnit.Framework;
    using System.Windows.Forms;

    [TestFixture]
    class Collection_Array_Init
    {
        public void ArrayInit()
        {

            string[] strAr = new string[] { "Hello", "World" };
            string[] strAr2 = { "Hello", "World" };

      

            new ContextMenuStrip().Items.AddRange( new ToolStripItem[] { new ToolStripMenuItem(), new ToolStripMenuItem()}  );
           // new ContextMenuStrip().Items.AddRange({ new ToolStripMenuItem(), new ToolStripMenuItem()});

            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.AddRange(
                    new ToolStripItem[]
                    {
                        new ToolStripMenuItem(),
                        new ToolStripMenuItem()
                    });

            cms.Items.AddRange(
            new ToolStripItem[]
            {
                            new ToolStripMenuItem(),
                            new ToolStripMenuItem()
            });
        }
    }
}
