using Ninject.Modules;
using Varian.StringTransform.Services.Interfaces;
using Varian.StringTransform.Services;

namespace Varian.StringTransform.DI
{
    public class StringTransformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStringTransform>().To<RomanNumeralStringTransformNumbers>();
        }
    }
}
