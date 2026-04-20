using System.Data;
using CRUD.Data;
namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.btnDelete.Click += btnDelete_Click;   // 手動掛接事件
        }

        // 連 → 查 → 轉 → 綁
        private void LoadData()
        {
            try
            {
                using (var con = DatabaseHelper.GetConnection())
                {
                    con.Open();

                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Name, Email FROM Customers";

                        using (var reader = cmd.ExecuteReader())
                        {
                            var table = new DataTable();
                            table.Columns.Add("Id");
                            table.Columns.Add("Name");
                            table.Columns.Add("Email");

                            while (reader.Read())
                            {
                                table.Rows.Add(
                                    reader["Id"]?.ToString(),
                                    reader["Name"]?.ToString(),
                                    reader["Email"]?.ToString()
                                );
                            }

                            MessageBox.Show("Rows loaded: " + table.Rows.Count);

                            dgvCustomerDetails.DataSource = null;
                            dgvCustomerDetails.Columns.Clear();
                            dgvCustomerDetails.AutoGenerateColumns = true;
                            dgvCustomerDetails.DataSource = table;

                            MessageBox.Show(
                                $"Grid Columns: {dgvCustomerDetails.Columns.Count}\nGrid Rows: {dgvCustomerDetails.Rows.Count}",
                                "Grid Debug"
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtID.Clear();
            txtName.Clear();
            txtEmail.Clear();
        }

        private void dgvCustomerDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // 使用範例
            //console.log(isNullOrWhiteSpace(null));      // true
            //console.log(isNullOrWhiteSpace(""));        // true
            //console.log(isNullOrWhiteSpace("   "));     // true
            //console.log(isNullOrWhiteSpace("hello"));   // false
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            try
            {
                using (var con = DatabaseHelper.GetConnection())
                {
                    con.Open();
                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Customers (Name, Email) VALUES (@Name, @Email)";
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = DatabaseHelper.GetConnection())
                {
                    con.Open();
                    string query = "DELETE FROM Customers WHERE Id = @Id";

                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@Id", int.Parse(txtID.Text));
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 你點選客戶列表中的某一筆客戶，系統就會自動把這個客戶的資料帶到旁邊的編輯表單，讓你可以修改或刪除
        // Master（主） = DataGridView / table（顯示所有客戶）
        // Detail（從） = 文字框 / form（編輯單一客戶）
        // 當點擊 DataGridView 儲存格時觸發
        private void dgvCustomerDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 如果點到的是標題列（RowIndex < 0），不做事直接返回
            if (e.RowIndex < 0) return;

            // 先列出目前 DataGridView 的所有欄位資訊，方便確認真正的欄位名稱
            string columnInfo = "";

            foreach (DataGridViewColumn col in dgvCustomerDetails.Columns)
            {
                columnInfo += $"Name={col.Name}, HeaderText={col.HeaderText}, DataPropertyName={col.DataPropertyName}\n";
            }

            MessageBox.Show(columnInfo, "欄位資訊");

            // 取得被點擊的那一整列資料
            DataGridViewRow row = dgvCustomerDetails.Rows[e.RowIndex];

            // 先用索引抓值，確認資料本身有沒有進來
            MessageBox.Show(
                $"Cells[0]={row.Cells[0].Value}\nCells[1]={row.Cells[1].Value}\nCells[2]={row.Cells[2].Value}",
                "列資料測試"
            );

            // 正式帶回 TextBox
            txtID.Text = row.Cells[0].Value?.ToString() ?? string.Empty;
            txtName.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
            txtEmail.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
        }
    }
}
