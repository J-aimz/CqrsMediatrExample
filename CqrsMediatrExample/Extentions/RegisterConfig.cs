using CqrsMediatrExample.DataStore;
using System.Runtime.CompilerServices;

namespace CqrsMediatrExample.Extentions
{
    public static class RegisterConfig
    {
        public static void AddConfig(this IServiceCollection services)
        {
            //register medaitr
            services.AddMediatR( x => x.RegisterServicesFromAssembly(typeof(Program).Assembly));

            //register db
            services.AddSingleton<FakeDataStore>();
        }
    }
}
