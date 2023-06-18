using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Components
{
    public class UIMenusCaller : MonoBehaviour
    {
        [SerializeField] Entity _entity;
        [SerializeField] GameObject _mainMenu;

        private void Update()
        {
            if (_entity.ControllsSelector.Controlls.OpenMainMenu)
            {
                _mainMenu.SetActive(!_mainMenu.activeInHierarchy);
            }
        }

    }
}
