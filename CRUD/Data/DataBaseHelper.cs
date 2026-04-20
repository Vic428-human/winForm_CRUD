using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite; // 這個專案實際上連的是 SQLite，而且資料庫檔案位置是 :　C:\Users\你的Windows使用者\AppData\Local\CS Software\SalesDB.db

namespace CRUD.Data
{
    /// <summary>
    /// DatabaseHelper - 類似 React 中的「資料庫工具類」（Utility / Context Provider）
    /// 負責管理 SQLite 資料庫的初始化與連線
    /// </summary>
    public static class DatabaseHelper
    {
        // C:\Users\目前登入的使用者\AppData\Local\CS Software
        private static readonly string AppFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "CS Software");

        //  DbPath：程式執行後，真正要「複製到」使用者電腦上的資料庫位置
        private static readonly string DbPath = Path.Combine(AppFolder, "SalesDB.db");

        private static readonly string ConnectionString = $"Data Source={DbPath}"; // $ 符號在 C# 裡的作用 = JavaScript 的反引號 `（模板字串）

        /// <summary>
        /// 初始化資料庫 - 類似 React 中的 useEffect(() => { ... }, []) 
        /// 只在應用程式第一次啟動時執行一次
        /// </summary>
        /// TODO: 接下來從這邊讀
        public static void InitializeDatabase()
        {
            // 1. 確保資料夾存在（類似 fs.mkdirSync
            if (!Directory.Exists(AppFolder))
                Directory.CreateDirectory(AppFolder);

            // 2. 如果本地資料庫檔案不存在，就從專案裡的 Data 資料夾複製一份出來
            if (!File.Exists(DbPath))
            {
                // sourceDb：專案裡 內建 的預設資料庫位置（開發時用的模板）
                string sourceDb = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Data",
                    "SalesDB.db");

                // 把範本資料庫複製成正式使用的資料庫
                File.Copy(sourceDb, DbPath);
            }
        }

        /// <summary>
        /// 取得資料庫連線 - 類似 React 中建立一個「資料庫實例」
        /// 每次要操作資料庫時都要呼叫這個方法
        /// </summary>
        public static SqliteConnection GetConnection()
        {
            // 返回一個新的連線物件（類似 new AxiosInstance 或 new PrismaClient）
            return new SqliteConnection(ConnectionString);
        }
    }
}
