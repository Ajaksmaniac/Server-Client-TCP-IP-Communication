using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace TCPClient01
{
    public partial class Form1 : Form

    {
        TcpClient mTCPClient;
        byte[] mRx;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            IPAddress ipa;
            int nPort;
            try
            {
                //Checks if IP  or  Port are not null
                if (String.IsNullOrEmpty(tbServerIP.Text) || String.IsNullOrEmpty(tbServerPort.Text)) return;
                if(!IPAddress.TryParse(tbServerIP.Text, out ipa))
                {
                    MessageBox.Show("Supply server IP address");
                    return;
                }
                if (!int.TryParse(tbServerPort.Text, out nPort))
                {
                    nPort = 23000;
                }

                mTCPClient = new TcpClient();
                mTCPClient.BeginConnect(ipa, nPort, onCompleteConnect, mTCPClient);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        

        }

        void onCompleteConnect(IAsyncResult iar)
        {

            TcpClient tcpc;
            try
            {

                tcpc = (TcpClient)iar.AsyncState;
                tcpc.EndConnect(iar);
                mRx = new byte[512];
                tcpc.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadFromServerStream, tcpc);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        void onCompleteReadFromServerStream(IAsyncResult iar)
        {


            TcpClient tcpc;
            int nBytesRecievedFromServer;
            string strRecieved;
            try
            {

                tcpc = (TcpClient)iar.AsyncState;
                nBytesRecievedFromServer = tcpc.GetStream().EndRead(iar);
                if(nBytesRecievedFromServer == 0)
                {
                    MessageBox.Show("Connection Lost...");
                    return;
                }
                strRecieved = Encoding.ASCII.GetString(mRx, 0 , nBytesRecievedFromServer);
                printLine(strRecieved);
                mRx = new byte[512];
                tcpc.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadFromServerStream, tcpc);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void printLine(string _strPrint)
        {
            tbConsole.Invoke(new Action<string>(doInvoke), _strPrint);

        }
        public void doInvoke(string _strPrint)
        {
            tbConsole.Text = _strPrint + Environment.NewLine + tbConsole.Text;
        }
        private void btSend_Click(object sender, EventArgs e)
        {
            byte[] tx;
            if (String.IsNullOrEmpty(tbPayload.Text))
            {
                return;
            }
            try
            {

                tx = Encoding.ASCII.GetBytes(tbPayload.Text);
                if(mTCPClient != null)
                {
                    if (mTCPClient.Client.Connected)
                    {
                        mTCPClient.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToServer, mTCPClient);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        void onCompleteWriteToServer(IAsyncResult iar)
        {
            TcpClient tcpc;
            try
            {
                tcpc = (TcpClient)iar.AsyncState;
                tcpc.GetStream().EndWrite(iar);
            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message);

            }
        }
    }
}
