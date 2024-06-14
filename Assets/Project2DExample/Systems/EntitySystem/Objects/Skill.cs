using Assets.Project2DExample.World.Components;
using EntitySystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EntitySystem.Objects
{
    public abstract class Skill : MonoBehaviour
    {
        [SerializeField] protected string _name;
        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }
        [SerializeField] protected Sprite _icon;
        public Sprite Icon 
        {
            get { return _icon; }
            set { _icon = value; }
        }
        [SerializeField] protected float _cooldown = 0;
        public float Cooldown 
        {
            get { return _cooldown; }
            set { _cooldown = value; }
        }
        [SerializeField] protected Entity _entity;

        public event Action OnSkillActivate = delegate { };

        protected float _remainCooldown = 0;
        public float RemainCooldown
        {
            get { return _remainCooldown; }
            set { _remainCooldown = value; }
        }
        protected abstract void Activate();
        public virtual bool TryActivate()
        {
            if(_remainCooldown <= 0)
            {
                Activate();
                _remainCooldown = Cooldown;
                OnSkillActivate.Invoke();
                return true;
            }
            else
            {
                return false;
            }
        }
        protected virtual void FixedUpdate()
        {
            if(_remainCooldown > 0)
            {
                _remainCooldown -= Time.deltaTime;
            }
        }
    }
}
