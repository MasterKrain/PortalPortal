using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalPortal
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance = null;

        void Awake()
        {
            if (Instance == null) Instance = this;
            else if (Instance != this) Destroy(gameObject);

            DontDestroyOnLoad(gameObject);

            // Get any component references down here
        }

        void Update()
        {

        }
    }
}
