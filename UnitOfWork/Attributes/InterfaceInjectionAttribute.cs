using System;

namespace UnitOfWork.Attributes
{
    public class InterfaceInjectionAttribute: Attribute
    {
        public Type InterfaceType { private get; set; }
    }
}