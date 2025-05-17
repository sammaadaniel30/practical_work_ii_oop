using System;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace OOP
{
    public class OctalInputValidator : InputValidator
    {

        public override void Validate(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i]; 

                bool IsDigit = c >= '0' && c <= '7'; 


                if (!IsDigit)
                {
                    throw new FormatException("Bad Format: input is not a valid octal number."); 
                }
            }
        }

    }
}