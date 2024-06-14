using Assets.Project2DExample.World.Components;
using EntitySystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace InteractSystem.Interfaces
{
    public interface IInteractable 
    {
        public abstract void Interact(Entity _entity);
    }
}
