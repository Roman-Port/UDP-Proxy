using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UdpProxyUi
{
    public class Packet
    {
        public PacketSource source;
        public byte[] data;
        public DateTime gotTime;

        public string previewAscii;
        public string previewHex;

        public Packet(PacketSource _source, byte[] _data, DateTime _time)
        {
            data = _data;
            source = _source;
            gotTime = _time;
            RecalculatePreview();
        }

        public void RecalculatePreview()
        {
            string preview = Encoding.ASCII.GetString(data);
            if (preview.Length > 200)
                preview = preview.Substring(0, 200);
            previewHex = ToHexString();
            if (previewHex.Length > 200)
                previewHex = previewHex.Substring(0, 200);
        }

        public string ToHexString()
        {
            StringBuilder hex = new StringBuilder(data.Length * 6);
            foreach (byte b in data)
                hex.AppendFormat("0x{0:x2}, ", b);
            return hex.ToString();
        }

        public string GetTime()
        {
            return gotTime.ToShortDateString() + " " + gotTime.Hour.ToString() + ":" + gotTime.Minute.ToString() + ":" + gotTime.Second.ToString() + "." + gotTime.Millisecond.ToString();
        }

        public void Write(Stream ms)
        {
            //Write the 14 bytes of header.
            //[0-3] Data length
            //[4-12] Timestamp ticks
            //[13-14] Source

            byte[] buf = new byte[4];
            buf = BitConverter.GetBytes(data.Length);
            if (BitConverter.IsLittleEndian == false)
                Array.Reverse(buf);
            ms.Write(buf, 0, 4);
            buf = new byte[8];
            buf = BitConverter.GetBytes(gotTime.Ticks);
            if (BitConverter.IsLittleEndian == false)
                Array.Reverse(buf);
            ms.Write(buf, 0, 8);
            short src = (short)source;
            buf = BitConverter.GetBytes(src);
            if (BitConverter.IsLittleEndian == false)
                Array.Reverse(buf);
            ms.Write(buf, 0, 2);
            //Now, write data.
            ms.Write(data, 0, data.Length);
        }

        public static Packet Read(Stream ms)
        {
            //Read the 14 bytes of header.
            //[0-3] Data length
            //[4-12] Timestamp ticks
            //[13-14] Source

            byte[] buf = new byte[4];
            ms.Read(buf, 0, 4);
            if (BitConverter.IsLittleEndian == false)
                Array.Reverse(buf);
            int length = BitConverter.ToInt32(buf, 0);
            buf = new byte[8];
            ms.Read(buf, 0, 8);
            if (BitConverter.IsLittleEndian == false)
                Array.Reverse(buf);
            DateTime dt = new DateTime(BitConverter.ToInt64(buf, 0));
            buf = new byte[2];
            ms.Read(buf, 0, 2);
            if (BitConverter.IsLittleEndian == false)
                Array.Reverse(buf);
            PacketSource src = (PacketSource)BitConverter.ToInt16(buf, 0);

            //Read in actual data.
            buf = new byte[length];
            ms.Read(buf, 0, length);

            //Create packet.
            return new Packet(src,buf, dt);
        }


        //List
        public static void WriteToFile(string path, List<Packet> packets)
        {
            File.Delete(path);
            using (FileStream fs = new FileStream(path, FileMode.CreateNew))
            {
                //Write how many entries there are.
                byte[] buf = new byte[4];
                buf = BitConverter.GetBytes(packets.Count);
                if (BitConverter.IsLittleEndian == false)
                    Array.Reverse(buf);
                fs.Write(buf, 0, 4);
                //Now, write all packets.
                for(int i = 0; i<packets.Count; i++)
                {
                    packets[i].Write(fs);
                }
            }
        }

        public static List<Packet> ReadFromFile(string path)
        {
            List<Packet> packets = new List<Packet>();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                //Read how many entries there are.
                byte[] buf = new byte[4];
                fs.Read(buf, 0, 4);
                if (BitConverter.IsLittleEndian == false)
                    Array.Reverse(buf);
                int count = BitConverter.ToInt32(buf, 0);
                
                //Now, write all packets.
                for (int i = 0; i < count; i++)
                {
                    Packet p = Read(fs);
                    packets.Add(p);
                }
            }
            return packets;
        }
    }

    public enum PacketSource
    {
        Client,
        RemoteServer
    }
}
