using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Microsoft.VisualBasic;

namespace FEUHS_AMS
{
    class Student : XDLINE
    {
        public static string stud_num = "";
        public static string rfid_num = "";

        public Student()
        {

        }

        public void loadStudentList(ListView lv)
        {
            List<string>[] thearrayList = this.selectItems("students_table inner join users_table on users_table.user_id = students_table.user_id" + 
                " inner join sections_table on students_table.section_id = sections_table.section_id" + 
                " inner join courses_table on courses_table.course_id = sections_table.course_id",
                "students_table.student_number, first_name, last_name, middle_name, extension, course_main_title, year, section", 
                new string[] { "student_number", "first_name", "last_name", "middle_name", "extension", "course_main_title", "year", "section" }, "");

            lv.Items.Clear();

            string[] student_number, first_name, last_name, middle_name, extension, course, year, section;
            int numberofQueries = thearrayList.ElementAt(0).Count;
            
            student_number = new string[numberofQueries];
            first_name = new string[numberofQueries];
            last_name = new string[numberofQueries];
            middle_name = new string[numberofQueries];
            extension = new string[numberofQueries];
            course = new string[numberofQueries];
            year = new string[numberofQueries];
            section = new string[numberofQueries];

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
                        default:
                            break;
                    }
                    j++;
                }
                i++;
            }

            for (int h = 0; h <= numberofQueries - 1; h++)
            {
                lv.Items.Add(new Student { Student_Number = student_number[h], First_Name = first_name[h],
                    Last_Name = last_name[h], Mi = middle_name[h], Ext = extension[h], Course = course[h],
                    Section = section[h], Year = year[h],
                    FullName = first_name[h] + " " + middle_name[h] + ". " + last_name[h] + " " + extension[h]});
            }
        }

        public void registerStudentRFID(string student_number, string rfid_number)
        {
            
                if (!this.isAlreadyRegisteredRFID(rfid_number))
                {
                    if (hasRFIDRegistered(student_number))
                    {
                        MessageBoxResult res = MessageBox.Show("Student Already have Registered RFID Number\n Overwrite ID Number?", "Overwriting ID",
                            MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                        if (res == MessageBoxResult.Yes)
                        {
                                this.updateQuery("students_table", new string[] { "rfid_number" },
                                    new string[] { rfid_number }, "student_number = " + student_number);
                                MessageBox.Show(this.updateQuery("attendance_table", new string[] { "rfid_number" },
                                    new string[] { rfid_number }, "rfid_number = " + Student.rfid_num));
                    }
                    }
                    else
                {
                    this.updateQuery("students_table", new string[] { "rfid_number" },
                        new string[] { rfid_number }, "student_number = " + student_number);
                }                    
                }
                else
                {
                    MessageBox.Show("RFID Number Already Registered!",
                        "Used RFID Number", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show(rfid_number);
                }
            
        }

         public bool isAlreadyRegisteredRFID(string rfid_number)
        {
            return this.Count("SELECT COUNT(student_number) FROM students_table where rfid_number = " + rfid_number) > 0;            
        }

        private bool hasRFIDRegistered(string student_number)
        {
            student_number = student_number == "" ? "0" : student_number;
            if (this.Count("SELECT COUNT(student_number) FROM students_table where student_number = " + student_number) > 0)
            {
                return this.selectItems("students_table", "rfid_number", new string[] { "rfid_number" }, "student_number = " + student_number)[0].ElementAt(0) != "";
            }
            return false;
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
    }
}
