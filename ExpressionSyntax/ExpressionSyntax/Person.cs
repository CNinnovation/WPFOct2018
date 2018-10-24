using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExpressionSyntax
{
    public class Person : BindableBase
    {
        public Person()
        {

        }

        public Person(string firstName, string lastName) =>
            (FirstName, LastName) = (firstName, lastName);
        
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }






    }
}
