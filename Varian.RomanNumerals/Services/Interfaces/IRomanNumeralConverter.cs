using Varian.RomanNumerals.Model;

namespace Varian.RomanNumerals.Services.Interfaces
{
    public interface IRomanNumeralConverter
    {
        RomanNumeral Convert(int number);        
    }
}
