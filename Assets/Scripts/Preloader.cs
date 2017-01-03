using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PortalPortal
{
    public class Preloader : MonoBehaviour
    {
        void Start()
        {
            SceneManager.LoadScene(1);
        }
    }
}
