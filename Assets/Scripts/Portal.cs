using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private PortalGun m_Owner;

    private Material m_Material;

    void Awake()
    {
        m_Material = GetComponent<MeshRenderer>().material;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetColor( Color color )
    {
        m_Material.color = color;
    }

    public Color GetColor()
    {
        return m_Material.color;
    }

    public void SetOwner( PortalGun player )
    {
        m_Owner = player;
    }
}
