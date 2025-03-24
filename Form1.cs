using System.Runtime.InteropServices;


namespace TeamsEnemy
{
    public partial class Form1 : Form
    {
        // Import the mouse_event function from user32.dll
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        // Define constants for mouse event types
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;

        private System.Windows.Forms.Timer moveCursorTimer;
        private bool moveRight;
        private int moveDistance = 100; // Distance to move the cursor
        public Form1()
        {
            InitializeComponent();

            // Initialize the Timer
            moveCursorTimer = new System.Windows.Forms.Timer();
            moveCursorTimer.Interval = 5000; // 5 seconds
            moveCursorTimer.Tick += MoveCursorTimer_Tick;

            moveRight = true; // Initially, move the cursor to the right
        }

        // Method to simulate a mouse click
        private void SimulateClick()
        {
            // Simulate left mouse button down and up (click)
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private void MoveCursorTimer_Tick(object? sender, EventArgs e)
        {
            // Get the current cursor position
            Point currentPosition = Cursor.Position;

            // Calculate the new position
            if (moveRight)
            {
                Cursor.Position = new Point(currentPosition.X + moveDistance, currentPosition.Y);
            }
            else
            {
                Cursor.Position = new Point(currentPosition.X - moveDistance, currentPosition.Y);
            }

            // Simulate a left mouse click
            SimulateClick();

            // Toggle direction
            moveRight = !moveRight;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            moveCursorTimer.Start(); // Start the timer
            toolStripStatusLabel1.Text = "Started";
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            moveCursorTimer.Stop(); // Stop the timer
            toolStripStatusLabel1.Text = "Stopped";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Panagiotis Fragos (c) 2025 - .NET (Core) 8.0", "About Teams Enemy");
        }
    }
}
