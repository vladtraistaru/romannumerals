using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varian.RomanNumerals.Model;
using Varian.RomanNumerals.Services.Interfaces;

namespace Varian.RomanNumerals.Services
{
    public class RomanNumeralConverter : IRomanNumeralConverter
    {
        public RomanNumeral Convert(int number)
        {
            if(number == 1)
            {
                var romanNumeral = new RomanNumeral()
                {
                    RomanNotation = RomanMarker.One,
                    Value = 1
                };
                return romanNumeral;

            }
            throw new NotImplementedException();
        }

        public RomanNumeral Convert(long number)
        {
            throw new NotImplementedException();
        }
    }
}
