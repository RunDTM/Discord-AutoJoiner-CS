using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Discord_AutoJoiner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            var values = new Dictionary<string, dynamic> { { "cmd", "INVITE_BROWSER" }, { "args", new Dictionary<string, string> { {"code", inviteBox.Text} }  }, { "nonce", Guid.NewGuid().ToString() } };
            var content = JsonConvert.SerializeObject(values);
            var request = WebRequest.Create("http://127.0.0.1:6463/rpc?v=1");
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(content);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            request.Headers.Add("Origin", "https://discord.com");
            var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);
            request.GetResponse();
        }
    }
}
