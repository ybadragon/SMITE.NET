using System;

namespace SMITEAPI.Implementations
{
    internal class ReturnTypeAttribute : Attribute
    {
        public Type Type { get; set; }
        public ReturnTypeAttribute(Type type)
        {
            Type = type;
        }
    }
}