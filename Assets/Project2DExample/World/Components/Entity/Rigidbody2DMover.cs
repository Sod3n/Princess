using Assets.Project2DExample.World.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Components
{
    public class Rigidbody2DMover : MonoBehaviour
    {
        [SerializeField] private Entity _entity;

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
        public void StopMove()
        {
            _entity.Rigidbody2D.velocity = Vector2.zero;
            _isMoveOnLastFrame = false;
        }
        protected virtual void FixedUpdate()
        {
            OnMove.Invoke(ref _moveVector);
            if (_moveVector.sqrMagnitude > 0)
            {
                _isMoveOnLastFrame = true;
                _entity.Rigidbody2D.velocity = _moveVector; //At the end _rigidbody.MovePosition() make me sad. It also just change velocity and continue do it if we stop invoke it, for "smooth" stop xD
            }
            else if (_isMoveOnLastFrame)
            {
                StopMove();
            }
        }
        protected virtual void Update()
        {
            _moveDirection = new Vector2(_entity.ControllsSelector.Controlls.Horizontal, _entity.ControllsSelector.Controlls.Vertical);
            _moveDirection.Normalize();

            _moveVector = _moveDirection * _entity.Characteristics.MoveSpeed;//if movespeed will be zero then will think that player stand
            if (_entity.Animator != null)
                _entity.Animator.SetInteger("MovementDirection", (int)GetAnimationDirectionAndRot(_moveVector));
        }

        private enum _animatorMoveDirection : int
        {
            Idle = 0,
            Up,
            UpRight,
            Right,
            DownRight,
            Down
        }
        /// <summary>
        /// function for get direction of move to set in animator, also flip sprite for leftone directions
        /// </summary>
        private _animatorMoveDirection GetAnimationDirectionAndRot(Vector2 moveDirection)
        {
            _animatorMoveDirection direction = _animatorMoveDirection.Idle;
            if (moveDirection.sqrMagnitude == 0) return direction;
            _entity.Rigidbody2D.transform.eulerAngles = new Vector3(0, 0);
            if (Vector2.Angle(Vector2.up, moveDirection) <= 10f)
            {
                direction = _animatorMoveDirection.Up;
            }
            else if (Vector2.Angle(new Vector2(1, 1), moveDirection) <= 35f)
            {
                direction = _animatorMoveDirection.UpRight;
            }
            else if (Vector2.Angle(Vector2.right, moveDirection) <= 10f)
            {
                direction = _animatorMoveDirection.Right;
            }
            else if (Vector2.Angle(new Vector2(1, -1), moveDirection) <= 35f)
            {
                direction = _animatorMoveDirection.DownRight;
            }
            else if (Vector2.Angle(Vector2.down, moveDirection) <= 10f)
            {
                direction = _animatorMoveDirection.Down;
            }
            else
            {
                _entity.Rigidbody2D.transform.eulerAngles = new Vector3(0, 180); // if not these one, flip and check remain angles
            }
            if (Vector2.Angle(new Vector2(-1, -1), moveDirection) <= 35f)
            {
                direction = _animatorMoveDirection.DownRight;
            }
            else if (Vector2.Angle(Vector2.left, moveDirection) <= 10f)
            {
                direction = _animatorMoveDirection.Right;
            }
            else if (Vector2.Angle(new Vector2(-1, 1), moveDirection) <= 35f)
            {
                direction = _animatorMoveDirection.UpRight;
            }
            return direction;
        }
    }
}
