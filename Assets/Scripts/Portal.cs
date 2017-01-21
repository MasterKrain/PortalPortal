using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private PortalGun m_Owner;
    public PortalGun Owner { get { return m_Owner; } }

    private Material m_Material;

    private Vector3 m_Angle;
    public Vector3 Angle { get { return m_Angle; } }

    void Awake()
    {
        LoadChildren();
    }

    public void Init( PortalGun player, Vector3 angle )
    {
        m_Owner = player;
        m_Angle = angle;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;

            if (child.name == "PortalMesh") m_Material = child.GetComponent<MeshRenderer>().material;
        }
    }

    public void SetColor( Color color )
    {
        m_Material.color = color;
    }

    public Color GetColor()
    {
        return m_Material.color;
    }
}
