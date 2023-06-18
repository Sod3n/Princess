using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.Hardware
{
    public interface IControlls
    {
        public ControllsType Type { get; }
        public bool AnyKey { get; }
        public Vector2 Cursor { get; }
        public float Horizontal { get; }
        public float Vertical { get; }
        public bool Attack { get; }
        public bool Flip { get; }
        public bool Interact { get; }
        public List<bool> Skills { get; }
        public bool OpenMainMenu { get; }
    }
}
