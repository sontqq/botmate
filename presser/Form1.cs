using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Windows.Forms.Timer;
using System.Windows.Forms;
using WindowsInput;
using System.Timers;
//using Magic;
using System.Security.Principal;


namespace presser
{
    /*public static*/

    public partial class Form1 : Form
    {
        // [DllImport("user32.dll")]
        // static extern IntPtr FindWindow(string windowClass, string windowName);

        [DllImport("user32.dll")]
        static extern short VkKeyScan(char ch);

        [DllImport("user32.dll")]
        static extern int MapVirtualKey(int uCode, uint uMapType);

        [DllImport("user32.dll")]
        static extern bool SetWindowText(IntPtr hWnd, string text);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, IntPtr Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool PostS(IntPtr hWnd, String Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr dc);

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int WM_APPCOMMAND = 0x319;


        //System.Timers.Timer aTimer = new System.Timers.Timer();
        //System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        System.Timers.Timer aTimer = new System.Timers.Timer();
        System.Windows.Forms.Timer timer;

        Stopwatch stopwatch = new Stopwatch();
        
        public uint counter = 0;
        public string actual;

        public static string windowName = "BOT";
        public static bool forogjon = true;

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        const int WM_SYSKEYDOWN = 0x0104;
        const int WM_SYSKEYUP = 0x0105;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_CHAR = 0x102;
        const int WM_SYSCHAR = 0x106;
        const int WM_IME_CHAR = 0x286;

        const int W = 0x57;
        const int A = 0x41;
        const int S = 0x53;
        const int D = 0x44;
        const int TAB = 0x09;
        const int E = 0x45;

        const int Q = 0x51;
        const int R = 0x52;
        const int X = 0x58;
        const int C = 0x43;
        const int G = 0x47;

        const int one = 0x31;
        const int two = 0x32;
        const int three = 0x33;
        const int four = 0x34;
        const int five = 0x35;
        const int six = 0x36;
        const int seven = 0x37;
        const int eight = 0x38;
        const int nine = 0x39;
        const int zero = 0x30;
    
        public Form1()
        {
            InitializeComponent();
        }
        public int ConvertX(char character) {
            switch (character)
            {
                case 'a':
                    return 0x41;
                case 'b':
                    return 0x42;
                case 'c':
                    return 0x43;
                case 'd':
                    return 0x44;
                case 'e':
                    return 0x45;
                case 'f':
                    return 0x46;
                case 'g':
                    return 0x47;
                case 'h':
                    return 0x48;
                case 'i':
                    return 0x49;
                case 'j':
                    return 0x4A;
                case 'k':
                    return 0x4B;
                case 'l':
                    return 0x4C;
                case 'm':
                    return 0x4D;
                case 'n':
                    return 0x4E;
                case 'o':
                    return 0x4F;
                case 'p':
                    return 0x50;
                case 'q':
                    return 0x51;
                case 'r':
                    return 0x52;
                case 's':
                    return 0x53;
                case 't':
                    return 0x54;
                case 'u':
                    return 0x55;
                case 'v':
                    return 0x56;
                case 'w':
                    return 0x57;
                case 'x':
                    return 0x58;
                case 'y':
                    return 0x59;
                case 'z':
                    return 0x5A;
                case '1':
                    return 0x31;
                case '2':
                    return 0x32;
                case '3':
                    return 0x33;
                case '4':
                    return 0x34;
                case '5':
                    return 0x35;
                case '6':
                    return 0x36;
                case '7':
                    return 0x37;
                case '8':
                    return 0x38;
                case '9':
                    return 0x39;
                case '0':
                    return 0x30;
                default:
                    return 0x20; // SPACE
            }
        }

        public void DoMouseClick()
        {
            /*
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            */
            
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 555, 339, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 548, 437, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 665, 355, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 694, 443, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 637, 382, 0, 0);
        }

        public void DoLoopMouse()
        {
            const int row = 30;
            const int column = 10;
            int[,] array = new int[row, column];

            for (int i = 504; i < 720; i++)
            {
                for (int j = 288; j < 504; j++)
                {

                }
            }
        }

