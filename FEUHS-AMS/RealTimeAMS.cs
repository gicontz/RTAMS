using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;

namespace FEUHS_AMS
{
    class RealTimeAMS : XDLINE
    {
        private string full_name;
        private string stud_number;
        private string section;
        private string timeTable = "";
        public static string time_in_format = "";
        public static string time_out_format = "";
        public static string serialPort = "";
        private List<string>[] student_info;

        public RealTimeAMS()
        {           
            if (this.OpenConnection())
            {
                this.CloseConnection();
                this.timeTable = this.timeState() == 0 ? "time_in" : "time_out";
            }
        }

       public string getFullName(string table_prefix)
        {
            string fullname = "";

            if (!this.isTableEmpty(table_prefix))
            {
                string rfid_number = getLastRFID(table_prefix);
                if (rfid_number != "" || rfid_number != null)
                {
                    List<string>[] student_info = getAllStudentData(table_prefix, rfid_number);
                    fullname = student_info[3].ElementAt(0) + ", " + student_info[2].ElementAt(0) + " " + student_info[5].ElementAt(0) + " " + student_info[4].ElementAt(0) + ".";
                }
            }

            return fullname;
        }

        public string getImage(string table_prefix)
        {
            if (!this.isTableEmpty(table_prefix))
            {
                string rfid_number = getLastRFID(table_prefix);
                if (rfid_number != "" || rfid_number != null)
                {
                    return this.getAllStudentData(table_prefix, rfid_number)[6].ElementAt(0);
                }
            }
            return "";
        }

        public string getSection(string table_prefix)
        {
            if (!this.isTableEmpty(table_prefix))
            {
                string rfid_number = getLastRFID(table_prefix);
                if (rfid_number != "" || rfid_number != null)
                {
                    string sectionId = this.getAllStudentData(table_prefix, rfid_number)[7].ElementAt(0);
                    string[] cols = { "year", "section" };
                    List<string>[] sectionInfo = this.selectItems("sections_table", "year, section", cols, "section_id = " + sectionId);
                    string year = sectionInfo[0].ElementAt(0);
                    string section = sectionInfo[1].ElementAt(0);
                    return year + " " + section;
                }
            }
            return "";
        }

        public string getStudentNumber(string table_prefix)
        {
            if (!this.isTableEmpty(table_prefix))
            {
                string rfid_number = getLastRFID(table_prefix);
                if (rfid_number != "" || rfid_number != null)
                {
                    return this.getAllStudentData(table_prefix, rfid_number)[0].ElementAt(0);
                }
            }
            return "";
        }

        private bool isTableEmpty(string table_prefix)
        {
            int rfid_numbers = this.Count("SELECT COUNT(*) FROM " + table_prefix + "_table");
            return rfid_numbers <= 0;
        }

        private List<string>[] getAllStudentData(string table_prefix, string rfid_number)
        {
            string[] cols = { "student_number", "section_id", "first_name", "last_name", "middle_name", "extension", "img_src", "section_id" };
            student_info = this.selectItems(table_prefix + "_table inner join students_table on " +
                "students_table.rfid_number = " + table_prefix + "_table.rfid_number inner join users_table on students_table.user_id = users_table.user_id",
                "*", cols, table_prefix + "_table.rfid_number =" + rfid_number);
            return student_info;
        }

        public string getContactNumber(string student_number)
        {
            return this.selectItems("students_table", "contact_number", new string[] { "contact_number" }, "student_number = " + student_number)[0].ElementAt(0);
        }

        public string getLastRFID(string table_prefix)
        {
            if (!this.isTableEmpty(this.timeTable)){
                string[] time_table_id = { "rfid_number" };
                string rfid_number = this.selectItems(table_prefix + "_table ORDER BY attendance_id DESC LIMIT 1", "rfid_number", time_table_id, "")[0].ElementAt(0);
                return rfid_number;
            }
            return "";
        }

        public int timeState()
        {
            string timeState = this.selectItems("university_table", "attendance_mode", new string[] { "attendance_mode" }, "")[0].ElementAt(0);
            return Int32.Parse(timeState);
        }

        public string changetimeState(int state)
        {
            return this.updateQuery("university_table", new string[] { "attendance_mode" }, new string[] { state.ToString() }, "univ_id = 1");
        }


    }
}
