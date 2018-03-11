using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FEUHS_AMS
{
    /// <summary>
    /// Interaction logic for Attendance.xaml
    /// </summary>
    public partial class Attendance : Window
    {
        //"+ typeof(Attendance).Namespace +"
        private string path = "pack://application:,,,/FEUHS-AMS;component/Images/";
        private CancellationTokenSource cts;
        private int timeStatus;
        private string mainStatus = "";
        private string table_prefix = "";
        private bool isStop = false;
        private sendSMS sms = new sendSMS();

        public Attendance()
        {
            RealTimeAMS rtams = new RealTimeAMS();
            InitializeComponent();
            this.timeStatus = rtams.timeState();
            this.table_prefix = this.timeStatus == 1 ? "time_out" : "time_in";
            checkAttendance();
            sms.PortLoad(RealTimeAMS.serialPort);
        }


        private async void checkAttendance()
        {
            string current = "", previous = "";
            while (!isStop)
            {
                previous = stdnum1.Content.ToString();
                RealTimeAMS rtams = new RealTimeAMS();
                await Task.Delay(100);
                int ts = rtams.timeState();
                    fullname1.Content = rtams.getFullName(this.table_prefix);

                    try
                    {
                        image.Source = new BitmapImage(new Uri(path + rtams.getImage(this.table_prefix)));
                    }
                    catch (ArgumentException e) { this.mainStatus = e.Message;  }

                    section1.Content = rtams.getSection(this.table_prefix);
                    stdnum1.Content = rtams.getStudentNumber(this.table_prefix);
                    current = stdnum1.Content.ToString();

                if (current != previous && current != "")
                {
                    
                    string[] shortcodes = { "[name]", "[date]", "[sect]", "[stdn]" };
                    string[] values = { fullname1.Content.ToString(), DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString(), section1.Content.ToString(), stdnum1.Content.ToString()   };
                    string message = ts == 0 ? RealTimeAMS.time_in_format : RealTimeAMS.time_out_format;

                    ShortCoder sc = new ShortCoder(shortcodes, values, message);
                    message = sc.performFormat();

                    sms.sendMsg(rtams.getContactNumber(stdnum1.Content.ToString()), message);
                }
                //rtams.getContactNumber(stdnum1.Content.ToString());
                //fullname2.Content = rtams.getLastRFID("time_in"); //Test to check RFID Number                
            }
            
        }

        private void showAdmin(object sender, MouseButtonEventArgs e)
        {
            cts = new CancellationTokenSource();
            isStop = true;
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
            if (cts != null)
            {
                cts.Cancel();
            }
        }
    }
}
