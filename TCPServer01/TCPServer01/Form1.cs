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
namespace TCPServer01
{
    public partial class Form1 : Form
    {
        TcpListener mTCPListener;
        TcpClient mTCPClient;
        byte[] mRx;
        public Form1()
        {
            InitializeComponent();
        }


        IPAddress findMyIPV4Address()
        {


            string strThisHostName = string.Empty;
            IPHostEntry thisHostDNSEntry = null;
            IPAddress[] allIPsOfThisHost = null;
            IPAddress ipv4Ret = null;
            try
            {
                strThisHostName = System.Net.Dns.GetHostName();
                printLine(strThisHostName);
                thisHostDNSEntry = System.Net.Dns.GetHostEntry(strThisHostName);
                allIPsOfThisHost = thisHostDNSEntry.AddressList;
                //Stores all adreses into IP Array, And looks for ipv4 addres
                for(int idx = allIPsOfThisHost.Length -1; idx > 0; idx--)
                {
                    if(allIPsOfThisHost[idx].AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipv4Ret = allIPsOfThisHost[idx];
                        break;
                        
                    }
                }

                
            }
            catch (Exception e)
                //reads data from network stream
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ipv4Ret;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress ipAddr;
            int nPort;

            //Converting from String to int
            if(!int.TryParse(tbPort.Text, out nPort))
            {
                //Default port
                nPort = 23000; 
            }


            //Converting from String to IPAddress
            if(!IPAddress.TryParse(tbIPAddress.Text, out ipAddr))
            {

                //If ip is invalid, It shows a message
                MessageBox.Show("Invalid IP Address");
            }
            //creating new TCPListener with given ip addres and port
            mTCPListener = new TcpListener(ipAddr, nPort);
            //Start Listening for incoming connections

            mTCPListener.Start();
            //Accepting begins accepting incoming connection    
            mTCPListener.BeginAcceptTcpClient(onCompleteAcceptTcpClient, mTCPListener);


        }
        

        void onCompleteAcceptTcpClient(IAsyncResult iar)
        {
            TcpListener tcpl = (TcpListener)iar.AsyncState;
            try
            {
                //Async accepts incoming connection
                mTCPClient = tcpl.EndAcceptTcpClient(iar);
                printLine("Client Connected.");
                //this represents a packet
                tcpl.BeginAcceptTcpClient(onCompleteAcceptTcpClient, tcpl);
                mRx = new byte[512];
                //reads data from network stream
                mTCPClient.GetStream().BeginRead(mRx,0,mRx.Length, onCompleteReadTCPClientStream, mTCPClient);
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        

        }

        void onCompleteReadTCPClientStream(IAsyncResult iar)
        {
            TcpClient tcpc;
            int nCountReadBytes = 0;
            string strRecv;
            try
            {
                tcpc = (TcpClient)iar.AsyncState;

                nCountReadBytes = tcpc.GetStream().EndRead(iar);
                //if no data is recieved, it closes the connection
                if(nCountReadBytes == 0)
                {
                    MessageBox.Show("Client Disconected.");
                    return;
                }
                //converts recieved bytes to ASCII characters
                strRecv = Encoding.ASCII.GetString(mRx, 0, nCountReadBytes);
                //prints message in the textBox
                printLine(strRecv);

                //prepares for the new read
                mRx = new byte[512];
                tcpc.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadTCPClientStream, tcpc);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void printLine(string _strPrint)
        {
            tbConsoleOutput.Invoke(new Action<string>(doInvoke), _strPrint);
                
        }
        public void doInvoke(string _strPrint)
        {
            tbConsoleOutput.Text = _strPrint + Environment.NewLine + tbConsoleOutput.Text;
        }


        //Sending data to the client
        private void btnSend_Click(object sender, EventArgs e)
        {
            
            byte[] tx = new byte[512];
            //If String to send is empty. returns
            if (string.IsNullOrEmpty(tbPayload.Text)) return;

            try
            {
                
                if(mTCPClient != null)
                {
                    if (mTCPClient.Client.Connected)
                    {

                        //Encodes string to bytes
                        tx = Encoding.ASCII.GetBytes(tbPayload.Text);
                        //Sends an packet to the client only if there is a client connected
                        mTCPClient.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToClientStream, mTCPClient);
                    }
                }
            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//
        //completes writing data to the client
        private void onCompleteWriteToClientStream(IAsyncResult iar)
        {
            try
            {
                TcpClient tcpc = (TcpClient)iar.AsyncState;
                //Stops sending data
                tcpc.GetStream().EndWrite(iar);  
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFindIP_Click(object sender, EventArgs e)
        {
            IPAddress ipa = null;
            ipa = findMyIPV4Address();
            if(ipa != null)
            {
                tbIPAddress.Text = ipa.ToString();
            }
        }
    }
}
