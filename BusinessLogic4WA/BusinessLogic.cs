using System;
using System.Collections.Generic;
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

        public bool passwordIsCorrect(string email, string password)
        {
            if (!userExists(email))
                return false;
            String pass = ado.getPassword(email);
            return  password == pass;

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
