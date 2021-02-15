using SQLite;
using StFrenteAndroid.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.SQL
{
   public class CommandNfePadrao
    {

        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool CriarBancoNfePadrao()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.CreateTable<NfePadrao>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }

        public bool DeletarNfePadrao()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.DropTable<NfePadrao>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }

        public bool InserirNfePadrao(NfePadrao SQLServ)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.Insert(SQLServ);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }
        
        public List<NfePadrao> GetNfePadrao()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    return conexao.Query<NfePadrao>("SELECT * FROM NfePadrao");
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return null;
            }
        }

        public List<NfePadrao> GetMax()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    return conexao.Query<NfePadrao>("SELECT * FROM NfePadrao order by Cod_Cel desc LIMIT 1");
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
