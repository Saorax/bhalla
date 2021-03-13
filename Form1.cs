using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Windows;
using MetroFramework;


namespace brawlhalla_stuff
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {

            InitializeComponent();
            string version = "1.0.1";
            //------------
            metroStyleManager1.Theme = sao_ping_checker.Properties.Settings.Default.Theme;
            if (metroStyleManager1.Theme == MetroThemeStyle.Dark)
            {
                metroComboBox1.SelectedIndex = 0;
                richTextBox1.BackColor = Color.FromArgb(12, 12, 12);
                richTextBox1.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                metroComboBox1.SelectedIndex = 1;
                richTextBox1.BackColor = Color.FromArgb(255, 255,255);
                richTextBox1.ForeColor = Color.FromArgb(12, 12, 12);
            }
            //------------
            metroComboBox2.SelectedIndex = sao_ping_checker.Properties.Settings.Default.Region;
            //------------
            if (sao_ping_checker.Properties.Settings.Default.Topmost == true)
            {
                this.TopMost = true;
                metroCheckBox1.Checked = true;
            }
            if (this.TopMost == true)
            {
                metroCheckBox1.Checked = true;
            }
            //------------
            metroComboBox2.SelectedIndex = sao_ping_checker.Properties.Settings.Default.Region;
        }

        

        List<string> ips = new List<string>()
            {
                "pingtest-atl.brawlhalla.com",
                "pingtest-cal.brawlhalla.com",
                "pingtest-ams.brawlhalla.com",
                "pingtest-sgp.brawlhalla.com",
                "pingtest-aus.brawlhalla.com",
                "pingtest-brs.brawlhalla.com",
                "pingtest-jpn.brawlhalla.com"
            };

        private void metroButton1_Click(object sender, EventArgs e)
        {
            List<Label> labels = new List<Label>()
            {
                  metroLabel13,
                  metroLabel12,
                  metroLabel14,
                  metroLabel15,
                  metroLabel16,
                  metroLabel7,
                  metroLabel17
            };
            foreach (var ip in ips)
            {
                int te = ips.FindIndex(x => x.StartsWith(ip));
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(ip);

                //ping color
                Color pingColor = Color.FromArgb(0, 177, 89);
                if (metroStyleManager1.Theme.ToString() == "Light")
                {
                    if (pingReply.RoundtripTime >= 150)
                    {
                        pingColor = Color.FromArgb(209, 17, 65);
                    }
                    else if (pingReply.RoundtripTime >= 80)
                    {
                        pingColor = Color.FromArgb(255, 196, 37);
                    };
                }
                else
                {
                    pingColor = Color.FromName("Lime");
                    if (pingReply.RoundtripTime >= 150)
                    {
                        pingColor = Color.FromName("Red");
                    }
                    else if (pingReply.RoundtripTime >= 80)
                    {
                        pingColor = Color.FromName("Yellow");
                    };
                };

                if (pingReply.Status == IPStatus.Success)
                {
                    labels[te].ForeColor = pingColor;
                    labels[te].Text = pingReply.RoundtripTime.ToString();
                    
                }
                else
                {
                    labels[te].ForeColor = Color.FromArgb(255, 196, 37);
                    labels[te].Text = "ERROR";
                }
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            {
                this.TopMost = true;
                sao_ping_checker.Properties.Settings.Default.Topmost = true;
            }
            else
            {
                this.TopMost = false;
                sao_ping_checker.Properties.Settings.Default.Topmost = false;
            }
            sao_ping_checker.Properties.Settings.Default.Save();
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = this.metroComboBox1.SelectedItem.ToString() == "Light";
            if (flag)
            {
                this.metroStyleManager1.Theme = MetroThemeStyle.Light;
                richTextBox1.ForeColor = Color.FromArgb(12, 12, 12);
                richTextBox1.BackColor = Color.FromArgb(255, 255, 255);
                sao_ping_checker.Properties.Settings.Default.Theme = MetroThemeStyle.Light;
            }
            else
            {
                this.metroStyleManager1.Theme = MetroThemeStyle.Dark;
                richTextBox1.ForeColor = Color.FromArgb(255,255,255);
                richTextBox1.BackColor = Color.FromArgb(12, 12, 12);
                sao_ping_checker.Properties.Settings.Default.Theme = MetroThemeStyle.Dark;
            }
            sao_ping_checker.Properties.Settings.Default.Save();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            Ping ping = new Ping();
            PingReply pingReply = ping.Send(ips[sao_ping_checker.Properties.Settings.Default.Region]);
            // ping color
            Color pingColor = Color.FromArgb(0, 177, 89);
            if (metroStyleManager1.Theme.ToString() == "Light")
            {
                if (pingReply.RoundtripTime >= 150)
                {
                    pingColor = Color.FromArgb(209, 17, 65);
                }
                else if (pingReply.RoundtripTime >= 80)
                {
                    pingColor = Color.FromArgb(255, 196, 37);
                };
            }
            else
            {
                pingColor = Color.FromName("Lime");
                if (pingReply.RoundtripTime >= 150)
                {
                    pingColor = Color.FromName("Red");
                }
                else if (pingReply.RoundtripTime >= 80)
                {
                    pingColor = Color.FromName("Yellow");
                };
            };

            metroLabel9.ForeColor = pingColor;
            metroLabel9.Text = pingReply.RoundtripTime.ToString();
            if (pingReply.Status == IPStatus.Success)
            {
                metroLabel9.ForeColor = pingColor;
                metroLabel9.Text = pingReply.RoundtripTime.ToString();
                //richTextBox1.Text = richTextBox1.Text += pingReply.RoundtripTime.ToString() + " ";

                richTextBox1.AppendText(pingReply.RoundtripTime.ToString(), pingColor);
                richTextBox1.AppendText(" ");
            }
            //Console.WriteLine(ips[sao_ping_checker.Properties.Settings.Default.Region]);
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sao_ping_checker.Properties.Settings.Default.Region = metroComboBox2.SelectedIndex;
            sao_ping_checker.Properties.Settings.Default.Save();
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked == true)
            {
                timer1.Enabled = true;
            } else
            {
                timer1.Enabled = false;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            int num;
            try
            {
                num = int.Parse(metroTextBox1.Text);
                metroTextBox1.Text = num.ToString();
            }
            catch
            {
                metroTextBox1.Text = "";
            }
            timer1.Interval = int.Parse(metroTextBox1.Text);
        }
    }
}
public static class RichTextBoxExtensions
{
    public static void AppendText(this RichTextBox box, string text, Color color)
    {
        box.SelectionStart = box.TextLength;
        box.SelectionLength = 0;

        box.SelectionColor = color;
        box.AppendText(text);
        box.SelectionColor = box.ForeColor;
    }
}