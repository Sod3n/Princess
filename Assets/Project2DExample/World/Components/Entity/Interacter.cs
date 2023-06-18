﻿using Assets.Project2DExample.World.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Components
{
    public class Interacter : MonoBehaviour
    {
        [SerializeField] private Entity _entity;
        private IInteractable _lastInteractableObjectInZone;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.GetComponent<IInteractable>() != null)
            {
                _lastInteractableObjectInZone = collision.GetComponent<IInteractable>();
            }

        }
        private void Update()
        {
            if (_entity.ControllsSelector.Controlls.Interact)
            {
                if(_lastInteractableObjectInZone != null)
                    _lastInteractableObjectInZone.Interact(_entity);
            }
        }
    }
}
