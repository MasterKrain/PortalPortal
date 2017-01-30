using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DynamicLayering : MonoBehaviour
{
    [SerializeField]
    private LayerMask m_LayerOnEnter, m_LayerOnExit;

    [SerializeField]
    private string m_UserTag;

    void OnTriggerEnter( Collider other )
    {
        if (other.gameObject.tag == m_UserTag)
        {
            other.gameObject.layer = m_LayerOnEnter;
        }
    }

    void OnTriggerExit( Collider other )
    {
        if (other.gameObject.tag == m_UserTag)
        {
            other.gameObject.layer = m_LayerOnExit;
        }
    }
}
