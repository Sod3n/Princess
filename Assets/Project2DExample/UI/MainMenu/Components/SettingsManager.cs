using Assets.Project2DExample.Objects;
using Assets.Project2DExample.Saver.Objects;
using Assets.Project2DExample.UI.MainMenu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Project2DExample.UI.MainMenu.Components
{
    public class SettingsManager : MonoBehaviour
    {
        Settings _settings = new Settings();
        SaverManager _saverManager = new SaverManager(new System.Xml.Serialization.XmlSerializer(typeof(Settings)), "settings.xml");
        public Settings Settings 
        { 
            get { return _settings;} 
            set { _settings = value; }
        }
        public void SaveSettings()
        {
            _saverManager.Save(Settings);
            StaticObjects.Settings = Settings;
        }
        private void Start()
        {
            if(StaticObjects.Settings != null)
            {
                Settings = StaticObjects.Settings;
            }
            else
            {
                Settings settings = (Settings)_saverManager.Load();
                if (settings != null)
                {
                    Settings = settings;
                }
                StaticObjects.Settings = Settings;
            }
            
        }
    }
}
