using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalPortal
{
    public class Loader : MonoBehaviour
    {
        public GameObject m_GameManager, m_SoundManager;

        void Awake()
        {
            if (GameManager.Instance == null) Instantiate(m_GameManager);
            if (SoundManager.Instance == null) Instantiate(m_SoundManager);

            Destroy(gameObject);
        }
    }
}
