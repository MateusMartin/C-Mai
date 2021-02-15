using SQLite;
using StFrenteAndroid.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.SQL
{
    class CommandCncm
    {
        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool CriarBancoCNCM()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.CreateTable<CNCM>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }

        public bool DeletarTabelaCNCM()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.DropTable<CNCM>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }

        public bool InserirCNCM(CNCM SQLServ)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.InsertOrReplace(SQLServ);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }

        public List<CNCM> GetCNCM()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    return conexao.Query<CNCM>("SELECT * FROM CNCM");
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return null;
            }
        }


        public bool DeletarCNCMSQL(CNCM sql)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.Delete(sql);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }

        public List<CNCM> GetMax()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    return conexao.Query<CNCM>("SELECT * FROM CNCM order by CodCNCM desc LIMIT 1");
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return null;
            }
        }


    }
}
