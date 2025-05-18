using System;
using System.ComponentModel;

namespace OOP 
{
    public class DecimalToTwoComplement : Conversion
    {

        private int size = 16; 

        public DecimalToTwoComplement(string name, string definition) : base(name, definition, new DecimalInputValidator(),true)
        {



        }

        public void SetSize(int size)
        {
            this.size = size; 
        }

        public override string Change(string input)
        {
            int number = Int32.Parse(input); 
            
            // Changed to allow for the implementation of negative values into Two's Complement
            int minVal = -(1 << (this.size - 1)); 
            int maxVal = (1 << (this.size - 1)) - 1; 

            if (number < minVal || number > maxVal)
            throw new ArgumentOutOfRangeException(nameof(input), $"Number must fit with {size} bits");

           

            uint unsignedValue = (uint) number & ((1u << size) - 1); 

            

            string binaryString = Convert.ToString(unsignedValue, 2).PadLeft(size, '0');
       
            return binaryString.PadLeft(size, '0');        
       
        }

        public override string Change(string input, int bits)
        {
            int number = Int32.Parse(input); 
            
            int minVal = -(1 << (bits - 1)); 
            int maxVal = (1 << (bits - 1)) - 1;

            if (number < minVal || number > maxVal)
            throw new ArgumentOutOfRangeException(nameof(input), $"Number must fit with {bits} bits");

           

            uint unsignedValue = (uint) number & ((1u << bits) - 1); 

            

            string binaryString = Convert.ToString(unsignedValue, 2).PadLeft(bits, '0');
       
            return binaryString.PadLeft(bits, '0');        
       
        }

    }
}