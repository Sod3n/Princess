using EntitySystem.Abstract;
using EntitySystem.Objects.UniqueEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EntitySystem.Components
{
    public class Flipper : EntityComponent
    {
        public override Type[] Dependencies { get; set; } =
        {
            typeof(Rigidbody2DMover),
            typeof(EffectsSystem),
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
                    EffectsSystem effectsSystem = Entity.GetComponent<EffectsSystem>();
                    effectsSystem.AddUniqueEffectOnTime(new EffectStun(effectsSystem), _flipTime);
                    effectsSystem.AddUniqueEffectOnTime(new EffectImmortality(effectsSystem), _flipTime);
                    Entity.GetEntityComponent<Rigidbody2DMover>().StopMove();
                    Entity.Rigidbody2D.AddForce(_flipDirection * Entity.Characteristics.FlipForce);
                    OnFlip.Invoke();
                }
            }
        }
    }
}
