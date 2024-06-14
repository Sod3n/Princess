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
    public class GraphicsSettings : MonoBehaviour
    {
        [SerializeField] SettingsManager _settingsManager;
        public void SetResolution(TMP_Dropdown change)
        {
            string res = change.options[change.value].text;
            string[] s = res.Split('×');
            Debug.Log(res);
            _settingsManager.Settings.ScreenHeight = int.Parse(s[1]);
            _settingsManager.Settings.ScreenWidth = int.Parse(s[0]);
            //Screen.SetResolution(_settingsManager.Settings.ScreenWidth, _settingsManager.Settings.ScreenHeight, _settingsManager.Settings.FullScreenMode);
        }
        public void SetFullScreenMode(TMP_Dropdown change)
        {
            switch (change.value)
            {
                case 0:
                    _settingsManager.Settings.FullScreenMode = FullScreenMode.Windowed;
                    break;
                case 1:
                    _settingsManager.Settings.FullScreenMode = FullScreenMode.FullScreenWindow;
                    break; 
                case 2:
                    _settingsManager.Settings.FullScreenMode = FullScreenMode.MaximizedWindow;
                    break;
            }
        }

        public void SetQualityLevel(TMP_Dropdown change)
        {
            _settingsManager.Settings.QualiteLevel = change.value;
        }
    }
}
