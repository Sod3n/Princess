using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ControllsSystem
{
    internal class NoneControlls : IControlls
    {
        public ControllsType Type { get; } = ControllsType.None;
        public bool AnyKey { get { return Input.anyKeyDown; } }

        public Vector2 Cursor { get { return new Vector2(); } }

        public float Horizontal { get { return 0; } }

        public float Vertical { get { return 0; } }

        public bool Attack { get { return false; } }

        public bool Flip { get { return false; } }

        public bool Interact { get { return false; } }

        public List<bool> Skills { get { return new List<bool>(); } }

        public bool OpenMainMenu { get { return false; } }
    }
}
