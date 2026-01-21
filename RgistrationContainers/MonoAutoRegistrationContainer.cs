using UnityEngine;

namespace UniResolve
{
    public abstract class MonoAutoRegistrationContainer : MonoRegistrationContainer
    {
        [SerializeField]
        private bool _registerOnAwake = true;

        protected virtual void Awake()
        {
            if (_registerOnAwake)
                Register();
        }
    }
}
