using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Varian.StringTransform.Services.Interfaces;

namespace Varian.StringTransform.Services
{
    public abstract class StringTransformNumbers : IStringTransform
    {
        //private static Regex NumberRegex = new Regex("/^[1-9][0-9]*$/");
        private static Regex NumberRegex = new Regex("\\d+");
                  

        public abstract string NumberTransformOperation(int number);

        public string Transform(string original)
        {
            var transformedString = new StringBuilder();

            var matches = NumberRegex.Matches(original);

            if(matches.Count == 0)
            {
                return original;
            }

            var index = 0;
            foreach (Match match in matches)
            {
                var substring = original.Substring(index, match.Index - index);
                transformedString.Append(substring);

                var transformation = NumberTransformOperation(int.Parse(match.Value));
                transformedString.Append(transformation);

                index += substring.Length + match.Value.Length;
            }
            if (index < original.Length)
            {
                transformedString.Append(original.Substring(index, original.Length-index));
            }
            return transformedString.ToString();
        }
    }
}
