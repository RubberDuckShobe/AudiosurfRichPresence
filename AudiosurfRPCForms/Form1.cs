using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Logging;
using System.Globalization;

namespace AudiosurfRPCForms {
    public partial class Form1 : Form {

        public static string songName;
        public static string artistName;
        public static string scoreString;
        bool isInitialized;

        [DllImport("SendMessageAudiosurf.dll", EntryPoint = "AudiosurfRegisterRPCWindow")]
        public static extern void AudiosurfRegisterRPCWindow();

        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        public DiscordRpcClient client;

        public const int WM_COPYDATA = 0x004A;

        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        //does absolutely nothing but everything fails and screams at me if this doesn't exist in the code so i'm putting it here and bullying it now
        //fuck you howToUseLabel_Click you're useless and serve no purpose
        private void howToUseLabel_Click(object sender, EventArgs e) {}

        void Initialize() {
            isInitialized = true;
            /*
            Create a discord client
            NOTE: 	If you are using Unity3D, you must use the full constructor and define
                     the pipe connection.
            */
            client = new DiscordRpcClient("698844368953671750", -1, null, false);

            //Set the logger
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            //Subscribe to events
            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Received Update! {0}", e.Presence);
            };

            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence() {
                Details = "In Audiosurf",
                State = "Unknown",
                Assets = new Assets() {
                    LargeImageKey = "audiosurficon4x",
                    LargeImageText = "Audiosurf"
                }
            });
        }

        public Form1() {
            InitializeComponent();
            if (!isInitialized) {
                Initialize();
            }
            var timer = new System.Timers.Timer(150);
            timer.Elapsed += (sender, args) => { client.Invoke(); };
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e) {
            AudiosurfRegisterRPCWindow();
        }

        private void OnApplicationExit(object sender, EventArgs e) {
            client.Dispose();
        }

        protected override void WndProc(ref Message m) {
            // Listen for operating system messages.
            switch (m.Msg) {
                case WM_COPYDATA:
                    COPYDATASTRUCT copyData = new COPYDATASTRUCT();
                    Type type = copyData.GetType();
                    copyData = (COPYDATASTRUCT)m.GetLParam(type);
                    string returnText = copyData.lpData;
                    if (returnText.Contains("successfullyregistered")) {
                        registeredLabel.Text = "Window registered!";
                        statusLabel.Text = "Current status:\nUnknown";
                    }

                    if (returnText.Contains("nowplayingartistname")) {
                        artistName = returnText.Replace("asreport nowplayingartistname ", "");
                        artistName = textInfo.ToTitleCase(artistName);
                        if (songName != null) {
                            songName = textInfo.ToTitleCase(songName);
                        }
                        client.SetPresence(new RichPresence() {
                            Details = "Playing song",
                            State = artistName + " - " + songName,
                            Assets = new Assets() {
                                LargeImageKey = "audiosurficon4x",
                                LargeImageText = "Audiosurf"
                            }
                        });
                        statusLabel.Text = "Current status:\nPlaying song\n" + artistName + " - " + songName;
                    }
                    if (returnText.Contains("nowplayingsongtitle")) {
                        songName = returnText.Replace("asreport nowplayingsongtitle ", "");
                        songName = textInfo.ToTitleCase(songName);
                        if (artistName != null) {
                            artistName = textInfo.ToTitleCase(artistName);
                        }
                        client.SetPresence(new RichPresence() {
                            Details = "Playing song",
                            State = artistName + " - " + textInfo.ToTitleCase(songName),
                            Assets = new Assets() {
                                LargeImageKey = "audiosurficon4x",
                                LargeImageText = "Audiosurf"
                            }
                        });
                        statusLabel.Text = "Current status:\nPlaying song\n" + artistName + " - " + songName;
                    }
                    
                    if (returnText.Contains("oncharacterscreen")) {
                        client.SetPresence(new RichPresence() {
                            Details = "On character select screen",
                            Assets = new Assets() {
                                LargeImageKey = "audiosurficon4x",
                                LargeImageText = "Audiosurf"
                            }
                        });
                        statusLabel.Text = "Current status:\nOn character select screen";
                    }
                    if (returnText.Contains("songcomplete")) {
                        scoreString = returnText.Replace("asreport songcomplete ", "");
                        client.SetPresence(new RichPresence() {
                            Details = "Just finished song (" + artistName + " - " + songName + ")",
                            State = "Score: " + scoreString,
                            Assets = new Assets() {
                                LargeImageKey = "audiosurficon4x",
                                LargeImageText = "Audiosurf"
                            }
                        });
                        statusLabel.Text = "Current status:\nJust finished song (" + artistName + " - " + songName + ")\nScore: " + scoreString;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
    }
}