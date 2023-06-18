using Assets.Project2DExample.UI.DialogSystem.Components;
using Assets.Project2DExample.World.Interfaces;
using Assets.Project2DExample.World.Objects;
using Assets.Project2DExample.World.Objects.UniqueEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Components.Interactables
{
    public class StartDialogOnInteract : MonoBehaviour, IInteractable
    {
        [SerializeField] Dialog _dialog;
        public void Interact(Entity entity)
        {
            _dialog.Initiate(entity.ControllsSelector);
        }
    }
}
