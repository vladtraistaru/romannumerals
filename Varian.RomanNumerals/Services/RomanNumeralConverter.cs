using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varian.Common;
using Varian.RomanNumerals.Model;
using Varian.RomanNumerals.Services.Interfaces;

namespace Varian.RomanNumerals.Services
{
    public class RomanNumeralConverter : IRomanNumeralConverter
    {
        private Dictionary<int, char> PositionToMarkers = new Dictionary<int, char>()
        {
            {1, RomanMarker.One},
            {2, RomanMarker.Ten},
            {3, RomanMarker.Houndred},
            {4, RomanMarker.Thousand}
        };

        private Dictionary<int, char> PositionToHalfInterval = new Dictionary<int, char>()
        {
            {1, RomanMarker.Five},
            {2, RomanMarker.Fifty},
            {3, RomanMarker.FiveHundred},
        };

        public RomanNumeral Convert(int number)
        {
            if (!number.IsInBetween(1, 3999, true))
            {
                throw new ArgumentException(nameof(number));
            }

            var digits = new List<string>();
            var romanNumeral = new RomanNumeral()
            {
                Value = number
            };

            var position = 0;
            while(number > 0)
            {
                position++;

                var digit = (short)(number % 10);
                number = number / 10;

                var romanDigit = TransformDigit(position, digit);
                if(romanDigit != string.Empty)
                    digits.Insert(0, romanDigit);
            }

            romanNumeral.RomanNotation = digits.Aggregate((a, b) => a + " " + b);
            return romanNumeral;            
        }

        private string TransformDigit(int position, int digit)
        {            
            if(digit == 0)
            {
                return string.Empty;
            }

            if (digit.IsInBetween(1, 3, true))
            {
                return new String(PositionToMarkers[position], digit);
            }

            if (digit == 4)
            {
                return PositionToMarkers[position].ToString() + PositionToHalfInterval[position];
            }

            if (digit == 5)
            {
                return PositionToHalfInterval[position].ToString();                
            }

            if (digit == 6)
            {
                return PositionToHalfInterval[position] + PositionToMarkers[position].ToString();
            }

            if (digit.IsInBetween(7,8,true))
            {
                return PositionToHalfInterval[position] + new String(PositionToMarkers[position], digit - 5);
            }

            if (digit == 9)
            {
                return PositionToMarkers[position].ToString() + PositionToMarkers[position + 1];
            }

            throw new ArgumentException(nameof(digit));
        }        
    }
}
