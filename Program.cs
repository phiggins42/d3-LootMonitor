using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LootAlert
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Settings.load();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LootAlert());
            Settings.save();

            if (d3.Initialized)
                d3.ResetMemory();
        }
    }
}
