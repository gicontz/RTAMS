using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Ini;
using System.Data;
using System.Resources;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace FEUHS_AMS
{
    class XDLINE
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public string connectionString;
        public MySqlConnection cnn = new MySqlConnection();
        public IniFile inif = new IniFile(AppDomain.CurrentDomain.BaseDirectory + "config.ini");
        public IniFile online_inif = new IniFile(AppDomain.CurrentDomain.BaseDirectory + "online_config.ini");
        public static bool isOnline = false;
        private string passphrase = "j234ksan1233Es";
        public static string path = "pack://application:,,,/FEUHS_AMS;component/Images/";

        //Constructor
        public XDLINE()
        {
            Initialize();
        }       

        //Initialize values
        public MySqlConnection Initialize()
        {
            string[] configss = this.readConfigurations();

            server = configss[2];
            database = configss[3];
            uid = configss[0];
            password = configss[1];
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            return connection;
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");                        
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Execute Query
        public string[] executeQuery(string query)
        {
            string[] results = new string[2];
                try
                {
                    //open connection
                    MySqlCommand mcmd = new MySqlCommand(query, connection);

                //create command and assign the query and connection from the constructor
                if (this.OpenConnection() == true)
                {
                    //Execute command
                    mcmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();

                    results[0] = "Success";
                    results[1] = "";
                }
            }
                catch (MySqlException ex)
            {
                results[0] = "Error";
                switch (ex.Number)
                {
                    case 1022:
                        results[1] = "Cannot Write Duplicate Keys";
                        break;

                    default:
                        results[1] = ex.ToString();
                        break;
                }
                this.CloseConnection();
            }
            return results;
            
        }

        public string insertQuery(string table_name, string[] column_names, string[] values)
        {
            string query = "INSERT into " + table_name + " (";
            int i = 0, j = 0;

            int numberOfCols = column_names.Length;
            int numberOfVals = values.Length;

            foreach (string column_name in column_names)
            {
                if (i < numberOfCols - 1)
                {
                    query += column_name + ", ";
                }
                else
                {
                    query += column_name + ") values (";
                }
                i++;
            }

            foreach (string value in values)
            {
                if (j < numberOfVals - 1)
                {
                    query += value + ", ";
                }
                else
                {
                    query += value + ")";
                }
                j++;
            }
            return this.executeQuery(query)[0];
        }

        public string updateQuery(string table_name, string[] column_names, string[] values, string whereStatement)
        {
            string query = "UPDATE " + table_name + " set ";
            int i = 0;
            
            int numberOfVals = values.Length;

            foreach (string column_name in column_names)
            {
                if (i < numberOfVals - 1)
                {
                    query += column_name + "=" + values[i] + ", ";
                }
                else
                {
                    query += column_name + "=" + values[i] + " ";
                }
                    i++;
            }
            query += " WHERE " + whereStatement;
            return this.executeQuery(query)[0];
        }

        public string deleteQuery(string table_name, string whereStatement)
        {
            string query = "DELETE from " + table_name + " WHERE ";
            query += whereStatement;
            return this.executeQuery(query)[0];            
        }


        public int Count(string query)
        {
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        public string[] readConfigurations()
        {
            IniFile theinif = isOnline ? this.online_inif : this.inif;

            string[] configs;
            configs = new string[4];
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "config.ini"))
            {
                configs[0] = theinif.IniReadValue("database", "username");
                configs[1] = theinif.IniReadValue("database", "password");
                configs[2] = theinif.IniReadValue("database", "hostname");
                configs[3] = theinif.IniReadValue("database", "databasename");

                //MessageBox.Show(configs[0]); //Testing purposes
            }
            return configs;
        }

        public void createConfigurations(string un, string pw, string hn, string dbname, string state)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "config.ini"))
            {
                inif.IniWriteValue("database", "username", un);
                inif.IniWriteValue("database", "password", pw);
                inif.IniWriteValue("database", "hostname", hn);
                inif.IniWriteValue("database", "databasename", dbname);
                inif.IniWriteValue("attendance", "status", state);
            }
        }

        public string selectItemById(string table_name, string id_name, string search_item, string value, bool withWhere)
        {
            string query = withWhere ? "SELECT " + search_item + " FROM " + table_name + " where " + id_name + " = "+ value :
                "SELECT " + search_item + " FROM " + table_name;

            //Create a list to store the result
            string item_string = "";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    item_string = dataReader[search_item] + "";
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();                
            }
            return item_string;
        }

        public bool isAccountExist(string un, string pw)
        {
            string decr_pw = "", accessibility = "";
            string query = "SELECT password, access FROM accounts_table where username = '" + un + "'";

            //Create a list to store the result
            string item_string = "";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    item_string = dataReader["password"] + "";
                    accessibility = dataReader["access"] + "";
                    //admin_access = accessibility;
                    decr_pw = StringCipher.Decrypt(item_string, passphrase);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }
            return decr_pw == pw;
        }

        //Select Items
        public List<string>[] selectItems(string table_name, string col_names, string[] columns, string whereStatement)
        {
            
            string query = "SELECT " + col_names + " from " + table_name;
            query = whereStatement != "" ? query + " where " + whereStatement : query;

            //Create a list to store the result
            List<string>[] list = new List<string>[columns.Length];

            for (int i = 0; i <= columns.Length - 1; i++)
            {
                list[i] = new List<string>();
            }

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    int j = 0;
                    foreach(List<string> ll in list){
                        ll.Add(dataReader[columns[j]] + "");
                        j++;
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }                   

        private SolidColorBrush setStockRemarksRow(string stock)
        {
            return stock == "Fair" ? Brushes.Gold :
                   stock == "Out of Stock" ? Brushes.Red : 
                   stock == "Good" ? Brushes.Green :
                   stock == "In Dangered" ? Brushes.Orange :
                   Brushes.Transparent;            
        }

        //Input Validations
        public static bool isNumber(string text)
        {
            return Regex.IsMatch(text, "^[0-9]{1,}$");
        }

        public static bool isText(string text)
        {            
            return Regex.IsMatch(text, "^[a-zA-Z\\s]{1,}$");
        }

    }

    //Class to get and set Products
    public class ProductItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Exp_Date { get; set; }

        public float Price { get; set; }
        
    }

    //Class to get and set Stocks
    public class StockItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Qty { get; set; }

        public string Unit { get; set; }

        public string Remarks { get; set; }

        public SolidColorBrush Color { get; set; }

    }
}


