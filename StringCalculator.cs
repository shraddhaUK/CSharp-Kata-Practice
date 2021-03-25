using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PracticeSample
{
    public class StringCalculator
    {
    
    //     public static int Add(string numbers){
    //         int sum=0;
    //         char[] delimiters = GetDelimiters(numbers);
    //         var negativenumbers = new List<int>();
    //         var myList = numbers.Split(delimiters).Select(s =>  s != "" ? int.Parse(s) : 0);
    //         foreach (var item in myList){
    //             if(item<0){
    //                 try{
    //                     negativenumbers.Add(item);
    //                     throw new Exception("Its a negative number");   
    //                 }catch(Exception e){
    //                     Console.WriteLine(e.Message + " "  + String.Join(", ", negativenumbers));
    //                     continue;
    //                 }
    //             }if(item < 1000){
    //                 sum =sum+item;
    //             }
                
    //         };
    //         return sum;
    //     }
    //     public static char[] GetDelimiters(string numbers)
    //     {
    //         var delimiters = new List<char> { ',', '\n','/' };
    //         if(numbers.StartsWith("//"))
    //         {
    //             var delimiterDeclaration = numbers.Split('\n').First();
    //             char  delimiter = delimiterDeclaration.Substring(2,1).Single();
    //             delimiters.Add(delimiter);                
    //         }
 
    //         return delimiters.ToArray();
    //     }

    // }

     public static int Add(string numbers){
            var sum=0;
            string modified =numbers;
            string[] delimiters = new string[]{};
            if(numbers.StartsWith("//"))
            {
                var delimiterDeclaration = numbers.Split('\n').First();
                 delimiters = GetDelimiters(numbers,delimiterDeclaration);
                 modified = numbers.Split('\n').Last();
            }else{
                 delimiters = GetDelimiters(numbers,"");
            }
            
            var negativenumbers = new List<int>();
            string[] result = modified.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
 
             var myList =result.Select(s => s != "" ? int.Parse(s) : 0);
           // var myList = numbers.Split(delimiters).Select(s => s != "" ? int.Parse(s) : 0);
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
                    Console.WriteLine("item :"+item);
                    sum =sum+item;
                }
                
            };
            return sum;
        }
        public static string[] GetDelimiters(string numbers,string delimiterDeclaration)
        {
            var delimiters = new List<string> { ",", "\n","/" };
            var regex = @"\[.*?\]";
            if(numbers.StartsWith("//"))
            {
                MatchCollection matches = Regex.Matches(delimiterDeclaration, regex, RegexOptions.IgnoreCase);
                int count = matches.Count;
                if (count == 0)
                {
                     string  delimiter = delimiterDeclaration.Substring(2,1).Single().ToString();
                     delimiters.Add(delimiter);  
                }else{

                    foreach (Match match in matches)
                        {
                            GroupCollection groups = match.Groups;
                            Console.WriteLine("I am here" + groups[0].Value);
                            string s= (groups[0].Value).Replace("[",string.Empty).Replace("]",string.Empty);
                            Console.WriteLine("delimeter :" + s);
                            delimiters.Add(s);
                        }
                }
               
                             
            }
 
            return delimiters.ToArray();
        }
}

}
