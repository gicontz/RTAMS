using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows;

namespace FEUHS_AMS
{
    class SqlSync : XDLINE
    {
        public void loadDumpList(ListView lv)
        {
            List<string>[] thearrayList = this.selectItems("dump_query_table", "*", new string[] { "query_id", "usage", "remarks" }, "");

            lv.Items.Clear();
            
            string[] usage, remarks;
            int[] query_id;
            int numberofQueries = thearrayList.ElementAt(0).Count;

            query_id = new int[numberofQueries];
            usage = new string[numberofQueries];
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
                            query_id[j] = Int32.Parse(value);
                            break;
                        case 1:
                            usage[j] = value;
                            break;
                        case 2:
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
                lv.Items.Add(new DumpList { DumpID = query_id[h], Usage = usage[h], Remarks = remarks[h] });
            }
        }

        public bool perfromSync()
        {
            XDLINE.isOnline = true;
            XDLINE xdl = new XDLINE();
            bool result = false;      

            List<string>[] queries = this.selectItems("dump_query_table", "query_id, query", new string[] { "query_id", "query" }, "");
            int numberOfQueries = queries[0].Count();

            for (int i = 0; i < numberOfQueries; i++)
            {
                result = executeSync(queries[1].ElementAt(i));
                if (result)
                {
                    XDLINE.isOnline = false;
                    XDLINE xdll = new XDLINE();
                    xdll.deleteQuery("dump_query_table", "query_id = " + queries[0].ElementAt(i));
                }
                XDLINE.isOnline = true;
            }
            XDLINE.isOnline = false;
            return result;
        }

        private bool executeSync(string q)
        {
            XDLINE xdl = new XDLINE();
            string[] res = xdl.executeQuery(q);
            return res[0] == "Success";
        }

    }

    public class DumpList
    {
        public int DumpID { get; set; }
        public string Usage { get; set; }
        public string Remarks { get; set; }
    }
}
