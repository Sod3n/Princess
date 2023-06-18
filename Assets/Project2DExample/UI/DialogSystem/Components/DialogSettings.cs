using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.UI.DialogSystem.Components
{
    public class DialogSettings : MonoBehaviour
    {
        [SerializeField] float _cooldownOnNextLine = 0.5f;
        public float CooldownOnNextLine
        {
            get { return _cooldownOnNextLine; }
            set { _cooldownOnNextLine = value; }
        }
    }
}
