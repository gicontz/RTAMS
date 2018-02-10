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

namespace FEUHS_AMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] sections = { "student_section", "attendance_section", "stats_section", "reports_section", "settings_section","about_section" };
        private List<Grid> section_panels = new List<Grid>();
        private List<Label> section_labels = new List<Label>();
        private string[] section_label_contents = { "STUDENTS", "ATTENDANCE", "STATISTICS", "REPORTS", "SETTINGS", "ABOUT"};
        private string[] settings_sections = {"log", "database", "accounts" };
        private UserInterface systemui;
        private XDLINE xdl;
        private XDLINE xdl_online;

        public MainWindow()
        {

            InitializeComponent();            
            systemui = new UserInterface();
            xdl = new XDLINE();

            initializeControls();

            XDLINE.isOnline = online_switch.IsChecked;

            //MessageBox.Show(xdl_offline.OpenConnection().ToString());
            //MessageBox.Show(xdl_online.OpenConnection().ToString());

        }


        private void initializeControls()
        {
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
            BrushConverter bc = new BrushConverter();
            List<Grid> grids = new List<Grid>();
            Grid[] gs = { log, database, accounts };

            foreach(Grid g in gs)
            {
                grids.Add(g);
            }
            
            UserInterface.controlVisit(settings_sections, sender, e, section_panels, grids, section_labels, (Brush)bc.ConvertFrom("#ff311b92"));
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
                mr = MessageBox.Show("You are Currenlty Online, the real time attendance system will not work smoothly.\nProceed Anyway?", "Online Database",
                    MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            }

            if (mr == MessageBoxResult.Yes)
            {
                Attendance att = new Attendance();
                att.Show();
                this.Close();
            }

        }
    }
}
