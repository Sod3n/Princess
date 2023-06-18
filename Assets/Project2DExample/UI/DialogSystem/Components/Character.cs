using Assets.Project2DExample.UI.DialogSystem.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Project2DExample.UI.DialogSystem.Components
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [SerializeField] private List<CharacterEmotion> _characterEmotions;
        public List<CharacterEmotion> CharacterEmotions
        {
            get { return _characterEmotions; }
            set { _characterEmotions = value; }
        }
        [SerializeField] private Color _textColor;
        public Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; }
        }
    }
}
