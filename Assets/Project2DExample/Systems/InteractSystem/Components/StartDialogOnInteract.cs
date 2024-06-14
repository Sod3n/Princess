using DialogSystem.Components;
using EntitySystem.Core;
using InteractSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace InteractSystem.Components
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
