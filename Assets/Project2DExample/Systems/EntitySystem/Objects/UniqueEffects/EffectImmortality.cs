using EntitySystem.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityEngine;

namespace EntitySystem.Objects.UniqueEffects
{
    public class EffectImmortality : Effect
    {
        public EffectImmortality(EffectsSystem effectsSystem) : base(effectsSystem)
        {
            EffectsSystem = effectsSystem; // invoke new setter of Entity
            _tag = "Immortality";
        }

        public new EffectsSystem EffectsSystem
        {
            get { return _effectsSystem; }
            set
            {
                Remove();
                _effectsSystem = value;
                if (_effectsSystem != null)
                    _effectsSystem.Entity.OnDamageReceive += SetDamageValueToZero;
            }
        }
        private void SetDamageValueToZero(ref Damage damage)
        {
            damage.Value = 0;
        }

        public override void Remove()
        {
            base.Remove();
            if (_effectsSystem != null)
            {
                _effectsSystem.Entity.OnDamageReceive -= SetDamageValueToZero;
            }
        }
    }
}
