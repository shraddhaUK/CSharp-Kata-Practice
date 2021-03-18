using System;
using System.Linq;
using System.Collections.Generic;

namespace PracticeSample
{
    public class Class1
    {
    
        public static int Add(string numbers){
            int sum=0;
            var negativenumbers = new List<int>();
            if(numbers.Length==0)
            return sum;
            var myList = numbers.Split(new Char [] {',' , '\n' ,';'}).Select(s => int.Parse(s));
            foreach (var item in myList){
                if(item<0){
                    try{
                        negativenumbers.Add(item);
                        throw new Exception("Its a negative number");   
                    }catch(Exception e){
                        Console.WriteLine(e.Message + " "  + String.Join(", ", negativenumbers));
                    }
                } else{ 
                    sum =sum+item;
                }
                
            };
            return sum;
        }
    }
}
