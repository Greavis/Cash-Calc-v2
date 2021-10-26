using Community.CsharpSqlite.SQLiteClient;
using HandyControl.Tools;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Cash_Calc_v2
{
    public partial class calcForm : Window
    {
        public calcForm()
        {
            InitializeComponent();
            this.boxAksAmount.PreviewTextInput += new TextCompositionEventHandler(TextBox_PreviewTextInput);
            this.boxPrincipalAmount.PreviewTextInput += new TextCompositionEventHandler(TextBox_PreviewTextInput);
            this.boxOnePercent.PreviewTextInput += new TextCompositionEventHandler(TextBox_PreviewTextInput);
            this.boxTwoPercent.PreviewTextInput += new TextCompositionEventHandler(TextBox_PreviewTextInput);
            this.boxSettings.PreviewTextInput += new TextCompositionEventHandler(TextBox_PreviewTextInput);
            this.boxRepairs3.PreviewTextInput += new TextCompositionEventHandler(TextBox_PreviewTextInput);
            this.boxRepairs5.PreviewTextInput += new TextCompositionEventHandler(TextBox_PreviewTextInput);
            this.boxBonuses.PreviewTextInput += new TextCompositionEventHandler(TextBox_PreviewTextInput);

            ConfigHelper.Instance.SetLang("ru");

            dataCon db = new dataCon();
            DataTable table = new DataTable();
            string curDate = System.DateTime.Today.ToShortDateString().Remove(0, 3);
            string strLoadTable = $"SELECT dataDay,magazine,daySalary FROM 'salaryTable' WHERE data='{curDate}'";
            

            db.openConnection();
            SqliteCommand loadTable = new SqliteCommand(strLoadTable, db.getConnection());
            SqliteDataAdapter adapter = new SqliteDataAdapter();
            adapter.SelectCommand = loadTable;
            adapter.Fill(table);
            
            if(table.Rows.Count > 0)
            {
                salaryTable.ItemsSource = table.DefaultView;
            }
            else
            {
                int i = 1;
                string List
                foreach(i in list) //нужно заполнение текущего месяца- -------------------------------------------------------------------
                string strFillMonth = $"INSERT INTO salaryTable(dataDay, data) VALUES('{}', '{}'";
                SqliteCommand fillMonth = new SqliteCommand(strFillMonth, db.getConnection());

            }
            
            
        }
        void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void boxPrincipalAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            if(boxPrincipalAmount.Text == "0" || boxPrincipalAmount.Text == null)
            {
                boxPrincipalAmount.Text = "";
            }
        }

        private void boxPrincipalAmount_LostFocus(object sender, RoutedEventArgs e)
        {
            if(boxPrincipalAmount.Text == null || boxPrincipalAmount.Text == "")
            {
                boxPrincipalAmount.Text = "0";
            }
        }
        private void boxAksAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            if (boxAksAmount.Text == "0" || boxAksAmount.Text == null)
            {
                boxAksAmount.Text = "";
            }
        }

        private void boxAksAmount_LostFocus(object sender, RoutedEventArgs e)
        {
            if (boxAksAmount.Text == null || boxAksAmount.Text == "")
            {
                boxAksAmount.Text = "0";
            }
        }
        private void boxOnePercent_GotFocus(object sender, RoutedEventArgs e)
        {
            if (boxOnePercent.Text == "0" || boxOnePercent.Text == null)
            {
                boxOnePercent.Text = "";
            }
        }

        private void boxOnePercent_LostFocus(object sender, RoutedEventArgs e)
        {
            if (boxOnePercent.Text == null || boxOnePercent.Text == "")
            {
                boxOnePercent.Text = "0";
            }
        }
        private void boxTwoPercent_GotFocus(object sender, RoutedEventArgs e)
        {
            if (boxTwoPercent.Text == "0" || boxTwoPercent.Text == null)
            {
                boxTwoPercent.Text = "";
            }
        }

        private void boxTwoPercent_LostFocus(object sender, RoutedEventArgs e)
        {
            if (boxTwoPercent.Text == null || boxTwoPercent.Text == "")
            {
                boxTwoPercent.Text = "0";
            }
        }
        private void boxSettings_GotFocus(object sender, RoutedEventArgs e)
        {
            if (boxSettings.Text == "0" || boxSettings.Text == null)
            {
                boxSettings.Text = "";
            }
        }

        private void boxSettings_LostFocus(object sender, RoutedEventArgs e)
        {
            if (boxSettings.Text == null || boxSettings.Text == "")
            {
                boxSettings.Text = "0";
            }
        }
        private void boxRepairs3_GotFocus(object sender, RoutedEventArgs e)
        {
            if (boxRepairs3.Text == "0" || boxRepairs3.Text == null)
            {
                boxRepairs3.Text = "";
            }
        }

        private void boxRepairs3_LostFocus(object sender, RoutedEventArgs e)
        {
            if (boxRepairs3.Text == null || boxRepairs3.Text == "")
            {
                boxRepairs3.Text = "0";
            }
        }
        private void boxRepairs5_GotFocus(object sender, RoutedEventArgs e)
        {
            if (boxRepairs5.Text == "0" || boxRepairs5.Text == null)
            {
                boxRepairs5.Text = "";
            }
        }

        private void boxRepairs5_LostFocus(object sender, RoutedEventArgs e)
        {
            if (boxRepairs5.Text == null || boxRepairs5.Text == "")
            {
                boxRepairs5.Text = "0";
            }
        }
        private void boxBonuses_GotFocus(object sender, RoutedEventArgs e)
        {
            if (boxBonuses.Text == "0" || boxBonuses.Text == null)
            {
                boxBonuses.Text = "";
            }
        }

        private void boxBonuses_LostFocus(object sender, RoutedEventArgs e)
        {
            if (boxBonuses.Text == null || boxBonuses.Text == "")
            {
                boxBonuses.Text = "0";
            }
        }

        private void boxAksAmount_GotFocus_1(object sender, RoutedEventArgs e)
        {

        }

        private void DatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            dateCalendar.Background = Brushes.White;

        }

        private void NumericUpDown_ValueChanged(object sender, HandyControl.Data.FunctionEventArgs<double> e)
        {
            numHours.Background = Brushes.Transparent;
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectorMag.Background = Brushes.Transparent;
        }

        private void myGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            myGrid.Focus();
        }
    }
}
