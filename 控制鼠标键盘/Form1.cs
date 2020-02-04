using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
        //static void Main(string[] args)
        //{

        //    System.Threading.Thread.Sleep(6 * 1000);

        //    MouseFlag.MouseLeftClickEvent(10, 1000, 0);

        //}
namespace 控制鼠标键盘
{ 
    public partial class Form1 : Form
    {
        public uint timerFlag = 1;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;   
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timerFlag = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (timerFlag)
            {
                case 1: MouseFlag.MouseLeftClickEvent(500, 600, 0);
                        System.Threading.Thread.Sleep(2 * 1000);break;
                case 2: MouseFlag.MouseLeftClickEvent(500, 320, 0);
                        System.Threading.Thread.Sleep(2 * 1000);break;
                case 3: MouseFlag.MouseLeftClickEvent(970, 680, 0);
                        System.Threading.Thread.Sleep(2 * 1000);timerFlag=0;break;
            }
            timerFlag++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timerFlag = 1;
        }
    }

    public class MouseFlag
    {
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }
        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);
        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);
        public static void MouseLeftClickEvent(int dx, int dy, uint data)
        {
            SetCursorPos(dx, dy);
            //System.Threading.Thread.Sleep(2 * 1000);
            mouse_event(MouseEventFlag.LeftDown, dx, dy, data, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, dx, dy, data, UIntPtr.Zero);
        }
        public static void MouseRightClickEvent(int dx, int dy, uint data)
        {
            SetCursorPos(dx, dy);
            //System.Threading.Thread.Sleep(2 * 1000);
            mouse_event(MouseEventFlag.RightDown, dx, dy, data, UIntPtr.Zero);
            mouse_event(MouseEventFlag.RightUp, dx, dy, data, UIntPtr.Zero);
        }
    }
}
