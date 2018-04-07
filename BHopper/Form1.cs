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
using System.Diagnostics;

namespace BHopper
{
    public partial class Form1 : Form
    {
        // Initialize and assign all addresses and offsets
        int addressLocalPlayer = LocalPlayerAddress;
        int offsetFlags = FlagsOffset;
        int addressJump = JumpAddress;

        string process = "csgo";
        int client;

        bool enabled = false;

        VAMemory vAMemory;

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetAsyncKeyState(int vKey);

        public Form1()
        {
            InitializeComponent();
            prgJumping.Style = ProgressBarStyle.Continuous;
            vAMemory = new VAMemory(process);
        }

        private void btnEnabled_MouseClick(object sender, MouseEventArgs e)
        {
            if (!enabled)
            {
                if (GetModuleAddress())
                {
                    enabled = true;
                    btnEnabled.Text = "Disable";
                    prgJumping.Value = 100;
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Something went wrong. Try connecting to a game before enabling.", "Error");
                }
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
            int jump = client + addressJump;                                            // Current jump address location
            int localPlayer = vAMemory.ReadInt32((IntPtr)addressLocalPlayer + client);  // Current player address location
            int flags = vAMemory.ReadInt32((IntPtr)localPlayer + offsetFlags);          // Current 'flags' address location

            // Main loop for jump logic
            while (true && enabled)
            {
                while (GetAsyncKeyState(32) < 0) // While space is held down
                {
                    if (prgJumping.ForeColor != Color.Green)
                    {
                        MethodInvoker mi = delegate ()
                        {
                            prgJumping.ForeColor = Color.Green;
                        };
                        this.Invoke(mi);
                    }

                    if (flags == 257) // If character not standing on ground
                    {
                        vAMemory.WriteInt32((IntPtr)jump, 5);
                        Thread.Sleep(10);
                        vAMemory.WriteInt32((IntPtr)jump, 4);
                    }
                    Thread.Sleep(10);
                }

                if (prgJumping.ForeColor != Color.Red)
                {
                    MethodInvoker mi2 = delegate ()
                    {
                        prgJumping.ForeColor = Color.Red;
                    };
                    this.Invoke(mi2);
                }

                Thread.Sleep(10);
            }
        }

        private bool GetModuleAddress()
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(process);

                if (processes.Length > 0)
                {
                    foreach (ProcessModule m in processes[0].Modules)
                    {
                        if (m.ModuleName == "client.dll")
                        {
                            client = (int)m.BaseAddress;
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
