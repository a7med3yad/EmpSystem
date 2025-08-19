using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EmpSystem
{

    public partial class Form1 : Form
    {
        const string connectionString = "Data Source=MEMO;Initial Catalog=TestDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        public SqlConnection conn = new SqlConnection(connectionString);
        byte[] imageBytes;
        public Form1()
        {

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string name = txt_name.Text;
                string job = txt_job.Text;
                double salary = double.Parse(txt_salary.Text);

                SqlCommand cmd = new SqlCommand("INSERT INTO employees (name, job, salary,Photo) VALUES (@name, @job, @salary,@photo)", conn);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@job", job);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = imageBytes;

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Record inserted successfully ✅");
                }
                else
                {
                    MessageBox.Show("No data was inserted ❌");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number for the salary!", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

        }
        private void cbx_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT Photo FROM Employees WHERE Name = @item", conn);
                cmd.Parameters.AddWithValue("@item", cbx_name.SelectedItem.ToString());

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (dr["Photo"] != DBNull.Value)
                    {
                        byte[] imgData = (byte[])dr["Photo"];
                        using (MemoryStream ms = new MemoryStream(imgData))
                        {
                            pic.Image = Image.FromStream(ms);
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No image found for this employee.");
                        pic.Image = null;
                    }
                }
                else
                {
                    MessageBox.Show("Employee not found.");
                }

                dr.Close();
            }


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadEmployeeNames();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadEmployeeNames();
        }


        private void LoadEmployeeNames()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT Name FROM Employees where IsDeleted = 0", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                cbx_name.Items.Clear(); 

                while (dr.Read())
                {
                    cbx_name.Items.Add(dr["Name"].ToString());
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {

            string oldName = (string)cbx_name.SelectedItem;

            if (MessageBox.Show("Update Name?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string newName = Interaction.InputBox("Enter new name:", "Input Required", oldName);

                if (!string.IsNullOrWhiteSpace(newName))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE Employees SET Name = @newName WHERE Name = @oldName", conn))
                        {
                            cmd.Parameters.AddWithValue("@newName", newName);
                            cmd.Parameters.AddWithValue("@oldName", oldName);

                            int rows = cmd.ExecuteNonQuery();
                            MessageBox.Show($"{rows} row(s) updated successfully.");
                            oldName = newName; 
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Update cancelled. No name entered.");
                }
            }

            if (MessageBox.Show("Update Salary?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string salaryInput = Interaction.InputBox("Enter new salary:", "Input Required", "0");

                if (decimal.TryParse(salaryInput, out decimal newSalary))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE Employees SET Salary = @salary WHERE Name = @name", conn))
                        {
                            cmd.Parameters.AddWithValue("@salary", newSalary);
                            cmd.Parameters.AddWithValue("@name", oldName);

                            int rows = cmd.ExecuteNonQuery();
                            MessageBox.Show($"{rows} row(s) updated successfully.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid salary entered.");
                }
            }

            if (MessageBox.Show("Update Job?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string newJob = Interaction.InputBox("Enter new job:", "Input Required", "");

                if (!string.IsNullOrWhiteSpace(newJob))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE Employees SET Job = @job WHERE Name = @name", conn))
                        {
                            cmd.Parameters.AddWithValue("@job", newJob);
                            cmd.Parameters.AddWithValue("@name", oldName);

                            int rows = cmd.ExecuteNonQuery();
                            MessageBox.Show($"{rows} row(s) updated successfully.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Update cancelled. No job entered.");
                }
            }

            if (MessageBox.Show("Update Image?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.jpg; *.png; *.gif)|*.jpg;*.png;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE Employees SET Photo = @photo WHERE Name = @name", conn))
                        {
                            cmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = imageBytes;
                            cmd.Parameters.AddWithValue("@name", oldName);

                            int rows = cmd.ExecuteNonQuery();
                            MessageBox.Show($"{rows} row(s) updated successfully.");
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.png; *.gif)|*.jpg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pic.Image = Image.FromFile(openFileDialog.FileName);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;

                string imagePath = openFileDialog.FileName;

                imageBytes = File.ReadAllBytes(imagePath);

            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MEMO;Initial Catalog=TestDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Employees SET IsDeleted = 1 WHERE Name = @item", conn);

                string item = cbx_name.SelectedItem.ToString();
                cmd.Parameters.AddWithValue("@item", item);

                int rowsAffected = cmd.ExecuteNonQuery();

                MessageBox.Show($"{rowsAffected} row(s) updated successfully.");
            }
        }

        private void src_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string name = src_name.Text.ToString();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Name, Job, Salary, Photo FROM Employees WHERE IsDeleted = 0 AND Name = @name", conn);
                da.SelectCommand.Parameters.AddWithValue("@name", name);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataTable dtDisplay = dt.DefaultView.ToTable(false, "Name", "Job", "Salary");
                    dtg.DataSource = dtDisplay;

                    dtg.AllowUserToAddRows = false;

                    dtg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dtg.ScrollBars = ScrollBars.None;

                    dtg.Height = dtg.Rows.GetRowsHeight(DataGridViewElementStates.Visible)
                                  + dtg.ColumnHeadersHeight;

                    byte[] imageBytes = (byte[])dt.Rows[0]["Photo"];
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pic.Image = Image.FromStream(ms);
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                }
                else
                {
                    MessageBox.Show("No data found.");
                    dtg.DataSource = null;
                    pic.Image = null;
                }
            }
        }
        private void ResetForm()
        {
            if (txt_name != null) txt_name.Clear();
            if (txt_job != null) txt_job.Clear();
            if (txt_salary != null) txt_salary.Clear();

            //if (cbx_name != null) cbx_name.SelectedIndex = -1;

            if (dtg != null) dtg.ClearSelection();
            if (src_name != null) src_name.Clear();

           // if (pic != null) pic.Image = null;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {

                ResetForm(); 

                MessageBox.Show("Saved Successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
