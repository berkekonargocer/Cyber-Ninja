using UnityEngine;
using UnityEngine.VFX;

namespace Nojumpo
{
    public class PlayerVFXManager : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] VisualEffect footStepVFX;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void PlayFootstepVFX(bool play) {
            if (play)
            {
                footStepVFX.Play();
            }
            else
            {
                footStepVFX.Stop();
            }
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}