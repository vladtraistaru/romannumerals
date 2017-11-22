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
            var romanNumeral = new RomanNumeral()
            {
                Value = number
            };

            if (number == 1)
            {
                romanNumeral.RomanNotation = RomanMarker.One;
                return romanNumeral;
            }

            if (number == 5)
            {
                romanNumeral.RomanNotation = RomanMarker.Five;
                return romanNumeral;
            }

            if (number == 10)
            {
                romanNumeral.RomanNotation = RomanMarker.Ten;
                return romanNumeral;
            }

            if (number == 50)
            {
                romanNumeral.RomanNotation = RomanMarker.Fifty;
                return romanNumeral;
            }

            if (number == 100)
            {
                romanNumeral.RomanNotation = RomanMarker.Houndred;
                return romanNumeral;
            }

            if (number == 1000)
            {
                romanNumeral.RomanNotation = RomanMarker.Thousand;
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
