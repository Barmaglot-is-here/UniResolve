using UnityEngine;

namespace UniResolve
{
    public class SceneAutoRegistrationContainer : SceneRegistrationContainer
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
