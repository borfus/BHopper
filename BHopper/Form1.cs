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
using System.Threading;

namespace BHopper
{
    public partial class Form1 : Form
    {
        int addressLocalPlayer;
        int offsetFlags;
        int addressJump;

        string process = "csgo";
        int client;

        bool enabled = false;

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetAsyncKeyState(int vKey);

        public Form1()
        {
            InitializeComponent();
            prgJumping.Style = ProgressBarStyle.Continuous;
        }

        private void btnEnabled_MouseClick(object sender, MouseEventArgs e)
        {
            if (!enabled)
            {
                enabled = true;
                btnEnabled.Text = "Disable";
                prgJumping.Value = 100;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.CancelAsync();
                }
                enabled = false;
                btnEnabled.Text = "Enable";
                prgJumping.Value = 0;
            }
            this.ActiveControl = null;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true && enabled)
            {
                while (GetAsyncKeyState(32) < 0)
                {
                    if (prgJumping.ForeColor != Color.Green)
                    {
                        MethodInvoker mi = delegate ()
                        {
                            prgJumping.ForeColor = Color.Green;
                        };
                        this.Invoke(mi);
                    }

                    Thread.Sleep(10);
                }
                MethodInvoker mi2 = delegate ()
                {
                    prgJumping.ForeColor = Color.Red;
                };
                this.Invoke(mi2);

                Thread.Sleep(10);
            }
        }
    }
}
