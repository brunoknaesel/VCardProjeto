using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVCardMVC.Models
{
    public static class DBComands
    {
        static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
        {
            DataSource = "testeandre.database.windows.net",
            UserID = "testeandre",
            Password = "Database@1234",
            InitialCatalog = "testeAndre"
        };

        public static SqlConnection conn = new SqlConnection(builder.ConnectionString);
        //public static SqlConnection conn = new SqlConnection(@"Source=testeandre.database.windows.net;Initial Catalog=testeAndre;User ID=testeandre;Password=********;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //public static MySqlConnection conn = new MySqlConnection(@"Data Source=testeandre.database.windows.net;Initial Catalog=testeAndre;Persist Security Info=False;User ID=testeandre;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False");
        //public static MySqlConnection conn = new MySqlConnection(@"Server=tcp:testeandre.database.windows.net,1433;Initial Catalog=testeAndre;Persist Security Info=False;User ID=testeandre;Password=Database@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //public static SqlConnection conn = new SqlConnection(@"Server=tcp:testeandre.database.windows.net,1433;Initial Catalog=testeAndre;Persist Security Info=False;User ID=testeandre;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        public static SqlCommand cmd;
        public static SqlDataReader dr;



        public static bool TesteUpdate()
        {
            bool temp = true;
            string update = $"UPDATE dbo.ClientePF SET Nome = 'Bruno' WHERE Nome = 'andreee'";
            cmd = new SqlCommand(update, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return temp;
        }


        /// <summary>
        /// Esta função faz um insert completo PF recebendo string de entrada.
        /// Por padrao os status entram como Pendente (1) aguardando aprovação do Admin
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>

        //classe testeBDAntigo
        //public static bool InsertClientePF(string nome, string email, string cpf, string dataNasc, string fone, string cep, string cidade, string rua, string bairro, string tempoExp, string ramo)
        //{
        //    int status = 1;
        //    //status = 0 - Inativo             //status = 1 - Pendente             //status = 2 - Ativo
        //    nome = "José";
        //    cpf = "047.489";
        //    email = "andre@loja";
        //    dataNasc = "01/01/2000";
        //    fone = "(47) 99119-8080";
        //    cep = "89040-300";
        //    cidade = "Timbo";
        //    rua = "Rua dos Caçadores";
        //    bairro = "Velha";
        //    tempoExp = "10";
        //    ramo = "Pedreiro";


        //    string insert = $"Insert into dbo.ClientePF (Nome, Email, CPF, Nascimento, Fone, Cep, Cidade, Rua, Bairro, TempoExperiencia, RamoAtiv1, Status) values ('{nome}','{email}','{cpf}','{dataNasc}','{fone}','{cep}','{cidade}','{rua}','{bairro}','{Convert.ToInt32(tempoExp)}', '{ramo}', {status} )";
        //    cmd = new SqlCommand(insert, conn);
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    conn.Close();

        //    return true;
        //}

        /// <summary>
        /// Esta função faz um insert completo PF recebendo string de entrada.
        /// Por padrao os status entram como Pendente(1) aguardando aprovação do Admin
        /// </summary>
        /// <param name = "elementos" ></ param >
        /// < returns ></ returns >
        public static bool InsertClientePF(string nome, string email, string cpf, string dataNasc, string fone, string cep, string cidade, string rua, string bairro, string tempoExp, string ramo)
        {
            int status = 1;
            //status = 0 - Inativo             //status = 1 - Pendente             //status = 2 - Ativo
            nome = "ANdre";
            cpf = "a22656";
            email = "blabla@blabla";
            dataNasc = "01/05/2000";
            fone = "(47) 12345-8080";
            cep = "89040-300";
            cidade = "Blu";
            rua = "Rua XV";
            bairro = "Centro";
            tempoExp = "12";
            ramo = "Pedreiro";


            string insert = $"Insert into dbo.endereco (Cep, Cidade, Rua, Bairro) values ('{cep}','{cidade}','{rua}','{bairro}')";
            cmd = new SqlCommand(insert, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            insert = $"Insert into dbo.pessoa (Nome, Email, Fone, TempoExperiencia, RamoAtiv1, Status) values ('{nome}','{email}','{fone}','{Convert.ToInt32(tempoExp)}', '{ramo}', {status} )";
            cmd = new SqlCommand(insert, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            int idEnd = 0;
            int idPessoa = 0;

            string select = "Select Top(1) * FROM dbo.endereco ORDER BY idend DESC";
            cmd = new SqlCommand(select, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idEnd = Convert.ToInt32(dr["idend"]);
            }
            dr.Close();
            conn.Close();

            select = "Select Top(1) * FROM dbo.pessoa ORDER BY idtable1 DESC";
            cmd = new SqlCommand(select, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idPessoa = Convert.ToInt32(dr["idtable1"]);
            }
            dr.Close();
            conn.Close();




            insert = $"Insert into dbo.pf (CPF, Nascimento, end_idend, pessoa_idtable1) values ('{cpf}','{dataNasc}',{idEnd}, {idPessoa} )";
            cmd = new SqlCommand(insert, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        public static bool InsertClientePJ(string nome, string email, string cnpj, string dataFund, string fone, string cep, string cidade, string rua, string bairro, string tempoExp, string ramo)
        {
            int status = 1;
            //status = 0 - Inativo             //status = 1 - Pendente             //status = 2 - Ativo
            nome = "Dematec Mat Constr. Ltda";
            cnpj = "00.630.803/0001-20";
            email = "dematec@";
            dataFund = "15/10/2020";
            fone = "(47) 99119-1010";
            cep = "89046-001";
            cidade = "Pomerode";
            rua = "Rua XV Novembro";
            bairro = "Centro";
            tempoExp = "5";
            ramo = "Eletricista";

            string insert = $"Insert into dbo.endereco (Cep, Cidade, Rua, Bairro) values ('{cep}','{cidade}','{rua}','{bairro}')";
            cmd = new SqlCommand(insert, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            insert = $"Insert into dbo.pessoa (Nome, Email, Fone, TempoExperiencia, RamoAtiv1, Status) values ('{nome}','{email}','{fone}','{Convert.ToInt32(tempoExp)}', '{ramo}', {status} )";
            cmd = new SqlCommand(insert, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            int idEnd = 0;
            int idPessoa = 0;

            string select = "Select Top(1) * FROM dbo.endereco ORDER BY idend DESC";
            cmd = new SqlCommand(select, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idEnd = Convert.ToInt32(dr["idend"]);
            }
            dr.Close();
            conn.Close();

            select = "Select Top(1) * FROM dbo.pessoa ORDER BY idtable1 DESC";
            cmd = new SqlCommand(select, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idPessoa = Convert.ToInt32(dr["idtable1"]);
            }
            dr.Close();
            conn.Close();




            insert = $"Insert into dbo.pj (CNPJ, DataFund, end_idend, pessoa_idtable1) values ('{cnpj}','{dataFund}',{idEnd}, {idPessoa} )";
            cmd = new SqlCommand(insert, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return true;
        }


        //public static bool InsertClientePJ(string nome, string email, string cnpj, string dataFund, string fone, string cep, string cidade, string rua, string bairro, string tempoExp, string ramo)
        //{
        //    int status = 1;
        //    status = 0 - I //    nome = "Dematec Mat Constr. Ltda";
        //    cnpj = "00.630.803/0001-20";
        //    email = "dematec@";
        //    dataFund = "15/10/2020";
        //    fone = "(47) 99119-1010";
        //    cep = "89046-001";
        //    cidade = "Pomerode";
        //    rua = "Rua XV Novembro";
        //    bairro = "Centro";
        //    tempoExp = "5";
        //    ramo = "Eletricista";nativo             //status = 1 - Pendente             //status = 2 - Ativo


        //    string insert = $"Insert into dbo.ClientePJ (Nome, Email, CNPJ, DataFund, Fone, Cep, Cidade, Rua, Bairro, TempoExperiencia, RamoAtiv1, Status) values ('{nome}','{email}','{cnpj}','{dataFund}','{fone}','{cep}','{cidade}','{rua}','{bairro}','{Convert.ToInt32(tempoExp)}', '{ramo}', {status} )";
        //    cmd = new SqlCommand(insert, conn);
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    conn.Close();

        //    return true;
        //}

        public static bool SelectClienteView(string ramoativ, out List<Pessoa> listapessoa) //string ramoativ, out List<Pessoa> listapessoa
        {
            bool temp = true;
            //string ramoativ = "Eletricista";
            // List<Pessoa> listapessoa = new List<Pessoa>();
            listapessoa = new List<Pessoa>();
            string select = $"Select * FROM dbo.pessoa WHERE  RamoAtiv1 = '{ramoativ}' ORDER BY nome DESC";
            cmd = new SqlCommand(select, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = Convert.ToString(dr["nome"]);
                pessoa.Fone = Convert.ToString(dr["Fone"]);
                pessoa.TempoExperiencia = Convert.ToInt32(dr["TempoExperiencia"]);
                //pessoa.Bairro = Convert.ToString(dr["Bairro"]);

                listapessoa.Add(pessoa);
            }
            dr.Close();
            conn.Close();

            string truncate = "TRUNCATE TABLE  dbo.TesteSelectAndre";
            cmd = new SqlCommand(truncate, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            foreach (var item in listapessoa)
            {
                //string insert = $"Insert into dbo.TesteSelectAndre (Nome, Fone, TempExp, Bairro) values ('{item.Nome}','{item.Fone}',{item.TempoExperiencia}, '{item.Bairro}' )";
                string insert = $"Insert into dbo.TesteSelectAndre (Nome, Fone, TempExp) values ('{item.Nome}','{item.Fone}',{item.TempoExperiencia} )";
                cmd = new SqlCommand(insert, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            return temp;
        }



        public static bool SelectClientesPendentes()
        {
            // select  .. (out string[] elementos)
            //string insert = $"Select * from dbo.ClientePF";

            //elementos = new string[] { "oi" };

            //ClientePF clientePF = new ClientePF();
            //clientePF.Nome = nome;
            //clientePF.Cpf = cpf;
            //clientePF.Email = email;
            //clientePF.Nascimento = dataNasc;
            //clientePF.FoneWhats = fone;
            //clientePF.Nome = nome;


            return true;
        }




    }
}
