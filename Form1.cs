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

namespace brawlhalla_stuff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            
            foreach (var ip in ips)
            {
                try
                {
                    Ping ping = new Ping();
                    PingReply pingReply = ping.Send(ip);

                    if (pingReply.Status == IPStatus.Success)
                    {
                        string pingColor = "Lime";
                        if (pingReply.RoundtripTime >= 150)
                        {
                            pingColor = "Red";
                        } else if (pingReply.RoundtripTime >= 80)
                        {
                            pingColor = "Yellow";
                        };

                        if (ip == "pingtest-atl.brawlhalla.com")
                        {
                            metroLabel13.ForeColor = Color.FromName(pingColor);
                            metroLabel13.Text = pingReply.RoundtripTime.ToString();
                        } 
                        else if (ip == "pingtest-cal.brawlhalla.com")
                        {
                            metroLabel12.ForeColor = Color.FromName(pingColor);
                            metroLabel12.Text = pingReply.RoundtripTime.ToString();
                        }
                        else if (ip == "pingtest-ams.brawlhalla.com")
                        {
                            metroLabel14.ForeColor = Color.FromName(pingColor);
                            metroLabel14.Text = pingReply.RoundtripTime.ToString();
                        }
                        else if (ip == "pingtest-sgp.brawlhalla.com")
                        {
                            metroLabel15.ForeColor = Color.FromName(pingColor);
                            metroLabel15.Text = pingReply.RoundtripTime.ToString();
                        }
                        else if (ip == "pingtest-aus.brawlhalla.com")
                        {
                            metroLabel16.ForeColor = Color.FromName(pingColor);
                            metroLabel16.Text = pingReply.RoundtripTime.ToString();
                        }
                        else if (ip == "pingtest-brs.brawlhalla.com")
                        {
                            metroLabel7.ForeColor = Color.FromName(pingColor);
                            metroLabel7.Text = pingReply.RoundtripTime.ToString();
                        }
                        else if (ip == "pingtest-jpn.brawlhalla.com")
                        {
                            metroLabel17.ForeColor = Color.FromName(pingColor);
                            metroLabel17.Text = pingReply.RoundtripTime.ToString();
                        }
                    }
                }
                catch
                {
                    
                }
            }
        }
    }
}
