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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToggleSwitch;
using System.IO.Ports;
using System.IO;
using System.Media;

namespace FEUHS_AMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static SerialPort _serialPort;
        private static string dstring = "";
        private static bool _continue;
        private static Thread readThread;
        private string rfidPort = "";
        private bool isRfidPortLoaded = false;

        private string[] sections = { "student_section", "attendance_section", "stats_section", "reports_section", "settings_section","about_section" };
        private List<Grid> section_panels = new List<Grid>();
        private List<Label> section_labels = new List<Label>();
        private string[] section_label_contents = { "STUDENTS", "ATTENDANCE", "STATISTICS", "REPORTS", "SETTINGS", "ABOUT"};
        private string[] settings_sections = { "log", "database", "accounts", "message" };
        private string[] students_sections = { "register", "edit" };
        private UserInterface systemui;
        private XDLINE xdl = new XDLINE();
        private SqlSync sqlsync = new SqlSync();
        private Student student = new Student();
        private Records rec = new Records();

        public MainWindow()
        {

            InitializeComponent();

            if (!xdl.OpenConnection()) {
                MessageBox.Show("Cannot Connect to the Database!");
                Environment.Exit(0);
            }
            else
            {
                xdl.CloseConnection();
                StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;

                    systemui = new UserInterface();
                    xdl = new XDLINE();

                    initializeControls();

                    XDLINE.isOnline = online_switch.IsChecked;
                    sqlsync.loadDumpList(dumqlList);
                    student.loadStudentList(studentList);
                    rec.loadAttendanceRecords(attendance_List);

                    //MessageBox.Show(xdl_offline.OpenConnection().ToString());
                    //MessageBox.Show(xdl_online.OpenConnection().ToString());
           }
           showPorts();
         }


        private void initializeControls()
        {
            RealTimeAMS rtams = new RealTimeAMS();
            section_panels.Clear();
            section_labels.Clear();
            Grid[] gs = { student_panel, attendance_panel, stats_panel, reports_panel, settings_panel, about_panel };
            Label[] ls = { student_section, attendance_section, stats_section, reports_section, settings_section, about_section };
            foreach (Grid g in gs)
            {
                section_panels.Add(g);
            }

            foreach (Label l in ls)
            {
                section_labels.Add(l);
            }

            int status = timeStatus.IsChecked ? 0 : 1;
            rtams.changetimeState(status);
        }

        private void sectionActive(object sender, MouseEventArgs e)
        {
            UserInterface.sectionActive(sections, sender, e);
        }

        private void sectionLeave(object sender, MouseEventArgs e)
        {
            UserInterface.sectionLeave(sections, sender, e);
        }

        private void sectionChange(object sender, MouseButtonEventArgs e)
        {
            systemui.sectionChange(section_label_contents, sender, e, section_panels, section_labels);
        }

        private void controlActive(object sender, MouseEventArgs e)
        {

            UserInterface.controlActive(sender, e, section_labels);
        }

        private void controlLeave(object sender, MouseEventArgs e)
        {
            Grid[] controlGrids = { settings_controller };
            Grid controller = new Grid();

            foreach (Grid g in controlGrids)
            {
                if ((UserInterface.section_name == "products_section" && g.Name == "products_controller")
                    || (UserInterface.section_name == "stocks_section" && g.Name == "stocks_controller")
                    || UserInterface.section_name == "settings_section" && g.Name == "settings_controller")
                {
                    controller = g;
                    break;
                }
            }
            UserInterface.controlLeave(sender, e, controller);
        }                    

    private void settingcontrolVisit(object sender, MouseButtonEventArgs e)
        {
            sqlsync.loadDumpList(dumqlList);
            BrushConverter bc = new BrushConverter();
            List<Grid> grids = new List<Grid>();
            Grid[] gs = { log, database, accounts, message };

            foreach(Grid g in gs)
            {
                grids.Add(g);
            }
            
            UserInterface.controlVisit(settings_sections, sender, e, section_panels, grids, section_labels, (Brush)bc.ConvertFrom("#ff311b92"));

            Grid gd = sender as Grid;

            switch (gd.Name)
            {
                case "database":
                    database_panel.Visibility = Visibility.Visible;
                    log_panel.Visibility = Visibility.Hidden;
                    sms_panel.Visibility = Visibility.Hidden;
                    accounts_panel.Visibility = Visibility.Hidden;
                    break;

                case "log":
                    database_panel.Visibility = Visibility.Hidden;
                    log_panel.Visibility = Visibility.Visible;
                    sms_panel.Visibility = Visibility.Hidden;
                    accounts_panel.Visibility = Visibility.Hidden;
                    break;

                case "accounts":
                    database_panel.Visibility = Visibility.Hidden;
                    log_panel.Visibility = Visibility.Hidden;
                    sms_panel.Visibility = Visibility.Hidden;
                    accounts_panel.Visibility = Visibility.Visible;
                    break;

                case "message":
                    database_panel.Visibility = Visibility.Hidden;
                    log_panel.Visibility = Visibility.Hidden;
                    accounts_panel.Visibility = Visibility.Hidden;
                    sms_panel.Visibility = Visibility.Visible;
                    break;
                default:

                break;
            }
        }
        
        private void databaseConnectionChange(object sender, RoutedEventArgs e)
        {
            HorizontalToggleSwitch hts = sender as HorizontalToggleSwitch;
            XDLINE.isOnline = hts.IsChecked;
        }
        
        private void showAttendance(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mr = MessageBoxResult.Yes;
            if (XDLINE.isOnline)
            {
                mr = MessageBox.Show("You are Currently Online, the real time attendance system will not work smoothly.\nProceed Anyway?", "Online Database",
                    MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            }

            if (mr == MessageBoxResult.Yes)
            {
                Attendance att = new Attendance();
                att.Show();
                this.Close();
            }

        }

        private async void synchronizeDatabase(object sender, RoutedEventArgs e)
        {
            imgsync.BeginStoryboard(imgsyncStory);

            await
            Task.Delay(700);

            string result = sqlsync.perfromSync() ? "Database Sucessfully Synced!" : "Cannot Complete Synchronization, please try again!";
            MessageBox.Show(result, "Synchronization", MessageBoxButton.OK, MessageBoxImage.Information);
            sqlsync.loadDumpList(dumqlList);
        }

        private void loadLists()
        {
            sqlsync.loadDumpList(dumqlList);
        }

        private void renewDatabase(object sender, RoutedEventArgs e)
        {
            imgsync.BeginStoryboard(imgsyncStory1);
            xdl.executeQuery("TRUNCATE TABLE `time_in_table`; TRUNCATE TABLE `time_out_table`");
        }

        private void timeStatusChanged(object sender, RoutedEventArgs e)
        {
            HorizontalToggleSwitch swits = sender as HorizontalToggleSwitch;
            RealTimeAMS rtams = new RealTimeAMS();
            int status = swits.IsChecked ? 0 : 1;
            rtams.changetimeState(status);
        }

        private void LoadPort(string port)
        {
            try
            {
                // Create a new SerialPort object with default settings.
                _serialPort = new SerialPort();

                // Allow the user to set the appropriate properties.
                _serialPort.PortName = port;
                _serialPort.BaudRate = 9600;
                _serialPort.Parity = Parity.None;
                _serialPort.DataBits = 8;
                _serialPort.StopBits = StopBits.One;

                // Set the read/write timeouts
                _serialPort.ReadTimeout = 300;
                _serialPort.WriteTimeout = 300;

                _serialPort.Open();
                _continue = true;
                Read();
            }
            catch (IOException e)
            {
                MessageBox.Show(e.ToString());
            }
            _serialPort.Close();
        }

        private void showPorts()
        {
            int i = 1;
            while(i <= 20)
            {
                comport.Items.Add("COM" + i);
                rfidports.Items.Add("COM" + i);
                i++;
            }
        }

        private static void Read()
        {
            //var beep = new SoundPlayer(Properties.Resources.beep);
            _continue = true;
            while (_continue)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    message = message.Replace(" ", "");
                    Student std = new Student();
                    std.registerStudentRFID(Student.stud_num, message);
                    if (message != "")
                    {
                        _continue = false;
                    }                                
                }
                catch (TimeoutException e)
                {

                }
            }
        }

        private void student_select(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = new ListView();
            lv = sender as ListView;
            var item = lv.SelectedItem as Student;

            if (item != null)
            {
                Student.stud_num = item.Student_Number;
                Student.rfid_num = xdl.selectItems("students_table", "rfid_number", new string[] { "rfid_number" }, "student_number = " + item.Student_Number)[0].ElementAt(0);                
            }
        }

        private void registerstudentcontrolVisit(object sender, MouseButtonEventArgs e)
        {
            readThread = new Thread(Read);
            LoadPort(this.rfidPort);
            isRfidPortLoaded = true;
            studentList.SelectedItems.Clear();
            Student.rfid_num = "";
        }
        
        private void gsmserialportselect(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            RealTimeAMS.serialPort = cb.Text;
        }

        private void rfidserialportselect(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            this.rfidPort = cb.Text;
        }
        
        private void releaseAssets_onWindowClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isRfidPortLoaded)
            {
                _serialPort.Close();
            }
        }
    }
}
