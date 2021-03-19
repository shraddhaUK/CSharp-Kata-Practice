using System;
using System.Linq;
using System.Collections.Generic;

namespace PracticeSample
{
    public class Class1
    {
    
        public static int Add(string numbers){
            int sum=0;
            char[] delimiters = GetDelimiters(numbers);
            var negativenumbers = new List<int>();
            if(numbers.Length==0)
            return sum;
            var myList = numbers.Split(delimiters).Select(s => int.Parse(s));
            foreach (var item in myList){
                if(item<0){
                    try{
                        negativenumbers.Add(item);
                        throw new Exception("Its a negative number");   
                    }catch(Exception e){
                        Console.WriteLine(e.Message + " "  + String.Join(", ", negativenumbers));
                        continue;
                    }
                }if(item < 1000){
                    sum =sum+item;
                }
                
            };
            return sum;
        }
        public static char[] GetDelimiters(string numbers)
        {
            var delimiters = new List<char> { ',', '\n' };
            if(numbers.StartsWith("//"))
            {
                var delimiterDeclaration = numbers.Split('\n').First();
                char  delimiter = delimiterDeclaration.Substring(2,1).Single();
                delimiters.Add(delimiter);                
            }
 
            return delimiters.ToArray();
        }

    }
}
