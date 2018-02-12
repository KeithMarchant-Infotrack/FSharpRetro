module CSharpToFSharp

open System

(*
    Some C# code to use as a reference
    Not as succinct as it could be with C#6/7 properties & constructor, but representative of common structures
    
    public class Person
    {
        public Person(string name, DateTime birthday)
        {
            _name = name;
            _birthday = birthday;
        }

        private readonly string _name;
        private readonly DateTime _birthday;

        public string Name
        {
            get { return _name; }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
        }

        public int Age
        {
            get { return DateTime.Today.Subtract(_birthday).Days / 365; }
        }
    }

*)

//FSharp example
//Public by default
//Immutable so we don't need get/set methods
//Constructor is automatically generated, although we could write another if we wanted 
//but it would be a function outside the type
//Whitespace used instead of braces & semicolons
//Type declaration after the variable (familiar to typescript devs)
open System
type Person = {
    Name: string
    Birthday: DateTime
}

//Separate Data from the expressions

//Function is implicitly typed
//Whitespace again for function body
//No return needed, F# functions are expressions not subroutines

// age : Person -> int
let age person = 
    DateTime.Today.Subtract(person.Birthday).Days / 365


//This works, example
let keith = {
    Name = "keith";
    Birthday = DateTime.Parse("1987-04-13")
}

age keith


        
