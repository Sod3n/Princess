using Assets.Project2DExample.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Project2DExample.UI.MainMenu.Components
{
    public class MovementFromUI : MonoBehaviour
    {
        [SerializeField] List<GameObject> AllMainMenuPanels;

        public void DisablePanels()
        {
            foreach (GameObject panel in AllMainMenuPanels)
            {
                panel.SetActive(false);
            }
        }
        public void SetActiveMainPanel(GameObject panel)
        {
            DisablePanels();
            panel.SetActive(true);
        }

        public void OpenScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        public void CloseGame()
        {
            Application.Quit();
        }
    }
}
