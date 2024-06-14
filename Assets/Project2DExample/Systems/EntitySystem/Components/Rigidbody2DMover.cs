using Aarthificial.Reanimation;
using EntitySystem.Abstract;
using EntitySystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace EntitySystem.Components
{
    public class Rigidbody2DMover : EntityComponent
    {
        private Vector2 _moveDirection = new Vector2();
        public Vector2 MoveDirection
        {
            get { return _moveDirection; }
            set { _moveDirection = value; }
        }

        public delegate void OnMoveEventHandler(ref Vector2 moveVector);
        public event OnMoveEventHandler OnMove = delegate { };

        Vector2 _moveVector = new Vector2();
        bool _isMoveOnLastFrame = false;
        public Reanimator reanimator;
        public void StopMove()
        {
            Entity.Rigidbody2D.velocity = Vector2.zero;
            _isMoveOnLastFrame = false;
            
        }
        protected virtual void FixedUpdate()
        {
            OnMove.Invoke(ref _moveVector);
            if (_moveVector.sqrMagnitude > 0)
            {
                _isMoveOnLastFrame = true;
                Entity.Rigidbody2D.velocity = _moveVector; //At the end _rigidbody.MovePosition() make me sad. It also just change velocity and continue do it if we stop invoke it, for "smooth" stop xD
            }
            else if (_isMoveOnLastFrame)
            {
                StopMove();
            }
        }
        protected virtual void Update()
        {
            _moveDirection = new Vector2(Entity.ControllsSelector.Controlls.Horizontal, Entity.ControllsSelector.Controlls.Vertical);
            _moveDirection.Normalize();
            _moveVector = _moveDirection * Entity.Characteristics.MoveSpeed;//if movespeed will be zero then will think that player stand
            _moveDirection = _moveVector.normalized * 100;
            Entity.Animator.SetInteger("MovementX", (int)_moveDirection.x);
            Entity.Animator.SetInteger("MovementY", (int)_moveDirection.y);
            Entity.Animator.SetInteger("MovementSpeed", (int)Entity.Characteristics.MoveSpeed);
            //reanimator.Set("root", 0);
            //reanimator.Set("movement", 0);
            //reanimator.Set("idle", 1);
        }
    }
}
