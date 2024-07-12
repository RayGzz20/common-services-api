using System.Reflection;

namespace AppCommonServices.WebAPI
{
    public class PresentationAssemblyReference
    {
        internal static readonly Assembly Assembly = typeof(PresentationAssemblyReference).Assembly;
    }
}
