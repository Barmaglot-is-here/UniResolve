using System.Linq;
using System.Reflection;
using UnityEngine;

namespace UniResolve
{
    public abstract class MonoRegistrationContainer : MonoBehaviour
    {
        public void Register()
        {
            FieldInfo[] fields = GetType().GetFields(BindingFlags.Public |
                                             BindingFlags.NonPublic |
                                             BindingFlags.Instance);

            var classFields = fields.Where(field => field.GetType().IsClass);

            Resolver.RegisterRange(classFields.Select(x => x.GetValue(this)));
        }
    }
}
