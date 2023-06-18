using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Project2DExample.Components
{
    public class StopGame : MonoBehaviour
    {
        public static int GameStoppers = 0;
        bool _gameStopperAdd = false;
        private void Update()
        {
            if(isActiveAndEnabled)
            {
                ControllsSelector.BlockControlls = true;
                Time.timeScale = 0f;
            }
        }
        private void OnDisable()
        {
            GameStoppers--;
            if (GameStoppers == 0)
            {
                Time.timeScale = 1f;
                ControllsSelector.BlockControlls = false;
            }
        }
        private void OnEnable()
        {
            GameStoppers++;
        }
    }
}
