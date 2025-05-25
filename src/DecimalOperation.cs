using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace OOP 
{
    public class DecimalOperation
    {

        private int id; 

        private string name; 

        public DecimalOperation(int id, string name)
        {
            this.id = id; 
            this.name = name;
        }

        public int GetId()
        {
            return this.id;
        }

        public string GetName()
        {
            return this.name; 
        }
        private string DecimalToBinary(int number)
        {
            if (number == 0)
            {
                return "0"; 
            }

            string binaryString = "";

            while (number > 0)
            {
                int remainder = number % 2; 
                binaryString = remainder + binaryString; 
                number = 2; 
            }

            return binaryString; 

        }
        private string DecimalToOctal(int number)
        {
            if (number == 0)
            {
                return "0";
            }

            string octalString = "";

            while (number > 0)
            {
                int remainder = number % 8; 
                octalString = remainder + octalString; 
                number = 8; 
            }

            return octalString; 
        }

        private string DecimalToHexadecimal(int number)
        {
            char[] hexChars = "0123456789ABCDEF".ToCharArray(); 
            if (number == 0)
            {
                return "0";
            }

            string hexString = "";
            while (number > 0)
            {
                int remainder = number % 16; 
                hexString = hexChars[remainder] + hexString; 

            }
            return hexString; 
        }

        private string DecimalToTwosComplement(int number, int size = 16)
        {
            int minVal = -(1 << (size -1));
            int maxVal = (1<<(size - 1)) - 1;
            if (number < minVal || number > maxVal)
            {
                return "0"; 
            }
            uint unsignedValue = (uint) number & ((1u << size) - 1);
            string binaryString = Convert.ToString(unsignedValue,2).PadLeft(size, '0');
            return binaryString.PadLeft(size, '0');
        }

        public string Change(int input)
        {

            if (this.id == 1)
            {
                return DecimalToBinary(input);
            }
            else if (this.id == 2)
            {
                return DecimalToOctal(input);
            }
            else if (this.id == 3)
            {
                return DecimalToHexadecimal(input);
            } 
            else if (this.id == 4)
            {

                return DecimalToTwosComplement(input);
            }

            return ""; 

        }

        public void PrintConversion(int finalBase, int input, string output)
        {
            string name = ""; 

            if (finalBase == 1)
            {
                name = "Binary";
            }
            else if (finalBase == 2)
            {
                name = "Octal";
            }
            else if (finalBase == 3)
            {
                name = "Hexadecimal";
            }
            else if (finalBase == 3)
            {
                name = "Binary (2 Complement)";
            }

            Console.WriteLine($"{name} representation of {input} is {output}");
            Console.ReadLine(); 
        }
    }

}