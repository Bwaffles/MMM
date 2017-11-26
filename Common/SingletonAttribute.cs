using System;

namespace Common
{
    //Indicates that there should only be one instance of this class for injection
    [AttributeUsage(AttributeTargets.Class)]
    public class SingletonAttribute : Attribute { }
}