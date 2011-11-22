using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Web.Script.Serialization;
using CommonClientServerLib.Messages;

namespace ChatterClient
{
    public partial class formChatter : Form
    {
        IAsyncResult m_result;
        public AsyncCallback m_pfnCallBack;
        public Socket m_clientSocket;

        public delegate void UpdateRichEditCallback(string text);
        public delegate void UpdateControlsCallBack(bool connected);

        public formChatter()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = GetIP();
        }

        void ButtonCloseClick(object sender, System.EventArgs e)
        {
            if (m_clientSocket != null)
            {
                m_clientSocket.Close();
                m_clientSocket = null;
            }
            Close();
        }

        void ButtonConnectClick(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Navn skal udfyldes før tilslutning!", "Brugernavn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // See if we have text on the IP and Port text fields
            if (textBoxIP.Text == "" || textBoxPort.Text == "")
            {
                MessageBox.Show("IP Address and Port Number are required to connect to the Server\n");
                return;
            }
            try
            {
                UpdateControls(false);
                // Create the socket instance
                m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Cet the remote IP address
                IPAddress ip = IPAddress.Parse(textBoxIP.Text);
                int iPortNo = System.Convert.ToInt16(textBoxPort.Text);
                // Create the end point 
                IPEndPoint ipEnd = new IPEndPoint(ip, iPortNo);
                // Connect to the remote host
                m_clientSocket.Connect(ipEnd);
                if (m_clientSocket.Connected)
                {
                    SendMessage("User:" + txtUserName.Text);
                    UpdateControls(true);
                    //Wait for data asynchronously 
                    WaitForData();
                }
            }
            catch (SocketException se)
            {
                string str;
                str = "\nConnection failed, is the server running?\n" + se.Message;
                MessageBox.Show(str);
                UpdateControls(false);
            }
        }
        void ButtonSendMessageClick(object sender, System.EventArgs e)
        {
            string msg = richTextTxMessage.Text;
            richTextTxMessage.Text = "";
            SendMessage(msg);
        }
        public void WaitForData()
        {
            try
            {
                if (m_pfnCallBack == null)
                {
                    m_pfnCallBack = new AsyncCallback(OnDataReceived);
                }
                SocketPacket theSocPkt = new SocketPacket();
                theSocPkt.thisSocket = m_clientSocket;
                // Start listening to the data asynchronously
                m_result = m_clientSocket.BeginReceive(theSocPkt.dataBuffer,
                                                        0, theSocPkt.dataBuffer.Length,
                                                        SocketFlags.None,
                                                        m_pfnCallBack,
                                                        theSocPkt);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }

        }
        public class SocketPacket
        {
            public System.Net.Sockets.Socket thisSocket;
            public byte[] dataBuffer = new byte[1024];
        }

        bool SocketConnected(Socket socket)
        {
            bool part1 = socket.Poll(1000, SelectMode.SelectRead);
            bool part2 = (socket.Available == 0);
            if (part1 & part2)
                return false;
            else
                return true;
        }

        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                SocketPacket theSockId = (SocketPacket)asyn.AsyncState;

                int iRx = theSockId.thisSocket.EndReceive(asyn);
                String szData = Encoding.UTF8.GetString(theSockId.dataBuffer, 0, iRx);
                AppendToRichEditControl(szData);
                if (SocketConnected(theSockId.thisSocket))
                    WaitForData();
                else
                    throw new SocketException((int)SocketError.ConnectionReset);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                if (se.SocketErrorCode == SocketError.ConnectionReset)
                {
                    object[] pList = { false };
                    this.BeginInvoke(new UpdateControlsCallBack(UpdateControls), pList);
                    MessageBox.Show("Forbindelsen blev afbrudt af serveren");
                }
                else
                    MessageBox.Show(se.Message);
            }
        }

        // This method could be called by either the main thread or any of the
        // worker threads
        private void AppendToRichEditControl(string msg)
        {
            // Check to see if this method is called from a thread 
            // other than the one created the control
            if (richTextRxMessage.InvokeRequired)
            {
                // We cannot update the GUI on this thread.
                // All GUI controls are to be updated by the main (GUI) thread.
                // Hence we will use the invoke method on the control which will
                // be called when the Main thread is free
                // Do UI update on UI thread
                object[] pList = { msg };
                richTextRxMessage.BeginInvoke(new UpdateRichEditCallback(OnUpdateRichEdit), pList);
            }
            else
            {
                // This is the main thread which created this control, hence update it
                // directly 
                OnUpdateRichEdit(msg);
            }
        }
        // This UpdateRichEdit will be run back on the UI thread
        // (using System.EventHandler signature
        // so we don't need to define a new
        // delegate type here)
        private void OnUpdateRichEdit(string msg)
        {
            richTextRxMessage.AppendText(msg + Environment.NewLine);
        }

        private void UpdateControls(bool connected)
        {
            buttonConnect.Enabled = !connected;
            buttonDisconnect.Enabled = connected;
            string connectStatus = connected ? "Connected" : "Not Connected";
            textBoxConnectStatus.Text = connectStatus;
        }
        void ButtonDisconnectClick(object sender, System.EventArgs e)
        {
            if (m_clientSocket != null)
            {
                m_clientSocket.Close();
                m_clientSocket = null;
                UpdateControls(false);
            }
        }
        //----------------------------------------------------	
        // This is a helper function used (for convenience) to 
        // get the IP address of the local machine
        //----------------------------------------------------
        String GetIP()
        {
            String strHostName = Dns.GetHostName();

            // Find host by name
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);

            // Grab the first IP addresses
            String IPStr = "";
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                if (ipaddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    IPStr = ipaddress.ToString();
                    return IPStr;
                }
            }
            return IPStr;
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            richTextRxMessage.Clear();
        }

        private void richTextTxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                string msg = richTextTxMessage.Text;
                richTextTxMessage.Text = "";
                SendMessage(msg);
                e.Handled = true;
            }

        }

        private void SendMessage(string msg)
        {
            string[] test = msg.Split(':');
            List<byte> data = new List<byte>();
            if (m_clientSocket == null)
            {
                MessageBox.Show("Sending is not possible when not connected!", "Sending", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (!m_clientSocket.Connected)
                {
                    MessageBox.Show("Sending is not possible when not connected!", "Sending", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                if(test[0] == "User")
                {
                    JavaScriptSerializer JSR = new JavaScriptSerializer();

                    JsonUserLogOn JsonMsg = new JsonUserLogOn();
                    JsonMsg.UserName = test[1];

                    msg = JSR.Serialize(JsonMsg);
                }
                //Use the following code to send bytes
                data.Add((byte)0x2);
                data.AddRange(System.Text.Encoding.UTF8.GetBytes(msg));
                data.Add((byte)0x10);
                data.Add((byte)0x3);
                if (m_clientSocket != null)
                {
                    m_clientSocket.Send(data.ToArray());
                }


            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }		
    }
}
