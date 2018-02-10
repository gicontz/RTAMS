using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows;

namespace FEUHS_AMS
{
    class UserInterface
    {
        public static List<Brush> default_colors = new List<Brush>();
        public static BrushConverter bc = new BrushConverter();
        public static string section_name = "";

        public UserInterface()
        {            
            default_colors.Insert(0, (Brush)bc.ConvertFrom("#ffde2128"));
            default_colors.Insert(1, (Brush)bc.ConvertFrom("#ff00c853"));
            default_colors.Insert(2, (Brush)bc.ConvertFrom("#ffffca28"));
            default_colors.Insert(3, (Brush)bc.ConvertFrom("#ff9c27b0"));
            default_colors.Insert(4, (Brush)bc.ConvertFrom("#ff311b92"));
            default_colors.Insert(5, (Brush)bc.ConvertFrom("#FF2CB2C7"));
        }

        // ternary passing a value conditionally
        public static void sectionActive(string[] sections, object sender, EventArgs e)
        {
            Label l = sender as Label;           
            l.Background = l.Name == sections[0] ? (Brush)bc.ConvertFrom("#ffe57373") :
                     l.Name == sections[1] ? (Brush)bc.ConvertFrom("#ff69f0ae") :
                     l.Name == sections[2] ? (Brush)bc.ConvertFrom("#fffff59d") :
                     l.Name == sections[3] ? (Brush)bc.ConvertFrom("#ffea80fc") :
                     l.Name == sections[4] ? (Brush)bc.ConvertFrom("#ff9575cd") :
                     l.Name == sections[5] ? (Brush)bc.ConvertFrom("#FF77C9D6") :
                     l.Background;
            l.Cursor = Cursors.Hand;
        }

        public static void sectionLeave(string[] sections, object sender, EventArgs e)
        {
            Label l = sender as Label;

            if (l.ContentStringFormat != "clicked")
             {                 
                 l.Background = l.Name == sections[0] ? (Brush)bc.ConvertFrom("#ffde2128") :
                     l.Name == sections[1] ? (Brush)bc.ConvertFrom("#ff00c853") :
                     l.Name == sections[2] ? (Brush)bc.ConvertFrom("#ffffca28") :
                     l.Name == sections[3] ? (Brush)bc.ConvertFrom("#ff9c27b0") : 
                     l.Name == sections[4] ? (Brush)bc.ConvertFrom("#ff311b92") :
                     l.Name == sections[5] ? (Brush)bc.ConvertFrom("#FF2CB2C7") :
                     l.Background;
                 l.Cursor = Cursors.Hand;
             }
        }

        public static void controlActive(object sender, EventArgs e, List<Label> labels)
        {
            Grid g = sender as Grid;
            Label thesection = new Label();
            foreach(Label l in labels)
            {
                if (l.ContentStringFormat == "clicked")
                {
                    thesection = l;
                }
            }
            g.Background = thesection.Background;
        }

        public static void controlLeave(object sender, EventArgs e, Grid gr)
        {
            Grid g = sender as Grid;
            if (g.Uid != "clicked")
            {
                g.Background = gr.Background;
            }
        }

        public static void controlVisit(string[] contents, object sender, EventArgs e, List<Grid> p, List<Grid> buttons, List<Label> labels, Brush sectionColor)
        {
            Grid thisbtn = sender as Grid;

            foreach (Grid btn in buttons)
            {
                btn.Uid = "none";
                btn.Background = sectionColor;
            }

            thisbtn.Uid = "clicked";

            /*foreach (Grid pa in p)
            {
                pa.Visibility = System.Windows.Visibility.Hidden;
            }*/

            for (int i = 0; i <= contents.Length - 1; i++)
            {
                if (thisbtn.Name.Equals(contents[i]))
                {
                    //p.ElementAt(i).Visibility = System.Windows.Visibility.Visible;

                    Label thesection = new Label();
                    foreach (Label l in labels)
                    {
                        if (l.ContentStringFormat == "clicked")
                        {
                            thesection = l;
                        }
                    }
                    thisbtn.Background = thesection.Background;
                }
            }

        }

        public void sectionChange(string[] contents, object sender, EventArgs e, List<Grid> p, List<Label> labels)
        {
            Label l = sender as Label;

            foreach (Label ll in labels)
            {
                ll.ContentStringFormat = "none";
                ll.Background = default_colors.ElementAt(labels.IndexOf(ll));
            }

            l.ContentStringFormat = "clicked";

            foreach (Grid pa in p)
            {
                pa.Visibility = System.Windows.Visibility.Hidden;
            }

            for (int i = 0; i <= contents.Length - 1; i++)
            {
                if (l.Content.Equals(contents[i]))
                {
                    p.ElementAt(i).Visibility = System.Windows.Visibility.Visible;
                    l.Background = p.ElementAt(i).Background;
                }
            }

        }

        public static void clearText(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            t.Clear();
        }

    }
}
