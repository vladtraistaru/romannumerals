using Ninject.Modules;
using Varian.StringParser.Services.Interfaces;
using Varian.StringParser.Services;

namespace Varian.StringParser.DI
{
    public class StringParserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStringParserService>().To<StringParserService>();
        }
    }
}
