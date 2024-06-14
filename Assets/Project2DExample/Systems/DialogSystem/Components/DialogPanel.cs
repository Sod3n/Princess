using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem.Components
{
    public class DialogPanel : MonoBehaviour
    {
        [SerializeField] private List<Image> _charactersImage = new List<Image>();
        public List<Image> CharactersImage
        {
            get { return _charactersImage; }
            set { _charactersImage = value; }
        }
        [SerializeField] private TextMeshProUGUI _dialogLine;
        public TextMeshProUGUI DialogLine
        {
            get { return _dialogLine; }
            set { _dialogLine = value; }
        }
        [SerializeField] private TextMeshProUGUI _characterName;
        public TextMeshProUGUI CharacterName
        {
            get { return _characterName; }
            set { _characterName = value; }
        }
        [SerializeField] private Image _backgroundImage;
        public Image BackgroundImage
        {
            get { return _backgroundImage; }
            set { _backgroundImage = value; }
        }
    }
}
