using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Threading.Tasks;
using Assets.Project2DExample.World.Objects;
using Assets.Project2DExample.World.Components;
using Assets.Project2DExample.Hardware;

namespace Assets.Project2DExample.World.Objects.UniqueEffects
{
    public class EffectStun : Effect
    {
        public EffectStun(Entity entity) : base(entity)
        {
            Entity = entity; // invoke new setter of Entity
            _tag = "EffectStun";
        }
        private ControllsType _controllsType;
        public new Entity Entity
        {
            get { return _entity; }
            set 
            {
                _entity = value;
                _controllsType = _entity.ControllsSelector.Controlls.Type;
                _entity.ControllsSelector.Type = ControllsType.None;
            }
        }

        public override void Remove()
        {
            base.Remove();
            if(_entity != null)
            {
                _entity.ControllsSelector.Type = _controllsType;
            }
        }
    }
}
