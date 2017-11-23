using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varian.RomanNumerals.Model
{
    public class RomanMarker
    {
        public char Marker { get; private set; }

        public static RomanMarker One = new RomanMarker() { Marker = 'I' };
        public static RomanMarker Five = new RomanMarker() { Marker = 'V' };
        public static RomanMarker Ten = new RomanMarker() { Marker = 'X' };
        public static RomanMarker Fifty = new RomanMarker() { Marker = 'L' };
        public static RomanMarker Houndred = new RomanMarker() { Marker = 'C' };
        public static RomanMarker FiveHundred = new RomanMarker() { Marker = 'D' };
        public static RomanMarker Thousand = new RomanMarker() { Marker = 'M' };

        public override string ToString()
        {
            return Marker.ToString();
        }

        public static implicit operator string(RomanMarker marker) { return marker.Marker.ToString(); }
        public static implicit operator char(RomanMarker marker) { return marker.Marker; }
    }
}
