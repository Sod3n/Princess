using Assets.Project2DExample.World.Objects;
using Assets.Project2DExample.World.Objects.UniqueEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Components
{
    public class Flipper : MonoBehaviour
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private float _flipTime;
        protected Vector2 _flipDirection;

        public event Action OnFlip = delegate { };

        protected void Update()
        {
            if (_entity.ControllsSelector.Controlls.Flip)
            {
                _flipDirection = _entity.Rigidbody2DMover.MoveDirection;
                if (_entity.Characteristics.CanFlip)
                {
                    _entity.Animator.SetTrigger("Flip");
                    _entity.AddUniqueEffectOnTime(new EffectStun(_entity), _flipTime);
                    _entity.AddUniqueEffectOnTime(new EffectImmortality(_entity), _flipTime);
                    _entity.Rigidbody2DMover.StopMove();
                    _entity.Rigidbody2D.AddForce(_flipDirection * _entity.Characteristics.FlipForce);
                    OnFlip.Invoke();
                }
            }
        }
    }
}
