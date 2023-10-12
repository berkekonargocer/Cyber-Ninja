using UnityEngine;
using UnityEngine.VFX;

namespace Nojumpo
{
    public class EnemyVFXManager : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] VisualEffect footstepVFX;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void Footstep() {
            footstepVFX.SendEvent("OnPlay");
        }
    }
}