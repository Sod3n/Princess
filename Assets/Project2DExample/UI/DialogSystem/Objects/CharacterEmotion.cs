using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.UI.DialogSystem.Objects
{
    [Serializable]
    public class CharacterEmotion
    {
        [SerializeField] CharacterEmotionType _type;
        public CharacterEmotionType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        [SerializeField] Sprite _sprite;
        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }
    }
}
