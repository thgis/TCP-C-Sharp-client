namespace ChatterClient
{
    partial class formChatter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMsgFromServer;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblServerIp;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMsgToServer;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxConnectStatus;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.RichTextBox richTextTxMessage;
        private System.Windows.Forms.RichTextBox richTextRxMessage;
        private System.Windows.Forms.Button buttonSendMessage;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button buttonConnect;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.richTextTxMessage = new System.Windows.Forms.RichTextBox();
            this.textBoxConnectStatus = new System.Windows.Forms.TextBox();
            this.lblMsgToServer = new System.Windows.Forms.Label();
            this.richTextRxMessage = new System.Windows.Forms.RichTextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.lblServerIp = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblMsgFromServer = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(370, 266);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(53, 24);
            this.buttonClose.TabIndex = 11;
            this.buttonClose.Text = "Close";
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Location = new System.Drawing.Point(10, 234);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(200, 24);
            this.buttonSendMessage.TabIndex = 14;
            this.buttonSendMessage.Text = "Send Message";
            this.buttonSendMessage.Click += new System.EventHandler(this.ButtonSendMessageClick);
            // 
            // richTextTxMessage
            // 
            this.richTextTxMessage.Location = new System.Drawing.Point(10, 130);
            this.richTextTxMessage.Name = "richTextTxMessage";
            this.richTextTxMessage.Size = new System.Drawing.Size(200, 96);
            this.richTextTxMessage.TabIndex = 2;
            this.richTextTxMessage.Text = "";
            this.richTextTxMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextTxMessage_KeyDown);
            // 
            // textBoxConnectStatus
            // 
            this.textBoxConnectStatus.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxConnectStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxConnectStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxConnectStatus.Location = new System.Drawing.Point(110, 274);
            this.textBoxConnectStatus.Name = "textBoxConnectStatus";
            this.textBoxConnectStatus.ReadOnly = true;
            this.textBoxConnectStatus.Size = new System.Drawing.Size(200, 13);
            this.textBoxConnectStatus.TabIndex = 10;
            this.textBoxConnectStatus.Text = "Not Connected";
            // 
            // lblMsgToServer
            // 
            this.lblMsgToServer.Location = new System.Drawing.Point(10, 114);
            this.lblMsgToServer.Name = "lblMsgToServer";
            this.lblMsgToServer.Size = new System.Drawing.Size(100, 16);
            this.lblMsgToServer.TabIndex = 9;
            this.lblMsgToServer.Text = "Message To Server";
            // 
            // richTextRxMessage
            // 
            this.richTextRxMessage.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextRxMessage.Location = new System.Drawing.Point(217, 130);
            this.richTextRxMessage.Name = "richTextRxMessage";
            this.richTextRxMessage.ReadOnly = true;
            this.richTextRxMessage.Size = new System.Drawing.Size(206, 128);
            this.richTextRxMessage.TabIndex = 1;
            this.richTextRxMessage.Text = "";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(88, 62);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(40, 20);
            this.textBoxPort.TabIndex = 6;
            this.textBoxPort.Text = "8000";
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonConnect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnect.ForeColor = System.Drawing.Color.Yellow;
            this.buttonConnect.Location = new System.Drawing.Point(287, 8);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(60, 48);
            this.buttonConnect.TabIndex = 7;
            this.buttonConnect.Text = "Connect To Server";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnectClick);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Connection Status";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(88, 36);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(135, 20);
            this.textBoxIP.TabIndex = 3;
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.BackColor = System.Drawing.Color.Red;
            this.buttonDisconnect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisconnect.ForeColor = System.Drawing.Color.Yellow;
            this.buttonDisconnect.Location = new System.Drawing.Point(360, 8);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(60, 48);
            this.buttonDisconnect.TabIndex = 15;
            this.buttonDisconnect.Text = "Disconnet From Server";
            this.buttonDisconnect.UseVisualStyleBackColor = false;
            this.buttonDisconnect.Click += new System.EventHandler(this.ButtonDisconnectClick);
            // 
            // lblServerIp
            // 
            this.lblServerIp.Location = new System.Drawing.Point(28, 39);
            this.lblServerIp.Name = "lblServerIp";
            this.lblServerIp.Size = new System.Drawing.Size(54, 17);
            this.lblServerIp.TabIndex = 4;
            this.lblServerIp.Text = "Server IP:";
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(20, 65);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(63, 17);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "Server Port:";
            // 
            // lblMsgFromServer
            // 
            this.lblMsgFromServer.Location = new System.Drawing.Point(217, 114);
            this.lblMsgFromServer.Name = "lblMsgFromServer";
            this.lblMsgFromServer.Size = new System.Drawing.Size(160, 16);
            this.lblMsgFromServer.TabIndex = 8;
            this.lblMsgFromServer.Text = "Message From Server";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(317, 266);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(53, 24);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(18, 13);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(65, 13);
            this.lblUserName.TabIndex = 17;
            this.lblUserName.Text = "Brugernavn:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(88, 10);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(135, 20);
            this.txtUserName.TabIndex = 18;
            // 
            // formChatter
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(434, 296);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonSendMessage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.textBoxConnectStatus);
            this.Controls.Add(this.lblMsgToServer);
            this.Controls.Add(this.lblMsgFromServer);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblServerIp);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.richTextTxMessage);
            this.Controls.Add(this.richTextRxMessage);
            this.Name = "formChatter";
            this.Text = "Socket Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

