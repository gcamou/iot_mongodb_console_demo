using System;

namespace MongoDbConsoleDemo.Utils
{
    public static class HelperMath
    {
        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }
    
    }
}