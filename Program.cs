using System;
using System.Windows.Forms;

namespace sleepmy
{
    static class Program
    {
        // Main entry point for the application
        [STAThread]
        static void Main()
        {
            // Enables visual styles for the application
            Application.EnableVisualStyles();
            // Set text rendering to be compatible with the modern standards
            Application.SetCompatibleTextRenderingDefault(false);
            // Run the main form of the application
            Application.Run(new Form1());  // Form1 is the main form of your app
        }
    }
}
