using System;
using System.Collections;

namespace databasePrac.DataBase
{
    
    //User Account Entity done
    public class UserAccount <T> 
    {
        public T Name { get; set; }
        
        public T Surname { get; set; }
        
        public T Car { get; set; }

        
        


        public UserAccount(T name, T surname, T car)
        {
            Name = name;
            Surname = surname;
            Car = car;
            
        }

        public UserAccount()
        {
            
        }
    }
}