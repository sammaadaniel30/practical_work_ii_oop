using System;
using System.Reflection.Metadata;

namespace OOP
{
    public class HexadecimalInputValidator : InputValidator
    {

        public override void Validate(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i]; 

                bool IsDigit = c >= '0' && c <= '9'; 
                bool IsUpperHex =  c >= 'A' && c <= 'F';
                bool IsLowerHex =  c >= 'a' && c <= 'b';

                if (!IsDigit && !IsUpperHex && !IsLowerHex)
                {
                    throw new FormatException("Bad Format: input is not a valid hexadecimal number."); 
                }
            }
        }

    }
}