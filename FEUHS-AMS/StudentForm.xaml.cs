using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : Window
    {
        private string student_n;
        private string user_id;
        private string contactnum;
        private XDLINE xdl = new XDLINE();
        private Dictionary<string, string> student_info = new Dictionary<string, string>();
        public StudentForm(string studentnumber)
        {
            InitializeComponent();
            student_number.Text = studentnumber;
            this.student_n = studentnumber;
            getstudentInfo();
            first_name.Text = student_info["first_name"];

        }

        private void getstudentInfo()
        {
            List<string> sinfo = xdl.selectItems("students_table", "user_id, contact_number", new string[] { "user_id", "contact_number" },
                "student_number = " + this.student_n)[0];
            user_id = sinfo.ElementAt(0);
            contactnum = sinfo.ElementAt(1); 
            List<string> stdinfo = xdl.selectItems("users_table", "first_name, last_name, middle_name, extension",
                new string[] { "first_name", "last_name", "middle_name", "extension" }, "user_id = " + user_id)[0];
            List<string> allInfo = new List<string>();
            allInfo.AddRange(sinfo);
            allInfo.AddRange(stdinfo);

            for (int i = 0; i < allInfo.Count; i++)
            {
                string key = i == 0 ? "user_id" : i == 1 ? "contact_number" : i == 2 ? "first_name" : 
                    i == 3 ? "last_name" : i == 4 ? "middle_name" : i == 5 ? "extension" : "";
                this.student_info.Add(key, allInfo.ElementAt(i));
            }
        }
    }
}
