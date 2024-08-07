using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace melumat_sisteminin_yaradilmasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connect;
        SqlCommand com;
        SqlDataAdapter da;


        void example()
        {
            connect = new SqlConnection("Data Source=DESKTOP-003N1MJ\\SQLEXPRESS;Initial Catalog=Elchin_diplom;Integrated Security=SSPI");
            connect.Open();
            da = new SqlDataAdapter("SELECT *from dbo.mektublar", connect);
            DataTable cedvel = new DataTable();
            da.Fill(cedvel);
            dataGridView1.DataSource = cedvel;
            connect.Close();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            example();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            /*
                string sual = "DELETE FROM dbo.mektublar where ID=@ID";
                com = new SqlCommand(sual, connect);
                com.Parameters.AddWithValue("@ID", textBox6.Text);
                com.Parameters.AddWithValue("@Movzu", textBox6.Text);
                com.Parameters.AddWithValue("@Kime", textBox6.Text);
                com.Parameters.AddWithValue("@Kimden", textBox6.Text);
                com.Parameters.AddWithValue("@Sobeler", textBox6.Text);

                com.Parameters.AddWithValue("@Gonderilme_tarixi", dateTimePicker1.Text);
                com.Parameters.AddWithValue("@Qebul_tarixi", dateTimePicker2.Text);


                connect.Open();
                com.ExecuteNonQuery();
                connect.Close();
                example();
            */
            

            


        }



        Bitmap bitmap;
        private void button3_Click(object sender, EventArgs e)
        {

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Bitmap imagebmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(imagebmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(imagebmp, 60, 20);

        }





        private void button9_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Movzu adı")
            {

                connect.Open();
                string search = textBox6.Text;

                try
                {
                    SqlCommand comm = new SqlCommand("select * from dbo.mektublar where Movzu=@Movzu", connect);
                    comm.Parameters.AddWithValue("Movzu", textBox6.Text);
                    SqlDataAdapter ads = new SqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    ads.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }

            }

            if (comboBox1.Text == "Mektubun kime unvanlanmasi")
            {

                connect.Open();
                string search = textBox6.Text;       //search evezine axtar yazmisam

                try
                {
                    SqlCommand comm = new SqlCommand("select * from dbo.mektublar where Kime=@Kime", connect);
                    comm.Parameters.AddWithValue("Kime", textBox6.Text);
                    SqlDataAdapter ads = new SqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    ads.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }

            }

            if (comboBox1.Text == "Mektubun kim terefinden yazilmasi")
            {

                connect.Open();
                string look = textBox6.Text; // look axtarmaq ucun istifade olunan bizim verdiyimi bir addı

                try
                {
                    SqlCommand comm = new SqlCommand("select * from dbo.mektublar where Kimden=@Kimden", connect);
                    comm.Parameters.AddWithValue("Kimden", textBox6.Text);
                    SqlDataAdapter ads = new SqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    ads.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }

            }


            if (comboBox1.Text == "Mektubun baslangic ve bitme tarixine uygun")
            {

                label4.Visible = true;
                label5.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;


                SqlConnection con = new SqlConnection("Data Source=DESKTOP-003N1MJ\\SQLEXPRESS;Initial Catalog=Elchin_diplom; Integrated Security = SSPI");
                DataTable ds = new DataTable();
                string sql = "SELECT ID,Movzu,Kime,Kimden,Gonderilme_tarixi,Qebul_tarixi FROM dbo.mektublar WHERE Gonderilme_tarixi BETWEEN @tarix1 and @tarix2";
                SqlDataAdapter ad = new SqlDataAdapter(sql, con);
                ad.SelectCommand.Parameters.AddWithValue("@tarix1", dateTimePicker1.Value);
                ad.SelectCommand.Parameters.AddWithValue("@tarix2", dateTimePicker2.Value);
                con.Open();
                ad.Fill(ds);
                dataGridView1.DataSource = ds;
                con.Close();

            }

            if (comboBox1.Text == "Sobe")
            {

                connect.Open();
                string loook = textBox6.Text;

                try
                {
                    SqlCommand comm = new SqlCommand("select * from dbo.mektublar where Sobeler=@Sobeler", connect);
                    comm.Parameters.AddWithValue("Sobeler", textBox6.Text);
                    SqlDataAdapter ads = new SqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    ads.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }

            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Movzu adı")
            {

                label4.Visible = false;
                label5.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;

            }

            if (comboBox1.Text == "Mektubun kime unvanlanmasi")
            {

                label4.Visible = false;
                label5.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;

            }

            if (comboBox1.Text == "Mektubun kim terefinden yazilmasi")
            {

                label4.Visible = false;
                label5.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;

            }


            if (comboBox1.Text == "Mektubun baslangic ve bitme tarixine uygun")
            {

                label4.Visible = true;
                label5.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;



            }

            if (comboBox1.Text == "Sobe")
            {

                label4.Visible = false;
                label5.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;

            }
        }
    }
}
