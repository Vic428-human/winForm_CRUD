using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

namespace CRUD.Data
{
    /// <summary>
    /// DatabaseHelper - 類似 React 中的「資料庫工具類」（Utility / Context Provider）
    /// 負責管理 SQLite 資料庫的初始化與連線
    /// </summary>
    public static class DatabaseHelper
    {
        // private static readonly = React 中的 useMemo + const（只計算一次，永遠不變）
        // 相當於在 App 一開始就決定好的「全域設定」
        private static readonly string AppFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "CS Software");

        // 資料庫檔案完整路徑（類似把資料庫當成一個「本地 JSON 檔案」來管理）
        
        private static readonly string DbPath = Path.Combine(AppFolder, "SalesDB.db"); // ← 字串插值（Interpolated String）

        // 連線字串（Connection String）→ 就像後端 API 的 baseURL
        private static readonly string ConnectionString = $"Data Source={DbPath}"; //$ 符號在 C# 裡的作用 = JavaScript 的反引號 `（模板字串）

        /// <summary>
        /// 初始化資料庫 - 類似 React 中的 useEffect(() => { ... }, []) 
        /// 只在應用程式第一次啟動時執行一次
        /// </summary>
        /// TODO: 接下來從這邊讀
        public static void InitializeDatabase()
        {
            // 1. 確保資料夾存在（類似 fs.mkdirSync）
            if (!Directory.Exists(AppFolder))
                Directory.CreateDirectory(AppFolder);

            // 2. 如果資料庫檔案不存在，就從專案裡的「Data」資料夾複製一份出來
            //    這是桌面應用常見的「首次安裝時初始化資料庫」技巧
            if (!File.Exists(DbPath))
            {
                // AppDomain.CurrentDomain.BaseDirectory ≈ React 專案中的 __dirname 或 process.cwd()
                string sourceDb = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Data",
                    "SalesDB.db");

                // 把專案內建的預設資料庫複製到使用者電腦的 AppData 資料夾
                File.Copy(sourceDb, DbPath);
            }
        }

        /// <summary>
        /// 取得資料庫連線 - 類似 React 中建立一個「資料庫實例」
        /// 每次要操作資料庫時都要呼叫這個方法
        /// </summary>
        public static SQLiteConnection GetConnection()
        {
            // 返回一個新的連線物件（類似 new AxiosInstance 或 new PrismaClient）
            return new SQLiteConnection(ConnectionString);
        }
    }
}
