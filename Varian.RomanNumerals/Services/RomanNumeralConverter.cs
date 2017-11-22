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
        public RomanNumeral Convert(int number)
        {
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
            {2, RomanMarker.Fifty}
        };

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
                if (PositionToHalfInterval.ContainsKey(position))
                {
                    return PositionToHalfInterval[position].ToString();
                }
                else
                {
                    if(position == 3)
                    {
                        return "CCCCC";
                    }
                    else if(position == 4)
                    {
                        return "MMMMM";
                    }                    
                }
                return PositionToMarkers[position].ToString() + PositionToHalfInterval[position];
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
                if(position < 4)
                {
                    return PositionToMarkers[position].ToString() + PositionToMarkers[position + 1];
                }
            }


            throw new Exception("um..");
            
        }

        public RomanNumeral Convert(long number)
        {
            throw new NotImplementedException();
        }
    }
}
