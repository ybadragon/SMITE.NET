using System;
using System.ComponentModel;

namespace SMITEAPI.Implementations
{
    internal class ReturnTypeAttribute : Attribute
    {
        public Type Type { get; set; }
        public ReturnTypeAttribute(Type type)
        {
            Type = type;
        }

        public virtual string Description => typeof(Type).Name;
    }
}