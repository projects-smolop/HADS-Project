using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic4WA
{
    public class BusinessLogic
    {
        private DataAccess.DataAccess ado = new DataAccess.DataAccess();
        public BusinessLogic() {}
       
        public bool registeUser(string email, string name, string lastName, int numConf, bool isVerify, string type, string password)
        {
           return ado.insertUser(email, name, lastName, numConf, isVerify, type, password); 
        }

        public DataSet getTareasGenericasDataSet()
        {
            return ado.getTareasGenericasDataSet();
        }

        public DataSet getSubjectsProfesorDataSet(string email)
        {
            return ado.getSubjectProfesorDataSet(email);
        }

        public DataSet getTareasGenericasDataSet(string subject)
        {
            return ado.getTareasGenericasDataSet(subject);
        }

        public DataSet getSubjectCodesDataSet(string email)
        {
            return ado.getSubjectDataSet(email);
        }
        public DataSet getOnlySubjectsDataSet(string email)
        {
            return ado.getOnlySubjectDataSet(email);
        }

        public string getUserRole(string email)
        {
            return ado.getUserRole(email);
        }

        public bool correctUser(string email, string role)
        {
            if (!userExists(email))
                return false;
            return ado.correctUser(email, role);
        }

        public bool passwordIsCorrect(string email, string password)
        {
            if (!userExists(email))
                return false;
            String pass = ado.getPassword(email);
            return  password == pass;

        }

        public DataSet getStudentTasksDataSet(string email, string codAsig)
        {
            return ado.getStudenTasksDataSet(email, codAsig);
        }

        public bool userExists(string email)
        {
            return ado.userExists(email);
        }
        
        public string getConfirmNum(string email)
        {
           return ado.getConfirmNum(email);
        }

        public bool confirmUser(string email)
        {
            return ado.confirmUser(email);
        }

        public bool matchConfirmCode(string email, string code)
        {
            String dbCode = ado.getConfirmCode(email);
            return (dbCode == int.Parse(code).ToString());
        }
        
        public bool isPasswordMatched(string password, string repassword)
        {
            return password == repassword;
        }

        public bool changePassword(string email, string password, string repassword)
        {
            bool b = false;
            if (isPasswordMatched(password, repassword))
                if (ado.updatePassword(email, password))
                    b = true;
            return b;
        }

        public List<List<string>> getUSers()
        {
            return ado.getUsers();
        }

        public Boolean updateConfirmNum(string numConf, string email)
        {
            return ado.updateConfirmNum(numConf, email);
        }
    }
}
