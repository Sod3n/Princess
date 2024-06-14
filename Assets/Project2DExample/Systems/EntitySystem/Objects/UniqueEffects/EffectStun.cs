using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Threading.Tasks;
using EntitySystem.Components;
using ControllsSystem;

namespace EntitySystem.Objects.UniqueEffects
{
    public class EffectStun : Effect
    {
        public EffectStun(EffectsSystem effectsSystem) : base(effectsSystem)
        {
            EffectsSystem = effectsSystem; // invoke new setter of Entity
            _tag = "EffectStun";
        }
        private ControllsType _controllsType;
        public new EffectsSystem EffectsSystem
        {
            get { return _effectsSystem; }
            set 
            {
                _effectsSystem = value;
                _controllsType = _effectsSystem.Entity.ControllsSelector.Controlls.Type;
                _effectsSystem.Entity.ControllsSelector.Type = ControllsType.None;
            }
        }

        public override void Remove()
        {
            base.Remove();
            if(_effectsSystem != null)
            {
                _effectsSystem.Entity.ControllsSelector.Type = _controllsType;
            }
        }
    }
}