        void OnTimedEvent(object source, ElapsedEventArgs e){
            counter++;
            IntPtr WindowToFind = FindWindow(null, textBox2.Text);
            forog();
            /*
            BlackMagic wow = new BlackMagic();
            try
            {
                IntPtr basewow = wow.MainModule.BaseAddress;
                wow.OpenProcessAndThread(SProcess.GetProcessFromWindowTitle("BOT"));
                float playerx = wow.ReadFloat((uint)basewow + 0x74);
                float playery = wow.ReadFloat((uint)basewow + 0x78);
                float playerz = wow.ReadFloat((uint)basewow + 0x7C);
                label8.Text = "x: " + playerx.ToString() + " y: " + playery.ToString() + " z: " + playerz.ToString();
            }
            catch (Exception ex) {
                label8.Text = ex.Message;
            }
            */
            foreach (var g in textBox3.Text)
            {
                // / jelre egyeb
                char KEY = g;
                actual = KEY.ToString();
                if (g == '+')
                {
                    Thread.Sleep(500);
                }
                if (g == '-')
                {
                    PostMessage(WindowToFind, (IntPtr)WM_SYSKEYDOWN, (IntPtr)TAB, IntPtr.Zero);
                    PostMessage(WindowToFind, (IntPtr)WM_SYSKEYUP, (IntPtr)TAB, IntPtr.Zero);
                }
                else
                {
                    PostMessage(WindowToFind, (IntPtr)WM_SYSKEYDOWN, (IntPtr)KEY, IntPtr.Zero);
                    PostMessage(WindowToFind, (IntPtr)WM_SYSKEYUP, (IntPtr)KEY, IntPtr.Zero);
                    // DEFAULT WAIT
                    Thread.Sleep(300);
                }
            }
            Thread.Sleep(300);
            if (checkBox2.Checked == true)
            {
                DoMouseClick();
            }
        }
        /*
        public void hack() {
            // CTM 0xD0F390
            BlackMagic wow = new BlackMagic();
            IntPtr WindowToFind = FindWindow(null, windowName);
            try
            {
                IntPtr basewow = wow.MainModule.BaseAddress;
                wow.OpenProcessAndThread(SProcess.GetProcessFromWindowTitle("BOT"));
                var name = wow.ReadASCIIString((uint)basewow + 0xEC4668, 256);
                var islooting = wow.ReadByte((uint)basewow + 0xDD3D44);
            
                var asd = wow.ReadASCIIString((uint)basewow + 0xDD3D44, 256);
                var x = wow.ReadASCIIString((uint)basewow + 0xEC47F1, 256);
                var y = wow.ReadASCIIString((uint)basewow + 0xD0F390, 256);
                var z = wow.ReadASCIIString((uint)basewow + 0x1274FE4, 256);
            
                float playerx = wow.ReadFloat((uint)basewow + 0x74);
                float playery = wow.ReadFloat((uint)basewow + 0x78);
                float playerz = wow.ReadFloat((uint)basewow + 0x7C);
                MessageBox.Show(z.ToString());
            }
            catch (Exception ex) { }
        }*/

        public void draw()
        {

        }

        public void pull() {
            actual = "PULL";
            IntPtr WindowToFind = FindWindow(null, windowName);
            PostMessage(WindowToFind, (IntPtr)WM_SYSKEYDOWN, (IntPtr)TAB, IntPtr.Zero);
            PostMessage(WindowToFind, (IntPtr)WM_SYSKEYUP, (IntPtr)TAB, IntPtr.Zero);
            PostMessage(WindowToFind, (IntPtr)WM_SYSKEYDOWN, (IntPtr)X, IntPtr.Zero);
            PostMessage(WindowToFind, (IntPtr)WM_SYSKEYUP, (IntPtr)X, IntPtr.Zero);
        }
        public void forog() {
            if (checkBox1.Checked == true)
            {
                if (checkBox2.Checked == true)
                {
                    DoMouseClick();
                }
                // BALRA 90 - JOBBRA 180
                actual = "FOROG";
                IntPtr WindowToFind = FindWindow(null, windowName);
                PostMessage(WindowToFind, (IntPtr)WM_SYSKEYDOWN, (IntPtr)A, IntPtr.Zero);
                Thread.Sleep(500);
                PostMessage(WindowToFind, (IntPtr)WM_SYSKEYUP, (IntPtr)A, IntPtr.Zero);
                //pull();
                PostMessage(WindowToFind, (IntPtr)WM_SYSKEYDOWN, (IntPtr)D, IntPtr.Zero);
                Thread.Sleep(800);
                PostMessage(WindowToFind, (IntPtr)WM_SYSKEYUP, (IntPtr)D, IntPtr.Zero);
            }
        }
        public void shot() {
            IntPtr WindowToFind = FindWindow(null, windowName);
            Thread.Sleep(1000);
        }
        private void button1_Click(object sender, EventArgs e)
        {
           // System.Timers.Timer aTimer = new System.Timers.Timer();
           // System.Windows.Forms.Timer timer;

            actual = "STARTED";
            stopwatch.Start();

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
             
            timer = new System.Windows.Forms.Timer();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            button1.Enabled = false;
            button2.Enabled = true;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            label1.Text = "Cycle: " + counter.ToString();
            label5.Text = "Elapsed: " + stopwatch.Elapsed.ToString();
            if(actual != null)
                label6.Text = actual.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actual = "STOPPED";
            aTimer.Enabled = false;
            timer.Stop();
            timer.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = false;
            timer.Dispose();
            aTimer.Dispose();
            counter = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool isElevated;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            if (isElevated == false)
                //MessageBox.Show("Please run with Administrator rights!");
            // NEMITAS A CSIPOGAS ELLEN
            // SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
            stopwatch.Stop();
            button2.Enabled = false;
            // DEFAULT SPELLQUEUE
            textBox3.Text = "-RRR-12E-3QR-4T-G0RX87";
           // textBox3.Text = "-01201201201245677889";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeName(findHwnd(textBox1.Text), textBox2.Text);

            IntPtr findHwnd(String wName) {
            IntPtr hWnd = IntPtr.Zero;
            foreach (Process pList in Process.GetProcesses())
            {
                if (pList.MainWindowTitle.Contains(wName))
                {
                    hWnd = pList.MainWindowHandle;
                }
            }
            return hWnd;
            }
        }
        void changeName(IntPtr handle, string name)
        {
            SetWindowText(handle, name);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // hack();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            windowName = textBox2.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            forogjon = checkBox1.Checked;
        }
    }

   

}
