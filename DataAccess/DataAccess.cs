using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using Sql.Library;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DataAccess
    {
        private SQL_Query dbManager = new SQL_Query();
        public DataAccess() { }

        Boolean insertQuery()
        {
            Boolean b = false;

            return b;
        }

        public bool insertUser(string email, string name, string lastName, int numConf, bool isVerify, string type, string password)
        {
            StringBuilder queryString = new StringBuilder();
            queryString.AppendFormat("INSERT INTO Usuarios VALUES('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}')", email, name, lastName, numConf, isVerify, type, password);
            return dbManager.insertQuery(queryString.ToString());
        }

        public string getPassword(string email)
        {
            String password = "";
            StringBuilder queryString = new StringBuilder();
            queryString.AppendFormat("SELECT pass FROM Usuarios WHERE email='{0}'", email);
            dbManager.Open();
            SqlDataReader r = dbManager.readQuery(queryString.ToString());
            if (r.Read())
                password =  r[0].ToString();
            dbManager.Close();
            return password;
        }

        public bool userExists(string email)
        {
            Boolean b;
            StringBuilder queryString = new StringBuilder();
            dbManager.Open();
            queryString.AppendFormat("SELECT email FROM Usuarios WHERE email='{0}'", email);
            b = (dbManager.readQuery(queryString.ToString()).HasRows ? true : false);
            dbManager.Close();
            return b;
        }

        public bool confirmUser(string email)
        {
            StringBuilder queryString = new StringBuilder("UPDATE Usuarios SET confirmado='True', numconfir=0");
            return dbManager.updateQuery(queryString.ToString());
        }

        public String getConfirmCode(string email)
        {
            return this.getConfirmNum(email);
        }

        public bool updateConfirmNum(string numConf, string email)
        {
            StringBuilder queryString = new StringBuilder();
            queryString.AppendFormat("UPDATE Usuarios SET numconfir={0} WHERE email='{1}'", numConf, email);
            return dbManager.updateQuery(queryString.ToString());
        }

        public bool updatePassword(string email, string password)
        {
            StringBuilder queryString = new StringBuilder();
            queryString.AppendFormat("UPDATE Usuarios SET pass='{0}' WHERE email='{1}'", password, email);
            return dbManager.updateQuery(queryString.ToString());
        }

        public String getConfirmNum(string email)
        {
            String numConf = "-1";
            StringBuilder queryString = new StringBuilder();
            queryString.AppendFormat("SELECT numconfir FROM Usuarios WHERE email='{0}'", email);
            dbManager.Open();
            SqlDataReader dataReader =  dbManager.readQuery(queryString.ToString());
            if (dataReader.Read())
                numConf = dataReader[0].ToString();
            dbManager.Close();
            return numConf;
        }

        public List<List<string>> getUsers()
        {
            List<List<string>> users = new List<List<string>>();
            dbManager.Open();
            SqlDataReader reader = dbManager.readQuery("SELECT * FROM Usuarios");
            while (reader.Read()) {
                List<String> elements = new List<string>();
                for (int i = 0; i < reader.FieldCount; i++)
                    elements.Add(string.Format("{0}",reader[i]));
                users.Add(elements);
            }
            dbManager.Close();
            return users;
        }

    }
}
