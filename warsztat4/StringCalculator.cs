using System;
using System.Collections.Generic;

namespace warsztat4
{
    public class StringCalculator
    {

        public int Add(string numbers)
        {
            var negativeNumbers = new List<int>();
            try
            {
                string defaultDelimiter = ",";
                var sum = 0;

                if (String.IsNullOrEmpty(numbers))
                {
                    return sum;
                }

                if (numbers.StartsWith("//["))
                {
                    var index = numbers.IndexOf('\n');
                    defaultDelimiter = numbers.Substring(2, index - 2);
                    var test = defaultDelimiter.Split('[', ']');
                    numbers = numbers.Substring(index + 1);
                }
                else if (numbers.StartsWith("//"))
                {
                    var index = numbers.IndexOf('\n');
                    defaultDelimiter = numbers.Substring(2, index-2);
                    numbers = numbers.Substring(index+1);
                }

                string[] numString = numbers.Split(new string[] { defaultDelimiter, "\n" }, StringSplitOptions.None);

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
