using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Varian.RomanNumerals.Services.Interfaces;
using Varian.StringTransform.Services.Interfaces;

namespace Varian.StringTransform.Services
{
    public class RomanNumeralStringTransformNumbers : StringTransformNumbers
    {
        public IRomanNumeralConverter _romanNumeralConverter;
        public RomanNumeralStringTransformNumbers(IRomanNumeralConverter romanNumeralConverter)
        {
            _romanNumeralConverter = romanNumeralConverter;
        }

        public override string NumberTransformOperation(int number)
        {
            return _romanNumeralConverter.Convert(number).RomanNotation;
        }
    }
}
