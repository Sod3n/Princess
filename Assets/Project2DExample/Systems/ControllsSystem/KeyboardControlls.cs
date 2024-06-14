using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ControllsSystem
{
    public class KeyboardControlls : IControlls
    {
        public ControllsType Type { get; } = ControllsType.KeyboardControlls;
        public bool AnyKey
        {
            get
            {
                return Input.anyKeyDown;
            }
        }
        public Vector2 Cursor
        {
            get
            {
                Vector3 Worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                return Worldpos;
            }
        }
        public KeyCode MoveLeftKey { get; set; } = KeyCode.A;
        public KeyCode MoveRightKey { get; set; } = KeyCode.D;
        public float Horizontal
        {
            get
            {
                
                float f = 0;
                if (Input.GetKey(MoveLeftKey))
                    f -= 1;
                if (Input.GetKey(MoveRightKey))
                    f += 1;
                return f;
            }
        }
        public KeyCode MoveUpKey { get; set; } = KeyCode.W;
        public KeyCode MoveDownKey { get; set; } = KeyCode.S;
        public float Vertical
        {
            get
            {
                float f = 0;
                if (Input.GetKey(MoveUpKey))
                    f += 1;
                if (Input.GetKey(MoveDownKey))
                    f -= 1;
                return f;
            }
        }
        public KeyCode AttackKey { get; set; } = KeyCode.Mouse0;
        public bool Attack
        {
            get
            {
                return Input.GetKeyDown(AttackKey);
            }
        }
        public KeyCode InteractKey { get; set; } = KeyCode.E;
        public bool Interact
        {
            get
            {
                return Input.GetKeyDown(InteractKey);
            }
        }
        public KeyCode FlipKey { get; set; } = KeyCode.Mouse1;
        public bool Flip
        {
            get
            {
                return Input.GetKeyDown(FlipKey);
            }
        }
        public List<KeyCode> SkillsKeys { get; set; } = new List<KeyCode>{ KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
        public List<bool> Skills
        {
            get
            {
                List<bool> bools = new List<bool>();
                foreach (var skillKey in SkillsKeys)
                {
                    bools.Add(Input.GetKeyDown(skillKey));
                }
                return bools;
            }
        }
        public KeyCode OpenMenuKey { get; set; } = KeyCode.Escape;
        public bool OpenMainMenu
        {
            get
            {
                return Input.GetKeyDown(OpenMenuKey);
            }
        }
    }
}
