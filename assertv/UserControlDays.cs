using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace assertv
{
    public partial class UserControlDays : UserControl
    {
        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Database.accdb;Mode=ReadWrite"; //데이터베이스 연결 문자열
        //하루 마다 다른 정적 변수 
        public static string static_day;
        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {
            
            var conn = new OleDbConnection(connString);
            conn.Open();

            var comm = new OleDbCommand("SELECT* FROM t_info", conn);
            var myRead = comm.ExecuteReader();

            OleDbCommand cmd = conn.CreateCommand();
            while (myRead.Read())
            {
                String day = "";
                String month = "";
                if (Convert.ToInt32(lbdays.Text) < 10)
                    day = "0" + lbdays.Text;
                else
                    day = lbdays.Text;
                if (Convert.ToInt32(Form1.static_month.ToString()) < 10)
                    month = "0" + Form1.static_month.ToString();
                else
                    month = Form1.static_month.ToString();

                if (day == myRead["e_date"].ToString().Substring(8,2) && Form1.static_year.ToString() == myRead["e_date"].ToString().Substring(0,4) && month == myRead["e_date"].ToString().Substring(5, 2))
                    lbevent.Text = myRead["event"].ToString();
            }
            conn.Close();
        }
        public void days(int numday) {
            lbdays.Text = numday + "";
        }

        private void lbdays_Click(object sender, EventArgs e)
        {
            static_day = lbdays.Text;
            //start timer if usercontroldays is click
            timer1.Start();
            EventForm eventform = new EventForm();
            eventform.Show();
        }

        //이벤트를 위한 메서드 만들기

        private void displayEvent()
        {
            var conn = new OleDbConnection(connString);
            conn.Open();
            //String sql = "SELECT* FROM t_info";

            var comm = new OleDbCommand("SELECT* FROM t_info", conn);
            var myRead = comm.ExecuteReader();

            while (myRead.Read())
            {
                String day = "";
                String month = "";
                if (Convert.ToInt32(lbdays.Text) < 10)
                    day = "0" + lbdays.Text;
                else
                    day = lbdays.Text;
                if (Convert.ToInt32(Form1.static_month.ToString()) < 10)
                    month = "0" + Form1.static_month.ToString();
                else
                    month = Form1.static_month.ToString();

                if (day == myRead["e_date"].ToString().Substring(8, 2) && Form1.static_year.ToString() == myRead["e_date"].ToString().Substring(0, 4) && month == myRead["e_date"].ToString().Substring(5, 2))
                    lbevent.Text = myRead["event"].ToString();
            }
            conn.Close();
        }
            
        //새 이벤트가 추가된 경우 이벤트를 자동으로 표시
        private void timer1_Tick(object sender, EventArgs e)
        {
            //displayEvent 메서드를 호출합니다.
            displayEvent();
        }





    }
}
