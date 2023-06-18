using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project2DExample.UI.MainMenu.Components
{
    public class ControllsSelectorSettings : MonoBehaviour
    {
        [SerializeField] SettingsManager _settingsManager;

        public void SetControllsType(TMP_Dropdown change)
        {
            _settingsManager.Settings.ControllsType = (ControllsType)(change.value+1);
        }
        public void SetMouseInverseX(Toggle value)
        {
            _settingsManager.Settings.MouseInverseX = value.isOn;
        }
        public void SetMouseInverseY(Toggle value)
        {
            _settingsManager.Settings.MouseInverseY = value.isOn;
        }
        /*public void SetMouseSensetivity(int value)
        {
            _settingsManager.Settings.MouseSensitivity = value;
        }*/
    }
}
