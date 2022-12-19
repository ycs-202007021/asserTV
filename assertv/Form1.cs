using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace assertv
{
    public partial class Form1 : Form
    {
        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Database.accdb;Mode=ReadWrite"; //데이터베이스 연결 문자열

        int month, year;
        //월 및 연도에 대해 다른 형식으로 전달할 수 있는 정적 변수를 생성.
        public static int static_month, static_year;


        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            displaDay();

            DateTime now = DateTime.Now;

            String day = "";
            String month = "";
            if (now.Day < 10)
                day = "0" + now.Day;
            else
                day = now.Day.ToString();

            if (now.Month < 10)
                month = "0" + now.Month;
            else
                month = now.Month.ToString();
            

            String date = now.Year + "-" + month + "-" + day;
                
            var conn = new OleDbConnection(connString);
            conn.Open();

            var comm = new OleDbCommand("SELECT* FROM t_info", conn);
            var myRead = comm.ExecuteReader();

            OleDbCommand cmd = conn.CreateCommand();
            while (myRead.Read())
            {
                if (date == myRead["e_date"].ToString()) 
                {
                    Traymassage tray = new Traymassage();
                    tray.MsgText = myRead["event"].ToString();
                    tray.ShowDialog();
                }
                    
            }
            conn.Close();

            label1.BackColor = Color.Transparent;
            label1.Parent = this;

            label5.BackColor = Color.Transparent;
            label5.Parent = this;

            Monday.BackColor = Color.Transparent;
            Monday.Parent = this;

            label6.BackColor = Color.Transparent;
            label6.Parent = this;

            label8.BackColor = Color.Transparent;
            label8.Parent = this;

            label4.BackColor = Color.Transparent;
            label4.Parent = this;

            lbDate.BackColor = Color.Transparent;
            lbDate.Parent = this;

            label7.BackColor = Color.Transparent;
            label7.Parent = this;   // 투명하게 하기 위해 라벨컨트롤이 얹혀있는 상위 컨트롤 이름

            DayContainer.BackColor = Color.Transparent;
            DayContainer.Parent = this;

            //this.btnPrevious.BackColor = System.Drawing.Color.Thistle;
        }

        private void displaDay() 
        {
            DateTime now = DateTime.Now;

            month = now.Month;
            year = now.Year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDate.Text = year + "년 " + monthname;

            static_month = month;
            static_year = year;
            //매월 첫날 구하기
            DateTime startofthemonth = new DateTime(year, month, 1);
            //월의 총 날짜 구하기
            int days = DateTime.DaysInMonth(year, month);
            //startofthemonth 정수형으로 변환
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlblank ucblank = new UserControlblank();
                DayContainer.Controls.Add(ucblank);
            }
            //날짜 만들기
            for(int i=1; i<= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();

                ucdays.days(i);
                DayContainer.Controls.Add(ucdays);
            }

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //이전달 달력 출력을 위해 달력 초기화
            DayContainer.Controls.Clear();

            //이전달 구하기 위해 감소
            month--;
            if (month == 0)
            {
                year--;
                month = 12;
            }

            static_month = month;
            static_year = year;
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDate.Text = year + "년 " + monthname;

            DateTime startofthemonth = new DateTime(year, month, 1);
            //월의 총 날짜 구하기
            int days = DateTime.DaysInMonth(year, month);
            //startofthemonth 정수형으로 변환
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlblank ucblank = new UserControlblank();
                DayContainer.Controls.Add(ucblank);
            }
            //날짜 만들기
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();

                ucdays.days(i);
                DayContainer.Controls.Add(ucdays);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //다음달 달력 출력을 위해 달력 초기화
            DayContainer.Controls.Clear();

            //다음달 구하기 위해 증가
            month++;
            if (month == 13)
            {
                year++;
                month = 1;
            }
            static_month = month;
            static_year = year;
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDate.Text = year + "년 " + monthname;

            DateTime startofthemonth = new DateTime(year, month, 1);
            //월의 총 날짜 구하기
            int days = DateTime.DaysInMonth(year, month);
            //startofthemonth 정수형으로 변환
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlblank ucblank = new UserControlblank();
                DayContainer.Controls.Add(ucblank);
            }
            //날짜 만들기
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();

                ucdays.days(i);
                DayContainer.Controls.Add(ucdays);
            }
        }
    }
}
