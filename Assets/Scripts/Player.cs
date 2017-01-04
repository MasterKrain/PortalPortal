using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Portal m_PortalPrefab;

    [SerializeField]
    private LayerMask m_PortalMask = 8;

    private int m_OwnedPortals;
    public int OwnedPortals { get { return m_OwnedPortals; } }

    // Use this for initialization
    void Start()
    {
        m_OwnedPortals = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnPortal();
        }
    }

    private void SpawnPortal()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10f, m_PortalMask))
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

            Portal portal = Instantiate(toInstantiate, position, eulerRot).GetComponent<Portal>();
            portal.SetOwner(this);

            m_OwnedPortals++;
        }
    }
}
