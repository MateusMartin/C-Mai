using SQLite;
using StFrenteAndroid.Assina;
using StFrenteAndroid.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.SQL
{
    public class CommandSaldo
    {

        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool CriarBancoSaldo()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.CreateTable<Saldo>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }

        public bool DeletarSaldo()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.DropTable<Saldo>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }
        public bool InserirSaldo(Saldo SQLServ)
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

        public List<Saldo> GetSaldo()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    return conexao.Query<Saldo>("SELECT * FROM Saldo");
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return null;
            }
        }


        public List<Saldo> GetSaldoIfAberto(String Chave)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    return conexao.Query<Saldo>("SELECT * FROM Saldo where Chave = " + Chave + " and Tipo = 1");
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
