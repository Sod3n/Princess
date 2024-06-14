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
    public class DialogLine
    {
        [SerializeField] Character _character;
        public Character Character
        {
            get { return _character; }
            set { _character = value; }
        }
        [SerializeField] string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

    }
}
