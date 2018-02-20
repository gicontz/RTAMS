using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace FEUHS_AMS
{
    class Records : XDLINE
    {
        public void loadAttendanceRecords(ListView lv)
        {
            List<string>[] thearrayList = this.selectItems("students_table inner join users_table on users_table.user_id = students_table.user_id" +
                " inner join sections_table on students_table.section_id = sections_table.section_id" +
                " inner join courses_table on courses_table.course_id = sections_table.course_id" + 
                " inner join attendance_table on students_table.rfid_number = attendance_table.rfid_number",
                "students_table.student_number, first_name, last_name, middle_name, extension, course_main_title, year, section, time_in, time_out, date_in, remarks",
                new string[] { "student_number", "first_name", "last_name", "middle_name", "extension",
                "course_main_title", "year", "section", "time_in", "time_out", "date_in", "remarks" }, "");

            lv.Items.Clear();

            string[] student_number, first_name, last_name, middle_name, extension, course, year, section, timeIN, timeOUT, date, remarks;
            int numberofQueries = thearrayList.ElementAt(0).Count;

            student_number = new string[numberofQueries];
            first_name = new string[numberofQueries];
            last_name = new string[numberofQueries];
            middle_name = new string[numberofQueries];
            extension = new string[numberofQueries];
            course = new string[numberofQueries];
            year = new string[numberofQueries];
            section = new string[numberofQueries];
            timeIN = new string[numberofQueries];
            timeOUT = new string[numberofQueries];
            date = new string[numberofQueries];
            remarks = new string[numberofQueries];

            int i = 0;
            foreach (List<string> d in thearrayList)
            {
                int j = 0;
                foreach (string value in d)
                {
                    switch (i)
                    {
                        case 0:
                            student_number[j] = value;
                            break;
                        case 1:
                            first_name[j] = value;
                            break;
                        case 2:
                            last_name[j] = value;
                            break;
                        case 3:
                            middle_name[j] = value;
                            break;
                        case 4:
                            extension[j] = value;
                            break;
                        case 5:
                            course[j] = value;
                            break;
                        case 6:
                            year[j] = value;
                            break;
                        case 7:
                            section[j] = value;
                            break;
                        case 8:
                            timeIN[j] = value;
                            break;
                        case 9:
                            timeOUT[j] = value;
                            break;
                        case 10:
                            date[j] = value;
                            break;
                        case 11:
                            remarks[j] = value;
                            break;
                        default:
                            break;
                    }
                    j++;
                }
                i++;
            }

            for (int h = 0; h <= numberofQueries - 1; h++)
            {
                lv.Items.Add(new Records
                {
                    Student_Number = student_number[h],
                    First_Name = first_name[h],
                    Last_Name = last_name[h],
                    Mi = middle_name[h],
                    Ext = extension[h],
                    Course = course[h],
                    Section = section[h],
                    Year = year[h],
                    FullName = first_name[h] + " " + middle_name[h] + ". " + last_name[h] + " " + extension[h],
                    Time_In = timeIN[h],
                    Time_Out = timeOUT[h],
                    Date = date[h],
                    Remarks = remarks[h],
                });
            }
        }

        public string Student_Number { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string FullName { get; set; }
        public string Mi { get; set; }
        public string Ext { get; set; }
        public string Course { get; set; }
        public string Section { get; set; }
        public string Year { get; set; }
        public string Time_In { get; set; }
        public string Time_Out { get; set; }
        public string Date { get; set; }
        public string Remarks { get; set; }
    }


}
