using System;
using System.Windows.Forms;
using System.Threading;  // For Timer
using System.Diagnostics; // To execute the sleep command

namespace sleepmy
{
    public partial class Form1 : Form
    {
        private System.Threading.Timer sleepTimer;  // Timer to handle the delay
        private int timeInSeconds;  // Store the time in seconds

        public Form1()
        {
            InitializeComponent();
        }

        // Button click event to set the sleep timer
        private void button1_Click(object sender, EventArgs e)
        {
            // Try to parse the input time from the TextBox to an integer (minutes)
            if (int.TryParse(textBox1.Text, out int timeInMinutes) && timeInMinutes > 0)
            {
                // Convert the minutes to seconds
                timeInSeconds = timeInMinutes * 60;

                // Display a message to inform the user of the set time
                lblMessage.Text = $"Laptop will sleep in {timeInMinutes} minute(s).";

                // Set a timer that will trigger the SleepTimerCallback after the specified time
                sleepTimer = new System.Threading.Timer(SleepTimerCallback, null, timeInSeconds * 1000, Timeout.Infinite);
            }
            else
            {
                // Show an error message if the input is invalid
                MessageBox.Show("Please enter a valid time in minutes.");
            }
        }

        // Callback function that is called when the timer finishes
        private void SleepTimerCallback(object state)
        {
            // Use the shutdown command to put the system into hibernation (sleep)
            Process.Start("shutdown", "/h");

            // Update the label to show that the laptop is going to sleep
            lblMessage.Invoke((MethodInvoker)(() => lblMessage.Text = "Laptop is going to sleep now."));
        }
    }
}
