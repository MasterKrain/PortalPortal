using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalPortal
{
    [RequireComponent(typeof(Collider))]
    public class CanUsePortal : MonoBehaviour
    {
        private Collider m_Collider;

        [SerializeField]
        private LayerMask m_PortalLayer;

        void Awake()
        {
            m_Collider = GetComponent<Collider>();
        }

        void Start()
        {

        }

        void Update()
        {
            CheckForPortal();
        }

        private void CheckForPortal()
        {
            Vector3 origin = Camera.main.transform.position;
            Vector3 dir = Camera.main.transform.forward;

            float dist = m_Collider.bounds.extents.x * 1.3f;

            Ray ray = new Ray(origin, dir);

            Debug.DrawRay(origin, dir * dist, Color.red);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, dist, m_PortalLayer))
            {
                Portal portal = hit.transform.parent.GetComponent<Portal>();
                Portal otherPortal = null;

                if (portal == portal.Owner.PortalA) otherPortal = portal.Owner.PortalB;
                else otherPortal = portal.Owner.PortalA;

                if (otherPortal != null) Teleport(otherPortal.transform.position + otherPortal.Angle.normalized * m_Collider.bounds.extents.x);
            }
        }

        private void Teleport( Vector3 position )
        {
            this.transform.position = position;
        }
    }
}
