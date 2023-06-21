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
    public class Flipper : EntityComponent
    {
        public override Type[] Dependencies { get; set; } =
        {
            typeof(Rigidbody2DMover),
        };

        [SerializeField] private float _flipTime;
        protected Vector2 _flipDirection;

        public event Action OnFlip = delegate { };

        protected void Update()
        {
            if (Entity.ControllsSelector.Controlls.Flip)
            {
                _flipDirection = Entity.GetEntityComponent<Rigidbody2DMover>().MoveDirection;
                if (Entity.Characteristics.CanFlip)
                {
                    Entity.Animator.SetTrigger("Flip");
                    Entity.AddUniqueEffectOnTime(new EffectStun(Entity), _flipTime);
                    Entity.AddUniqueEffectOnTime(new EffectImmortality(Entity), _flipTime);
                    Entity.GetEntityComponent<Rigidbody2DMover>().StopMove();
                    Entity.Rigidbody2D.AddForce(_flipDirection * Entity.Characteristics.FlipForce);
                    OnFlip.Invoke();
                }
            }
        }
    }
}
