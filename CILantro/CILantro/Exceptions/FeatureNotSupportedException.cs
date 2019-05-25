using System;

namespace CILantro.Exceptions
{
    public class FeatureNotSupportedException : Exception
    {
        public FeatureNotSupportedException(string featureName)
            : base($"The following feature is not supported: \"{featureName}\".")
        {
        }
    }
}