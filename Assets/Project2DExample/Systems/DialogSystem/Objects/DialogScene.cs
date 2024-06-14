using DialogSystem.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DialogSystem.Objects
{
    [Serializable]
    public class DialogScene
    {
        [SerializeField] List<Character> _currentCharacters = new List<Character>();
        public List<Character> CurrentCharacters
        {
            get { return _currentCharacters; }
            set { _currentCharacters = value; }
        }
        [SerializeField] Sprite _background;
        public Sprite Background
        {
            get { return _background; }
            set { _background = value; }
        }
        [SerializeField] List<DialogLine> _dialogLines = new List<DialogLine>();
        public List<DialogLine> DialogLines
        {
            get { return _dialogLines; }
            set
            {
                _dialogLines = value;
            }
        }

        int _currentDialogLine = -1;
        public int CurrentDialogLine
        {
            get { return _currentDialogLine; }
            set { _currentDialogLine = value; }
        }
        DialogPanel _dialogPanel;

        public event Action<int> OnDialogLineChange = delegate { };

        public void Set(DialogPanel dialogPanel)
        {
            if(_currentCharacters.Count > dialogPanel.CharactersImage.Count)
            {
                Debug.LogError("Not enougth characters on dialog panel");
                return;
            }
            for(int i = 0; i < _currentCharacters.Count; i++)
            {
                dialogPanel.CharactersImage[i].sprite = _currentCharacters[i].CharacterEmotions[0].Sprite;
                dialogPanel.CharactersImage[i].gameObject.SetActive(true);
            }
            for (int i = _currentCharacters.Count; i < dialogPanel.CharactersImage.Count; i++)
            {
                dialogPanel.CharactersImage[i].gameObject.SetActive(false);
            }
            dialogPanel.BackgroundImage.sprite = Background;
            _dialogPanel = dialogPanel;
            NextDialogLine();
        }
        
        public bool NextDialogLine()
        {
            _currentDialogLine++;
            if (_currentDialogLine > DialogLines.Count-1) return false;

            OnDialogLineChange.Invoke(_currentDialogLine);
            _dialogPanel.CharacterName.text = DialogLines[_currentDialogLine].Character.Name;
            _dialogPanel.DialogLine.text = DialogLines[_currentDialogLine].Text;
            _dialogPanel.CharacterName.color = DialogLines[_currentDialogLine].Character.TextColor;

            return true;
        }
    }
}
