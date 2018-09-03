using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UdpProxyUi
{
    public partial class InfoPopup : Form
    {
        public Packet pack;

        public InfoPopup(Packet pack)
        {
            InitializeComponent();
            this.pack = pack;
            hex.Text = pack.ToHexString();
            ascii.Text = Encoding.ASCII.GetString(pack.data);
            packetfromlabel.Text = "Packet from " + pack.source.ToString() + " at " + pack.GetTime();
        }

        private void openinhexedit_Click(object sender, EventArgs e)
        {
            //Open this as a hexedit link.
            string url = "https://hexed.it/#base64:";
            //Convert packet data to base64.
            url += Convert.ToBase64String(pack.data);
            //Open in browser.
            System.Diagnostics.Process.Start(url);
        }
    }
}
