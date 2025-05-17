using System;
using System.Buffers;
using System.Diagnostics.Contracts;

namespace OOP 
{

    public class Converter
    {
        private List<Conversion> operations; 


        
        public Converter()
        {
            this.operations = new List<Conversion>(); 

            this.operations.Add(new DecimalToBinary("Binary", "Decimal to Binary")); 
            this.operations.Add(new DecimalToOctal("Binary", "Decimal to Octal")); 
            this.operations.Add(new DecimalToHexadecimal("Hexadecimal", "Decimal To Hexadecimal")); 
            this.operations.Add(new DecimalToTwoComplement("TwoComplement", "Decimal to Binary(TwoComplement)"));
            this.operations.Add(new BinaryToDecimal("Decimal", "Binary to Decimal")); 
            this.operations.Add(new TwoComplementToDecimal("Decimal", "Binary (TwoComplement) to Decimal"));
            this.operations.Add(new OctalToDecimal("Decimal", "Octal to Decimal")); 
            this.operations.Add(new HexadecimalToDecimal("Decimal", "Hexadecimal to Decimal")); 
            
            
        }

        public int Exit()
        {
            return this.operations.Count + 1; 
        }

        public int GetNumberOperations()
        {
            return this.operations.Count(); 
        }

        // This method will not be neccessary 
        public int PrintOperations()
        {
            Console.WriteLine("-------------------");

            for (int i = 1; i <= this.operations.Count(); i++)
            {
                Console.WriteLine($"{i}. {this.operations[i-1].GetDefinition()} ");

            }
            Console.WriteLine($"{this.Exit()}. Exit");

            string tmp = Console.ReadLine();

            if (tmp == "")
            {
                return this.GetNumberOperations() + 1;
            }

            int option = int.Parse(tmp);

            return (option < 1 || option > this.GetNumberOperations()) ? this.Exit() + 1: option;



        }
        
        

        public string PerformConversion(int op, string input)
        {
            
            this.operations[op-1].Validate(input); 

            if (this.operations[op-1].NeedBitSize())
            {
                Console.WriteLine("How many bits should I use"); 
                int bits = Int32.Parse(Console.ReadLine()); 

                return this.operations[op-1].Change(input, bits); 
            } 

            return this.operations[op-1].Change(input); 
            
        }

        public void PrintConversion(int op, string input, string output)
        {
            this.operations[op-1].PrintConversion(op, input, output);
        }

    }
}