using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniResolve
{
    public class SceneRegistrationContainer : MonoBehaviour
    {
        public void Register()
        {
            var components  = GetComponents();
            components      = Filter(components);

            Resolver.RegisterRange(components);
        }

        private IEnumerable<Component> GetComponents()
        {
            IEnumerable<Component> components = Array.Empty<Component>();

            foreach (Transform child in transform)
            {
                IEnumerable<Component> childComponents = child.GetComponents<Component>();

                components = components.Concat(childComponents);
            }

            return components;
        }

        private IEnumerable<Component> Filter(IEnumerable<Component> components)
            => components.Where(component => component.GetType().Namespace != "UnityEngine");
    }
}
