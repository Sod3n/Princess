using EntitySystem.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitySystem.Abstract
{
    public abstract class EntityComponent : MonoBehaviour
    {
        [SerializeField] private Entity _entity;
        public Entity Entity
        {
            get => _entity;
            set => _entity = value;
        }
        public virtual Type[] Dependencies { get; set; }
    }

}
