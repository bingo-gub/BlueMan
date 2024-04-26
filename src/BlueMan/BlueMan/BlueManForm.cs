using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void BlueManForm_Load(object sender, EventArgs e)
        {
            TransparencyKey = Color.FromArgb(24, 255, 6);
            TopMost = true;

            Random random = new Random();
            int randomSound = random.Next(0, soundPaths.Length);
            PlaySound(soundPaths[randomSound]);


        }

        private void BlueManPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private async void PlaySound(string sound)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream soundStream = assembly.GetManifestResourceStream(sound);

            using (var player = new System.Media.SoundPlayer(soundStream))
            {
                await Task.Run(() => { player.Load(); player.PlaySync(); });
                Close();
            }
        }
    }
}
