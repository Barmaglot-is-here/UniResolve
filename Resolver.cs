using System;
using System.Collections.Generic;

namespace UniResolve
{
    public static class Resolver
    {
        private static readonly Dictionary<Type, object> _services;

        static Resolver()
        {
            _services = new();
        }

        public static void Register(object obj)
        {
            var type = obj.GetType();

            if (_services.ContainsKey(type))
                throw new RegistrationException($"Service already registred: {type}");

            _services.Add(type, obj);
        }

        public static void RegisterRange(IEnumerable<object> range)
        {
            foreach (object obj in range)
                Register(obj);
        }

        public static void Remove<TService>()
        {
            Type type = typeof(TService);

            _services.Remove(type);
        }

        public static TService Request<TService>()
        {
            Type type = typeof(TService);

            return (TService)_services[type];
        }
    }
}
