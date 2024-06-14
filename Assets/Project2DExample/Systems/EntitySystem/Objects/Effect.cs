using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Project2DExample.World;
using Assets.Project2DExample.World.Components;
using EntitySystem.Components;

namespace EntitySystem.Objects
{

    [Serializable]
    public class Effect
    {
        [SerializeField] protected string _tag = "none";
        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }
        [SerializeField] protected bool _visible = false;
        protected EffectsSystem _effectsSystem;
        public EffectsSystem EffectsSystem
        {
            get { return _effectsSystem; }
            set { _effectsSystem = value; }
        }
        public Effect(EffectsSystem effectsSystem)
        {
            _effectsSystem = effectsSystem;
        }

        public virtual void Remove()
        {
            EffectsSystem.UniqueEffects.Remove(this);
        }
    }
}
