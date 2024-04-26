using System;
using System.Timers;
using System.Windows.Forms;

namespace BlueMan
{
    public partial class MainForm : Form
    {
        System.Timers.Timer blueManTimer = new System.Timers.Timer();

        public MainForm()
        {
            InitializeComponent();
            Opacity = 0;
            ShowInTaskbar = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            blueManTimer.Elapsed += new ElapsedEventHandler(ShowBlueMan);
            blueManTimer.Interval = 1;
            blueManTimer.Enabled = true;
            
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var crpa = base.CreateParams;
                crpa.ExStyle |= 0x80;
                return crpa;
            }
        }

        private void ShowBlueMan(object source, ElapsedEventArgs e)
        {
            Random random = new Random();
            int randomTime = random.Next(1000, 5000);
            
            blueManTimer.Interval = randomTime;
            blueManTimer.Enabled = false;


            BlueManForm blueManForm = new BlueManForm();
            blueManForm.ShowDialog();
            blueManTimer.Enabled = true;
        }
        
    }
}