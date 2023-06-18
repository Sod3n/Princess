using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Project2DExample.World;
using Assets.Project2DExample.World.Components;

namespace Assets.Project2DExample.World.Objects
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
        protected Entity _entity;
        public Entity Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }
        public Effect(Entity entity)
        {
            _entity = entity;
        }

        public virtual void Remove()
        {
            Entity.UniqueEffects.Remove(this);
        }
    }
}
