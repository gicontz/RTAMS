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
using System.Windows.Shapes;

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

        public Attendance()
        {
            InitializeComponent();

            checkAttendance();
        }


        private async void checkAttendance()
        {
            RealTimeAMS rtams = new RealTimeAMS();
            for (;;)
            {
                await Task.Delay(100);

                    fullname1.Content = rtams.getFullName("time_in");

                    try
                    {
                        image.Source = new BitmapImage(new Uri(path + rtams.getImage("time_in")));
                    }
                    catch (ArgumentException e) { }

                    section1.Content = rtams.getSection("time_in");
                    stdnum1.Content = rtams.getStudentNumber("time_in");
                    //fullname2.Content = rtams.getLastRFID("time_in"); //Test to check RFID Number
                
            }
        }

        private void showAdmin(object sender, MouseButtonEventArgs e)
        {
            cts = new CancellationTokenSource();

            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
            if (cts != null)
            {
                //cts.Cancel();
            }
        }
    }
}
