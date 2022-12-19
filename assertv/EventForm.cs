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
    public partial class EventForm : Form
    {
        // 문자열 생성
        private string StrSQL = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Database.accdb;Mode=ReadWrite"; //데이터베이스 연결 문자열

        public EventForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //이부분이 문제의 데이터 베이스..... 
        private void button1_Click(object sender, EventArgs e)
        {
            var Conn = new OleDbConnection(StrSQL);
            String sql = "INSERT INTO t_info(e_date,event)VALUES('"; sql+=this.txdate.Text+"', '" +this.txevent.Text+"')";
            OleDbCommand Comm = new OleDbCommand(sql, Conn);
            Conn.Open();
            Comm.ExecuteNonQuery();
            Comm.Dispose();
            MessageBox.Show("저장 되었습니다.");
            Conn.Close();
            this.Close();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            //lets call the static variables we declare
            txdate.Text = Form1.static_year + "-" + Form1.static_month+ "-"+ UserControlDays.static_day;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
    }
}
