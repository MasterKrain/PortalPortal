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
            Portal portal = Instantiate(m_PortalPrefab.gameObject, hit.point + (hit.normal * .01f), Quaternion.Euler(Quaternion.LookRotation(-hit.normal).eulerAngles)).GetComponent<Portal>();
            portal.SetOwner(this);
            m_OwnedPortals++;
        }
    }
}
