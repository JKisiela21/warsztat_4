using System;
using System.Collections.Generic;
using System.Linq;

namespace warsztat4
{
    public class StringCalculator
    {

        public int Add(string numbers)
        {
            var negativeNumbers = new List<int>();
            try
            {
                List<string> defaultDelimiter = new List<string>() ;
                defaultDelimiter.Add("\n");
                var sum = 0;

                if (String.IsNullOrEmpty(numbers))
                {
                    return sum;
                }

                if (numbers.StartsWith("//["))
                {
                    var index = numbers.IndexOf('\n');
                    var delimiters = numbers.Substring(2, index - 2).Split('[', ']'); 
                    defaultDelimiter.AddRange(delimiters.Where(x => x != ""));
                    numbers = numbers.Substring(index + 1);
                }
                else if (numbers.StartsWith("//"))
                {
                    var index = numbers.IndexOf('\n');
                    defaultDelimiter.Add(numbers.Substring(2, index-2));
                    numbers = numbers.Substring(index+1);
                }else
                {
                    defaultDelimiter.Add(",");
                }

                string[] numString = numbers.Split(defaultDelimiter.ToArray(), StringSplitOptions.None);

                foreach (var str in numString)
                {
                    var number = int.Parse(str);
                    if(number < 0)
                    {
                        negativeNumbers.Add(number);
                    }else
                    {
                        if(number <= 1000)
                        sum += number;
                    }
                    
                }

                if(negativeNumbers.Count > 0)
                {
                    string strNumbers = String.Join(",", negativeNumbers);

                    throw new ArgumentException($"negatives not allowed {strNumbers}");
                }

                return sum;
            }catch(FormatException e)
            {
                throw e;
            }
            

        }

    }
}
