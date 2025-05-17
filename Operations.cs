using System; 

namespace OOP 
{
    public class Operations
    {
        private List<string> operations; 

        private string separator; 

        public Operations(string separator)
        {
            this.operations = new List<string>(); 
            this.separator = separator; 
        }

        public void AddOperations(string input, string output, int conversion, int error, string errorMessage)
        {
            string operation = ""; 
            
            operation += input + separator; 
            operation += output + separator;
            operation += conversion.ToString() + separator;
            operation += error.ToString() + separator;
            operation += errorMessage;

            this.operations.Add(operation);      
        }

        public void SaveOperations(string filePath)
        {
            StreamWriter? writer = null; 

            try 
            {
                writer = new StreamWriter(filePath); 

                writer.Write("input" + this.separator); 
                writer.Write("output" + this.separator);
                writer.Write("conversation" + this.separator); 
                writer.Write("error" + this.separator); 
                writer.Write("error_message");


                foreach (string line in this.operations)
                {
                    writer.WriteLine(line); 
                }


            }
            catch (IOException ex)
            {
                Console.WriteLine($"IO error: {ex.Message}"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}"); 
            }
            finally
            {
                writer?.Close(); 
            }
        }
    }

}