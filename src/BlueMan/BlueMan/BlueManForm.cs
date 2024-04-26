using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading.Tasks;
using System.Reflection;

namespace BlueMan
{
    public partial class BlueManForm : Form
    {
        readonly string[] soundPaths =
        {
            "BlueMan.Sounds.1.wav",
            "BlueMan.Sounds.2.wav",
            "BlueMan.Sounds.3.wav"
        };

        // constants for mouse window events
        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;

        // import the SendMessage and ReleaseCapture functions from user32.dll
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public BlueManForm()
        {

            InitializeComponent();

        }

        Random random = new Random();

        private void BlueManForm_Load(object sender, EventArgs e)
        {
            TransparencyKey = Color.FromArgb(24, 255, 6);
            TopMost = true;

            int randomSound = random.Next(0, soundPaths.Length);
            DoAction(soundPaths[randomSound]);
        }

        private void BlueManPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private async void DoAction(string sound)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream soundStream = assembly.GetManifestResourceStream(sound);

            int randomEvent = random.Next(0, 1);
            switch (randomEvent)
            {
                case 0:
                    Task.Run(() => TVBounce(random.Next(0, 1) == 1));
                    break;
            }

            using (var player = new System.Media.SoundPlayer(soundStream))
            {
                await Task.Run(() => { player.Load(); player.PlaySync(); });
                Close();
            }
        }

        private void TVBounce(bool getFaster)
        {
            int x = 1;
            int y = 1;
            int speed = 1;
            while (true)
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        Left += x;
                        Top += y;

                        if (Top > 1080)
                        {
                            y = -1 * speed;

                            if (getFaster)
                                speed++;
                        }
                        if (Top < 0)
                        {
                            y = 1 * speed;

                            if (getFaster)
                                speed++;
                        }
                        if (Left > 1920)
                        {
                            x = -1 * speed;

                            if (getFaster)
                                speed++;
                        }
                        if (Left < 0)
                        {
                            x = 1 * speed;

                            if (getFaster)
                                speed++;
                        }
                    });
                }
                catch { }
            }
        }
    }
}