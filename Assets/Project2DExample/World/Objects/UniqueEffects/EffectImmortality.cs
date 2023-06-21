using Assets.Project2DExample.World.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityEngine;

namespace Assets.Project2DExample.World.Objects.UniqueEffects
{
    public class EffectImmortality : Effect
    {
        public EffectImmortality(Entity entity) : base(entity)
        {
            Entity = entity; // invoke new setter of Entity
            _tag = "Immortality";
        }

        public new Entity Entity
        {
            get { return _entity; }
            set
            {
                Remove();
                _entity = value;
                if (_entity != null)
                    _entity.OnDamageReceive += SetDamageValueToZero;
            }
        }
        private void SetDamageValueToZero(ref Damage damage)
        {
            damage.Value = 0;
        }

        public override void Remove()
        {
            base.Remove();
            if (_entity != null)
            {
                _entity.OnDamageReceive -= SetDamageValueToZero;
            }
        }
    }
}
