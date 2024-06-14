using ControllsSystem;
using DialogSystem.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSystem;
using UnityEngine;

namespace DialogSystem.Components
{
    public class Dialog : MonoBehaviour
    {
        ControllsSelector _controllsSelector;
        [SerializeField] DialogPanel _dialogPanel;
        [SerializeField] List<DialogScene> _dialogScenes = new List<DialogScene>();
        [SerializeField] DialogSettings _dialogSettings;
        int _currentDialogScene = 0;
        bool initiated = false;

        public event Action<int,int> OnDialogSceneAndLine = delegate { };
        public event Action OnDialogEnd = delegate { };

        public void Initiate(ControllsSelector controllsSelector)
        {
            TimeManager.StopWorld();
            _controllsSelector = controllsSelector;
            _dialogScenes[0].Set(_dialogPanel);
            _dialogPanel.gameObject.SetActive(true);
            initiated = true;
            StartCoroutine(ResetLineCooldown());
        }

        bool nextLineNotCooldown = false;
        private void LateUpdate()
        {
            if (_controllsSelector != null && _controllsSelector.Controlls.AnyKey && initiated && nextLineNotCooldown)
            {
                nextLineNotCooldown = false;
                StartCoroutine(ResetLineCooldown());
                if (!_dialogScenes[_currentDialogScene].NextDialogLine())
                {
                    _currentDialogScene++;
                    if(_currentDialogScene < _dialogScenes.Count)
                    {
                        _dialogScenes[_currentDialogScene].Set(_dialogPanel);
                    }
                    else
                    {
                        _dialogPanel.gameObject.SetActive(false);
                        initiated = false;
                        _currentDialogScene = 0;
                        OnDialogEnd.Invoke();
                        TimeManager.StartWorld();
                    }
                }
                else
                {
                    OnDialogSceneAndLine.Invoke(_currentDialogScene, _dialogScenes[_currentDialogScene].CurrentDialogLine);
                }
            }
        }
        IEnumerator ResetLineCooldown()
        {
            yield return new WaitForSecondsRealtime(_dialogSettings.CooldownOnNextLine);
            nextLineNotCooldown = true;
        }
    }
}
