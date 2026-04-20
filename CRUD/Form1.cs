using System.Data;
using CRUD.Data;
namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 連 → 查 → 轉 → 綁
        private void LoadData() // 從資料庫抓 Customers → 轉成 table → 丟給 UI 顯示
        {
            try
            {
                // 連 => 建立資料來源連線 
                using (var con = DatabaseHelper.GetConnection())
                {
                    con.Open();

                    // 查 => 告訴系統你要什麼資料 => Get 
                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Name, Email FROM Customers";

                        /* table.Load(reader) 類似下面這段意思
                            var list = new List<object>();
                            while (reader.Read()) //  一筆一筆讀
                            {
                                list.Add(new
                                {
                                    Id = reader["Id"],
                                    Name = reader["Name"],
                                    Email = reader["Email"]
                                });
                            }
                         */

                        // 執行 SQL，並回傳資料流
                        using (var reader = cmd.ExecuteReader())
                        {
                            var table = new DataTable();
                            // 轉 =>把資料轉成 UI 能吃的格式
                            table.Load(reader);　// 把「讀資料 + 組結構」全部藏起來了
                            // 這裡是把資料綁到 DataGridView（類似 React table component）
                            dgvCustomerDetails.DataSource = table;
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
