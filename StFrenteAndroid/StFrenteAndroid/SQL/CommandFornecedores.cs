using SQLite;
using StFrenteAndroid.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.SQL
{
    class CommandFornecedores
    {

        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool CriarBancoFornecedores()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.CreateTable<Fornecedores>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }

        public bool DeletarTelaFornecedores()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.DropTable<Fornecedores>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }

        public bool InserirFornecedores(Fornecedores SQLServ)
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

        public List<Fornecedores> GetFornecedores()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    return conexao.Query<Fornecedores>("SELECT * FROM Fornecedores");
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return null;
            }
        }

        public List<Fornecedores> GetFornecedoresByID(int codigo)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    return conexao.Query<Fornecedores>("SELECT * FROM Fornecedores Where Codigo = "+ codigo);
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return null;
            }
        }



        public bool DeletarFornecedoresSQL(Fornecedores sql)
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

        public bool AlterarFornecedores(Fornecedores SQLServ)
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

        public List<Fornecedores> GetFiltroFornecedores(String TipoFilt, String Filtro)
        {
            try
            {
                String Select = "SELECT * FROM Fornecedores";

                if (TipoFilt == "Razao")
                {
                    Select = Select + " Where RazaoSocial like '%"+ Filtro + "%'";
                }
                if (TipoFilt == "Cidade")
                {
                    Select = Select + " Where Cidade like '%" + Filtro + "%'";
                }
                if (TipoFilt == "CNPJ")
                {
                    Select = Select + " Where CNPJ like '%" + Filtro + "%'";
                }

                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    return conexao.Query<Fornecedores>(Select);
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return null;
            }
        }

        public List<Fornecedores> GetMax()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    return conexao.Query<Fornecedores>("SELECT * FROM Fornecedores order by Codigo desc LIMIT 1");
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
