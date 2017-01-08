using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    [SerializeField]
    private Portal m_PortalPrefab;

    [SerializeField]
    private LayerMask m_LegalSurfaceLayers;

    [SerializeField]
    private string m_LegalSurfaceTag, m_PortalTag;

    private Portal m_PortalA, m_PortalB;
    public Portal PortalA { get { return m_PortalA; } }
    public Portal PortalB { get { return m_PortalB; } }

    [SerializeField]
    private float m_MaxGunRange = 100f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Portal ShootPortalA()
    {
        Portal portal = ShootPortal();
        if (portal != null)
        {
            if (m_PortalA != null) Destroy(m_PortalA.gameObject);
            portal.SetColor(Color.blue);
            m_PortalA = portal;
        }

        return portal;
    }

    public Portal ShootPortalB()
    {
        Portal portal = ShootPortal();
        if (portal != null)
        {
            if (m_PortalB != null) Destroy(m_PortalB.gameObject);
            portal.SetColor(new Color(1f, .4f, .0f));
            m_PortalB = portal;
        }

        return portal;
    }

    private Portal ShootPortal()
    {
        RaycastHit hit;

        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;

        Ray ray = new Ray(origin + (direction * .51f), direction);

        if (Physics.Raycast(ray, out hit, m_MaxGunRange))
        {
            string hitTag = hit.transform.tag;
            if (hitTag == m_LegalSurfaceTag || hitTag == m_PortalTag)
            {
                GameObject toInstantiate = m_PortalPrefab.gameObject;

                Vector3 position = hit.point + (hit.normal * .01f);

                Vector3 dir = hit.point - this.transform.position;
                Vector3 angles = Quaternion.LookRotation(-hit.normal).eulerAngles;

                if (Mathf.Abs(hit.normal.y) == 1f)
                {
                    angles.y = Quaternion.LookRotation(dir).eulerAngles.y;
                }

                Quaternion eulerRot = Quaternion.Euler(angles);

                // If there's any existing portal in the way, destroy it and raycast again to get the right position for the new portal
                if (hitTag == m_PortalTag)
                {
                    Destroy(hit.transform.gameObject);
                    if (Physics.Raycast(ray, out hit, m_MaxGunRange, m_LegalSurfaceLayers)) position = hit.point + (hit.normal * .01f);
                }

                Portal portal = Instantiate(toInstantiate, position, eulerRot).GetComponent<Portal>();
                portal.SetOwner(this);

                return portal;
            }
        }

        return null;
    }
}
