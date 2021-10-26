using Community.CsharpSqlite.SQLiteClient;
using System;

namespace Cash_Calc_v2
{
    class salaryCalc
    {
        dataCon db = new dataCon();
        calcForm calcF = new calcForm();

        public double daySalary(string selectedDate)
        {
            string[] dataSalaryMonth = new string[13];
            string strLoadDayTable = $"SELECT * FROM salaryTable WHERE dataDay='{selectedDate}'";
            
            db.openConnection();
            SqliteCommand loadDayTable = new SqliteCommand(strLoadDayTable, db.getConnection());
            SqliteDataReader reader = loadDayTable.ExecuteReader();

            int i = 0;
            while (reader.Read())
            {
                dataSalaryMonth[i] = reader[i].ToString();
                i++;
            }
            reader.Close();

            int principalAmount = Convert.ToInt32(dataSalaryMonth[4]);
            int aksAmount = Convert.ToInt32(dataSalaryMonth[5]);
            int phones1 = Convert.ToInt32(dataSalaryMonth[6]);
            int phones2 = Convert.ToInt32(dataSalaryMonth[7]);
            double settings = Convert.ToDouble(dataSalaryMonth[8]);
            double repairs3 = Convert.ToDouble(dataSalaryMonth[9]);
            double repairs5 = Convert.ToDouble(dataSalaryMonth[10]);
            int bonuses = Convert.ToInt32(dataSalaryMonth[11]);

            int hours = Convert.ToInt32(dataSalaryMonth[2]);
            string magazine = dataSalaryMonth[3];
            double summAmount = Convert.ToDouble(principalAmount) + Convert.ToDouble(aksAmount) + Convert.ToDouble(phones1) + Convert.ToDouble(phones2);
            
            int percentStair3;
            int percentStair2;
            int percentStair1;
            int minAmoutPerDay;
            double percent3;
            double percent2;
            double percent1;

            double salaryDaySelected = 0;
            switch (magazine)
            {
                case "Артбухта":
                    percentStair3 = 20000;
                    percentStair2 = 18000;
                    percentStair1 = 13000;
                    minAmoutPerDay = 13000;
                    percent3 = 0.06;
                    percent2 = 0.05;
                    percent1 = 0.04;
                    getCashPerDay();
                    salaryDaySelected = getCashPerDay();
                    return salaryDaySelected;
                case "Меньшикова":
                    if ((bool)calcF.emlCount2.IsChecked)
                    {
                        percentStair3 = 20000;
                        percentStair2 = 18000;
                        percentStair1 = 13000;
                        minAmoutPerDay = 13000;
                        percent3 = 0.06;
                        percent2 = 0.05;
                        percent1 = 0.04;
                        getCashPerDay();
                        salaryDaySelected = getCashPerDay();
                        return salaryDaySelected;
                    }
                    else
                    {
                        percentStair3 = 16000;
                        percentStair2 = 11000;
                        percentStair1 = 9000;
                        minAmoutPerDay = 11000;
                        percent3 = 0.05;
                        percent2 = 0.04;
                        percent1 = 0.03;
                        getCashPerDay();
                        salaryDaySelected = getCashPerDay();
                        return salaryDaySelected;
                    }

                case "Центр":
                    percentStair3 = 15000;
                    percentStair2 = 10000;
                    percentStair1 = 8000;
                    minAmoutPerDay = 10000;
                    percent3 = 0.05;
                    percent2 = 0.04;
                    percent1 = 0.03;
                    getCashPerDay();
                    salaryDaySelected = getCashPerDay();
                    return salaryDaySelected;
                case "Пожарова":
                    percentStair3 = 5000;
                    percentStair2 = 4000;
                    percentStair1 = 3000;
                    minAmoutPerDay = 4000;
                    percent3 = 0.05;
                    percent2 = 0.04;
                    percent1 = 0.03;
                    getCashPerDay();
                    salaryDaySelected = getCashPerDay();
                    return salaryDaySelected;
                case "Остряки":
                    percentStair3 = 5000;
                    percentStair2 = 4000;
                    percentStair1 = 3000;
                    minAmoutPerDay = 4000;
                    percent3 = 0.05;
                    percent2 = 0.04;
                    percent1 = 0.03;
                    getCashPerDay();
                    salaryDaySelected = getCashPerDay();
                    return salaryDaySelected;
                case "Юмашева":
                    percentStair3 = 12000;
                    percentStair2 = 8000;
                    percentStair1 = 6000;
                    minAmoutPerDay = 8000;
                    percent3 = 0.05;
                    percent2 = 0.04;
                    percent1 = 0.03;
                    getCashPerDay();
                    salaryDaySelected = getCashPerDay();
                    return salaryDaySelected;
                default:
                    return salaryDaySelected;
            }

            double getCashPerDay()
            {
                double cashPerDay;
                if (summAmount >= minAmoutPerDay)
                {
                    if (aksAmount >= percentStair3)
                    {
                        cashPerDay = (summAmount - phones1) * 0.02 + phones1 * 0.01 + aksAmount * percent3 + settings * 0.3 + repairs3 * 0.3 + repairs5 * 0.5 + bonuses + hours * 100;
                        return cashPerDay;
                    }
                    else if (aksAmount >= percentStair2)
                    {
                        cashPerDay = (summAmount - phones1) * 0.02 + phones1 * 0.01 + aksAmount * percent2 + settings * 0.3 + repairs3 * 0.3 + repairs5 * 0.5 + bonuses + hours * 100;
                        return cashPerDay;
                    }
                    else if (aksAmount >= percentStair1)
                    {
                        cashPerDay = (summAmount - phones1) * 0.02 + phones1 * 0.01 + aksAmount * percent1 + settings * 0.3 + repairs3 * 0.3 + repairs5 * 0.5 + bonuses + hours * 100;
                        return cashPerDay;
                    }
                    else if (aksAmount < percentStair1)
                    {
                        cashPerDay = (summAmount - phones1) * 0.02 + phones1 * 0.01 + aksAmount * 0.02 + settings * 0.3 + repairs3 * 0.3 + repairs5 * 0.5 + bonuses + hours * 100;
                        return cashPerDay;
                    }
                }
                if (summAmount < minAmoutPerDay)
                {
                    cashPerDay = settings * 0.3 + repairs3 * 0.3 + repairs5 * 0.5 + bonuses + (hours * 100 - 300);
                    return cashPerDay;
                }
                cashPerDay = 0;
                return cashPerDay;
            }
        }
    }
}
