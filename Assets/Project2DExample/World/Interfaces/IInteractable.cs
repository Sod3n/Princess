using Assets.Project2DExample.World.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Interfaces
{
    public interface IInteractable 
    {
        public abstract void Interact(Entity _entity);
    }
}
