using System; 
using System.Linq; 

namespace OOP 
{
    public class BinaryToDecimal : Conversion 
    {
        public BinaryToDecimal(string name, string definition) : base(name, definition, new BinaryInputValidator())
        {

            

        }

        public override string Change(string input)
        {
            
           int number = Int32.Parse(input); 

           if (number == 0)
           {

                return "0"; 
           }
            string decimalString = ""; 
            int decimalValue = 0;
            int baseValue = 1; 

            // Convert binary to decimal
            while (number > 0)
            {
                int lastDigit = number % 10;
                decimalValue += lastDigit * baseValue;
                baseValue *= 2;
                number /= 10;
            }

            number = decimalValue; 

            decimalString = number.ToString(); 

            return decimalString;
        }
    }

}