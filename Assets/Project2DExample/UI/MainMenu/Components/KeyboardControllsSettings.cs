using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Assets.Project2DExample.UI.MainMenu.Components
{
    public class KeyboardControllsSettings : MonoBehaviour
    {
        [SerializeField] SettingsManager _settingsManager;
        [SerializeField] GameObject _KeybindingNotification;

        [SerializeField] TMP_Text _moveUp;
        [SerializeField] TMP_Text _moveDown;
        [SerializeField] TMP_Text _moveLeft;
        [SerializeField] TMP_Text _moveRight;
        [SerializeField] TMP_Text _attack;
        [SerializeField] TMP_Text _interact;
        [SerializeField] TMP_Text _flip;
        [SerializeField] TMP_Text _skill1;
        [SerializeField] TMP_Text _skill2;
        [SerializeField] TMP_Text _skill3;
        [SerializeField] TMP_Text _skill4;

        void Start ()
        {
            SetKeysInSettings();
        }
        public void SetKeysInSettings()
        {
            _moveUp.text = _settingsManager.Settings.KeyboardControlls.MoveUpKey.ToString();
            _moveDown.text = _settingsManager.Settings.KeyboardControlls.MoveDownKey.ToString();
            _moveLeft.text = _settingsManager.Settings.KeyboardControlls.MoveLeftKey.ToString();
            _moveRight.text = _settingsManager.Settings.KeyboardControlls.MoveRightKey.ToString();
            _attack.text = _settingsManager.Settings.KeyboardControlls.AttackKey.ToString();
            _interact.text = _settingsManager.Settings.KeyboardControlls.InteractKey.ToString();
            _flip.text = _settingsManager.Settings.KeyboardControlls.FlipKey.ToString();
            _skill1.text = _settingsManager.Settings.KeyboardControlls.SkillsKeys[0].ToString();
            _skill2.text = _settingsManager.Settings.KeyboardControlls.SkillsKeys[1].ToString();
            _skill3.text = _settingsManager.Settings.KeyboardControlls.SkillsKeys[2].ToString();
            _skill4.text = _settingsManager.Settings.KeyboardControlls.SkillsKeys[3].ToString();
        }
        KeyCode _keyCode = KeyCode.Escape;
        bool _keyListen = false;
        int _keyListenId;
        private void Update()
        {
            if (_keyListen)
            {
                foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kcode))
                    {
                        _keyCode = kcode;
                        SetKey();
                        _keyListen = false;
                        _KeybindingNotification.SetActive(false);
                    }
                }
            }
            
        }
        public void ListenKeys(int id)
        {
            _keyListen = true;
            _KeybindingNotification.SetActive(true);
            _keyListenId = id;
        }
        public void SetKey()
        {
            switch (_keyListenId)
            {
                case 0:
                    if (_keyCode != KeyCode.Escape)
                        _settingsManager.Settings.KeyboardControlls.MoveUpKey = _keyCode;
                    break;
                case 1:
                    if (_keyCode != KeyCode.Escape)
                        _settingsManager.Settings.KeyboardControlls.MoveLeftKey = _keyCode;
                    break;
                case 2:
                    if (_keyCode != KeyCode.Escape)
                        _settingsManager.Settings.KeyboardControlls.MoveRightKey = _keyCode;
                    break;
                case 3:
                    if (_keyCode != KeyCode.Escape)
                        _settingsManager.Settings.KeyboardControlls.MoveDownKey = _keyCode;
                    break;
                case 4:
                    if (_keyCode != KeyCode.Escape)
                        _settingsManager.Settings.KeyboardControlls.AttackKey = _keyCode;
                    break;
                case 5:
                    if (_keyCode != KeyCode.Escape)
                        _settingsManager.Settings.KeyboardControlls.FlipKey = _keyCode;
                    break;
                case 6:
                    if (_keyCode != KeyCode.Escape)
                        _settingsManager.Settings.KeyboardControlls.InteractKey = _keyCode;
                    break;
                case 7:
                    if (_keyCode != KeyCode.Escape)
                        _settingsManager.Settings.KeyboardControlls.SkillsKeys[0] = _keyCode;
                    break;
                case 8:
                    if (_keyCode != KeyCode.Escape)
                        _settingsManager.Settings.KeyboardControlls.SkillsKeys[1] = _keyCode;
                    break;
                case 9:
                    if (_keyCode != KeyCode.Escape)
                        _settingsManager.Settings.KeyboardControlls.SkillsKeys[2] = _keyCode;
                    break;
                case 10:
                    if (_keyCode != KeyCode.Escape)
                        _settingsManager.Settings.KeyboardControlls.SkillsKeys[3] = _keyCode;
                    break;
            }
            SetKeysInSettings();
        }
    }
}
