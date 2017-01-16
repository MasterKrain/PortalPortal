using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalPortal
{
    public class Portal : MonoBehaviour
    {
        private PortalGun m_Owner;

        private Material m_Material;

        void Awake()
        {
            LoadChildren();
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

        public void SetOwner( PortalGun player )
        {
            m_Owner = player;
        }
    }
}
