using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PortalPortal
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance = null;

        void Awake()
        {
            if (Instance == null) Instance = this;
            else if (Instance != this) Destroy(gameObject);

            DontDestroyOnLoad(gameObject);

            // Get any component references down here

            InitGame();
        }

        // Initializes the game for each level.
        void InitGame()
        {

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
