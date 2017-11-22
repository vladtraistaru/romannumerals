using Ninject.Modules;
using Varian.RomanNumerals.Services;
using Varian.RomanNumerals.Services.Interfaces;

namespace Varian.RomanNumerals.DI
{
    public class RomanNumeralModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRomanNumeralConverter>().To<RomanNumeralConverter>();
        }
    }
}
