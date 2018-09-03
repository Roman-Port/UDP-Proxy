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
    delegate void AddCallback(ListViewItem data);
    delegate void LoadCallback(string path);

    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();

            mainPacketList.View = View.Details;
            mainPacketList.GridLines = true;
            mainPacketList.FullRowSelect = true;

            mainPacketList.Columns.Add("Source", 120);
            mainPacketList.Columns.Add("Length", 80);
            mainPacketList.Columns.Add("Time", 250);
            mainPacketList.Columns.Add("ASCII Preview", 300);
            mainPacketList.Columns.Add("Hex Preview", 300);

        }

        public List<Packet> registeredPackets = new List<Packet>();
        public List<ItemPacketPair> queue = new List<ItemPacketPair>();

        public void AddItemToPacketList(Packet pack)
        {
            string[] arr = new string[5];
            ListViewItem itm;
            arr[0] = pack.source.ToString();
            arr[1] = pack.data.Length.ToString();
            arr[2] = pack.GetTime();
            arr[3] = pack.previewAscii;
            arr[4] = pack.previewHex;

            itm = new ListViewItem(arr);
            itm.BackColor = Color.LightBlue;
            if (pack.source == PacketSource.RemoteServer)
                itm.BackColor = Color.LightPink;

            if(pause.Checked)
            {
                //Add to queue for later.
                var p = new ItemPacketPair();
                p.pack = pack;
                p.item = itm;
                queue.Add(p);
            } else
            {
                //Invoke
                if (this.mainPacketList.InvokeRequired)
                {
                    AddCallback d = new AddCallback((ListViewItem i) =>
                    {
                        mainPacketList.Items.Insert(0, itm);
                        registeredPackets.Insert(0, pack);
                    });
                    this.Invoke(d, new object[] { itm });
                }
                else
                {
                    mainPacketList.Items.Insert(0, itm);
                    registeredPackets.Insert(0, pack);
                }
            }
            
            
        }

        private void mainPacketList_ItemActivate(object sender, EventArgs e)
        {
            //When this item is clicked, inspect it.
            //Get the item that was selected.
            ListViewItem item = mainPacketList.SelectedItems[0];
            //Get the packet from the index.
            Packet pack = registeredPackets[item.Index];
            //Show
            var dialog = new InfoPopup(pack);
            DialogResult dr = dialog.ShowDialog(this);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //Open file selector
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "UDP Proxy File|*.udpp";
            saveFileDialog1.Title = "Choose location of file.";
            saveFileDialog1.ShowDialog();

            //Save
            if (saveFileDialog1.FileName != "")
            {
                lock(registeredPackets)
                {
                    Packet.WriteToFile(saveFileDialog1.FileName, registeredPackets);
                }
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            //Open file selector
            OpenFileDialog saveFileDialog1 = new OpenFileDialog();
            saveFileDialog1.Filter = "UDP Proxy File|*.udpp";
            saveFileDialog1.Title = "Choose location of file.";
            saveFileDialog1.ShowDialog();

            //Save
            if (saveFileDialog1.FileName != "")
            {
                //Add each.
                LoadCallback d = new LoadCallback((string path) =>
                {
                    registeredPackets.Clear();
                    mainPacketList.Items.Clear();
                    pause.Checked = false;
                    List<Packet> p = Packet.ReadFromFile(saveFileDialog1.FileName);
                    for (int ii = 0; ii < p.Count; ii++)
                    {
                        AddItemToPacketList(p[ii]);
                    }
                });
                


                if (this.mainPacketList.InvokeRequired)
                {
                    
                    this.Invoke(d, new object[] { saveFileDialog1.FileName });
                }
                else
                {
                    d(saveFileDialog1.FileName);
                }
            }
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            //Add each.
            LoadCallback d = new LoadCallback((string path) =>
            {
                registeredPackets.Clear();
                mainPacketList.Items.Clear();
            });



            if (this.mainPacketList.InvokeRequired)
            {

                this.Invoke(d, new object[] { null });
            }
            else
            {
                d(null);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pause_CheckedChanged(object sender, EventArgs e)
        {
            if(!pause.Checked)
            {
                lock(queue)
                {
                    for (int ii = 0; ii < queue.Count; ii++)
                    {
                        var pair = queue[ii];

                        mainPacketList.Items.Insert(0, pair.item);
                        registeredPackets.Insert(0, pair.pack);
                    }
                }
                queue.Clear();
            }
        }

        private void beginproxybtn_Click(object sender, EventArgs e)
        {
            beginproxybtn.Enabled = false;
            beginproxybtn.Text = "Starting...";
            Program.StartProxy();
            beginproxybtn.Text = "Proxy Started";
        }
    }

    public class ItemPacketPair
    {
        public ListViewItem item;
        public Packet pack;
    }
}
