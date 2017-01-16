using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalPortal
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private PortalGun m_PortalGun;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (m_PortalGun != null)
            {
                if (Input.GetButtonDown("Fire1")) m_PortalGun.ShootPortalA();
                if (Input.GetButtonDown("Fire2")) m_PortalGun.ShootPortalB();
            }
        }
    }
}
