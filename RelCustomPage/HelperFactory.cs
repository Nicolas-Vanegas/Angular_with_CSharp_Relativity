using Relativity.API;

namespace RelCustomPage
{
    public class HelperFactory
    {
        public static ICPHelper GetHelper()
        {
            var helper = Relativity.CustomPages.ConnectionHelper.Helper();
            return helper;
        }
    }
}
