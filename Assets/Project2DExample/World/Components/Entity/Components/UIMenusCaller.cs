using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Components
{
    public class UIMenusCaller : EntityComponent
    {
        [SerializeField] GameObject _mainMenu;

        private void Update()
        {
            if (Entity.ControllsSelector.Controlls.OpenMainMenu)
            {
                _mainMenu.SetActive(!_mainMenu.activeInHierarchy);
            }
        }

    }
}
