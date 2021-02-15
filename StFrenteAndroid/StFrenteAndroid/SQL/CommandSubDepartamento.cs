using SQLite;
using StFrenteAndroid.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.SQL
{
    public class CommandSubDepartamento
    {
        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool CriarBancoSubDepartamento()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.CreateTable<SubDepartamento>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }

        public bool DeletarSubDepartamento()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.DropTable<SubDepartamento>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }

        public bool InserirSubDepartamento(SubDepartamento SQLServ)
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

        public List<SubDepartamento> GetSubDepartamento()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    return conexao.Query<SubDepartamento>("SELECT * FROM SubDepartamento");
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return null;
            }
        }


        public List<SubDepartamento> GetSubDepartamentoByDprt(int Cod)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    return conexao.Query<SubDepartamento>("SELECT * FROM SubDepartamento where CdDepartamento = "+ Cod);
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return null;
            }
        }

        public List<SubDepartamento> GetTabSubDepartamento()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    return conexao.Query<SubDepartamento>("SELECT t1.CodSubDepartamento, t1.Descricao,t1.CdDepartamento , t2.Descricao as DescriDepart FROM SubDepartamento t1 LEFT JOIN Departamento t2 on(t1.CodSubDepartamento = t2.IdDepart)");

                    // SELECT t1.CodSubDepartamento, t1.Descricao, t2.Descricao as DescriDepart FROM SubDepartamento t1 INNER JOIN Departamento t2 on(t1.CodSubDepartamento = t2.IdDepart)
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return null;
            }
        }


        public List<SubDepartamento> GetMax()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    return conexao.Query<SubDepartamento>("SELECT * FROM SubDepartamento order by CodSubDepartamento desc LIMIT 1");
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return null;
            }
        }


        public bool DeletarSubDepartamento(SubDepartamento sql)
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
    }
}
