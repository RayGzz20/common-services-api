using System.Reflection;

namespace AppCommonServices.Application
{
    public class ApplicationAssemblyReference
    {
        internal static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
    }
}
