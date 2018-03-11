using System;
using System.Windows.Forms;
using smsCore;

namespace FEUHS_AMS
{
    class sendSMS  : XDLINE
    {

        private string appname = "SMS Sample";
        private SMSComm Modem;
        private int result;

        public void PortLoad(string port)
        {
            try
            {
                //add reference muna, add mo yung smscore
                Modem = new SMSComm(port); //ilagay dito yung com port
                Modem.doE += Application.DoEvents;
                Modem.MessageReceived += NewMessageReceivedEvent;
                Control.CheckForIllegalCrossThreadCalls = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void sendMsg(string num, string msg)
        {
            if ((Modem != null))
            {
                result = Modem.SendSms(num, msg);

                switch (result)
                {
                    case 0:
                        //MessageBox.Show("Message Sent!");
                        break;
                    case 1:
                        //MessageBox.Show("Message Failed!");
                        break;
                    case 2:
                        MessageBox.Show("Some parts failed to send!");
                        break;
                }
            }
        }

        private void NewMessageReceivedEvent(string fromNum, string message)
        {
            MessageBox.Show("From: " + fromNum + "\r\n\r\n" + "Message:\r\n" + message, appname, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ClosePort()
        {
            if ((Modem != null))
            {
                Modem.Dispose();
                Modem = null;
            }
        }
    }
}
