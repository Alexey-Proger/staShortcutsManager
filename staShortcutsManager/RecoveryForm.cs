using staShortcutsManager.Properties;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace staShortcutsManager
{
    public partial class RecoveryForm : Form
    {
        String[] RecoveryURLS;
        string targetPath;
        string iconPath;
        string recoveryName;
        int recovery;
        public RecoveryForm(String[] RecoveryNames, String[] RecoveryDescs, String[] recoveryURLS)
        {
            RecoveryURLS = recoveryURLS;
            InitializeComponent();

            select_an_recovery.Text = $"Select recovery for {Settings.Default.deviceName}:";

            if (RecoveryNames.Length == 4)
            {
                this.Size = new Size(GetProperSize(400), GetProperSize(466) - 20);
                flMain.Size = new Size(GetProperSize(358), GetProperSize(329));
                butCancel.Location = new Point(GetProperSize(109), GetProperSize(380) - 20);
            }

            int chetchik = 0;
            foreach (string tag in RecoveryNames)
            {
                int recoveryIcon = 0;

                switch (tag[0])
                {
                    case ('T'):
                        recoveryIcon = 0;
                        break;
                    case ('O'):
                        recoveryIcon = 1;
                        break;
                    case ('P'):
                        recoveryIcon = 2;
                        break;
                    default:
                        recoveryIcon = 3;
                        break;
                }

                RecoveryButton rb = new RecoveryButton();
                rb.RecoveryIcon = recoveryIcon;
                rb.RecoveryDesc = RecoveryDescs[chetchik];
                rb.Tag = (chetchik.ToString() + tag);
                chetchik++;
                rb.MouseClick += new MouseEventHandler(this.custom_Click);
                flMain.Controls.Add(rb);
            }
        }

        private void custom_Click(object sender, EventArgs e)
        {
            var button = (RecoveryButton)sender;
            string tag = button.Tag.ToString();

            switch (tag[1])
            {
                case ('T'):
                    targetPath = Path.Combine(Settings.Default.appFolder, $"twrp{tag[5]}.img");
                    iconPath = Path.Combine(Settings.Default.appFolder, "twrp.ico");
                    recoveryName = (tag[5] == '1') ? $"TWRP" : $"TWRP - {tag[5]}";
                    recovery = 0;
                    break;
                case ('O'):
                    targetPath = Path.Combine(Settings.Default.appFolder, $"ofox{tag[5]}.img");
                    iconPath = Path.Combine(Settings.Default.appFolder, "ofox.ico");
                    recoveryName = (tag[5] == '1') ? $"oFox recovery" : $"oFox recovery - {tag[5]}";
                    recovery = 1;
                    break;
                case ('P'):
                    targetPath = Path.Combine(Settings.Default.appFolder, $"pbrp{tag[5]}.img");
                    iconPath = Path.Combine(Settings.Default.appFolder, "pbrp.ico");
                    recoveryName = (tag[5] == '1') ? $"PBRP" : $"PBRP - {tag[5]}";
                    recovery = 2;
                    break;
            }



            switch (tag[0])
            {
                case ('0'):
                    CreateRecoveryShortcut(RecoveryURLS[0]);
                    break;
                case ('1'):
                    CreateRecoveryShortcut(RecoveryURLS[1]);
                    break;
                case ('2'):
                    CreateRecoveryShortcut(RecoveryURLS[2]);
                    break;
                case ('3'):
                    CreateRecoveryShortcut(RecoveryURLS[3]);
                    break;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task CreateRecoveryShortcut(string recoveryURL)
        {
            Uri recoveryURI = new Uri(recoveryURL);
            ProgressForm pf = new ProgressForm("Cancel");
            pf.Location = new Point(
                    this.Left + (this.Width - pf.Width) / 2,
                    this.Top + (this.Height - pf.Height) / 2
                );
            this.Enabled = false;

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            NamedPipeServerStream pipeServer = null;

            string recoveryBaseName = "";
            switch (recovery)
            {
                case 0:
                    recoveryBaseName = "twrp";
                    break;
                case 1:
                    recoveryBaseName = "ofox";
                    break;
                case 2:
                    recoveryBaseName = "pbrp";
                    break;
            }

            string icoPath = Path.Combine(Settings.Default.appFolder, $"{recoveryBaseName}.ico");

            Task.Run(async () =>
            {
                pipeServer = new NamedPipeServerStream("RecoveryPipe", PipeDirection.Out);
                try
                {
                    pipeServer.WaitForConnection();
                    cts.Cancel();
                }
                catch (ObjectDisposedException)
                {
                }
            });


            try
            {
                WebClient client = new WebClient();

                if (Functions.InternetAvailability())
                {
                    if (File.Exists(targetPath) && File.Exists(icoPath))
                    {
                        using (MessageForm mf = new MessageForm("This recovery is downloaded. Do you want to update it?", "sta Shortcuts Manager", "YesNo"))
                        {
                            Settings.Default.fileAction = 0;
                            mf.ShowDialog(this);
                        }
                        if (Settings.Default.fileAction == 1)
                        {
                            Functions.CreateShortcut(targetPath, recoveryName, true, iconPath);
                            pf.Close();
                            this.Enabled = true;
                            this.Close();
                            return;
                        }
                    }

                    pf.Show();
                    pf.UpdateProgress(0, "(1/2): Downloading recovery image...");

                    await Task.Delay(950, token);

                    if (!Directory.Exists(Settings.Default.appFolder))
                    {
                        Directory.CreateDirectory(Settings.Default.appFolder);
                    }

                    using (token.Register(() =>
                    {
                        try { client.CancelAsync(); } catch { }
                    }))
                    {
                        await Task.Run(() =>
                        {
                            try
                            {
                                client.DownloadProgressChanged += (s, e) =>
                                {
                                    pf.UpdateProgress((e.ProgressPercentage), "(1/2): Downloading recovery image...");
                                };

                                client.DownloadFileAsync(recoveryURI, targetPath);

                                bool finished = false;
                                bool cancelled = false;

                                client.DownloadFileCompleted += (s, e) =>
                                {
                                    finished = true;
                                    cancelled = e.Cancelled;
                                };

                                while (!finished)
                                {
                                    token.ThrowIfCancellationRequested();
                                    Application.DoEvents();
                                    Thread.Sleep(10);
                                }

                                if (cancelled || token.IsCancellationRequested)
                                    throw new OperationCanceledException(token);
                            }
                            catch (OperationCanceledException)
                            {
                                throw;
                            }
                            catch
                            {
                                using (MessageForm mf = new MessageForm($"Failed to download {recoveryBaseName} image.", "sta Shortcuts Manager - Error", "Default"))
                                {
                                    mf.ShowDialog(pf);
                                }
                                pf.Close();
                                this.Enabled = true;
                            }
                        }, token);

                        token.ThrowIfCancellationRequested();

                        pf.UpdateProgress(0, "(2/2): Downloading recovery icon...");

                        await Task.Run(() =>
                        {
                            Uri icoURI = new Uri($"https://github.com/Alexey-Proger/files/releases/download/SSM/{recoveryBaseName}.ico");

                            try
                            {
                                client.DownloadProgressChanged += (s, e) =>
                                {
                                    pf.UpdateProgress((e.ProgressPercentage), "(2/2): Downloading recovery icon...");
                                };

                                client.DownloadFileAsync(icoURI, icoPath);

                                bool finished = false;
                                bool cancelled = false;

                                client.DownloadFileCompleted += (s, e) =>
                                {
                                    finished = true;
                                    cancelled = e.Cancelled;
                                };

                                while (!finished)
                                {
                                    token.ThrowIfCancellationRequested();
                                    Application.DoEvents();
                                    Thread.Sleep(10);
                                }

                                if (cancelled || token.IsCancellationRequested)
                                    throw new OperationCanceledException(token);
                            }
                            catch (OperationCanceledException)
                            {
                                throw;
                            }
                            catch
                            {
                                using (MessageForm mf = new MessageForm($"Failed to download {recoveryBaseName} icon.", "sta Shortcuts Manager - Error", "Default"))
                                {
                                    mf.ShowDialog(pf);
                                }
                                pf.Close();
                                this.Enabled = true;
                            }
                        }, token);
                    }

                    await Task.Delay(1300, token);
                    pf.UpdateProgress(100, "Completed!");
                    await Task.Delay(500, token);
                    Functions.CreateShortcut(targetPath, recoveryName, true, iconPath);
                    pf.Close();
                    this.Enabled = true;
                    this.Close();
                }
                else
                {
                    using (MessageForm mf = new MessageForm("No Internet connection. Please connect and try again.", "sta Shortcuts Manager - Error", "Default"))
                    {
                        mf.ShowDialog(this);
                    }
                    this.Enabled = true;
                }
            }
            catch (OperationCanceledException)
            {
                if (File.Exists(targetPath))
                    File.Delete(targetPath);

                pf.Close();
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                using (MessageForm mf = new MessageForm($"An error has occurred: \n{ex}", "sta Shortcuts Manager - Error", "Default"))
                {
                    mf.ShowDialog(this);
                }
                pf.Close();
                this.Enabled = true;
            }
            finally
            {
                try { pipeServer?.Dispose(); } catch { }
                cts.Dispose();
                this.Activate();
            }
        }

        private int GetProperSize(int size)
        {
            int properIconSize;
            using (Graphics graphics = this.CreateGraphics())
                properIconSize = (int)((double)size * ((double)graphics.DpiX / 96.0));
            return properIconSize;
        }
    }
}
