using Assets.Project2DExample.UI;
using ControllsSystem;
using EntitySystem.Abstract;
using EntitySystem.Components;
using EntitySystem.Objects;
using EntitySystem.Objects.UniqueEffects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace EntitySystem.Core
{
    
    public class Entity : MonoBehaviour
    {
        #region Components
        [Header("Must Be Setted")]
        [SerializeField] private EntityType _type;
        public EntityType Type { get { return _type; } }

        [SerializeField] private ControllsSelector _controllsSelector;
        public ControllsSelector ControllsSelector
        {
            get { return _controllsSelector; }
            set { _controllsSelector = value; }
        }

        [SerializeField] private Characteristics _characteristics;
        public Characteristics Characteristics
        {
            get { return _characteristics; }
            set { _characteristics = value; }
        }
        
        [SerializeField] private Animator _animator;
        public Animator Animator
        {
            get { return _animator; }
        }
        [SerializeField] private Rigidbody2D _rigidbody2D;
        public Rigidbody2D Rigidbody2D
        {
            get { return _rigidbody2D; }
        }

        [Header("Debug")]

        [SerializeField] private List<EntityComponent> _entityComponents;

        public List<EntityComponent> EntityComponents
        {
            get { return _entityComponents; }
            set { _entityComponents = value; }
        }

        public T GetEntityComponent<T>() where T : EntityComponent
        {
            foreach (var component in _entityComponents)
            {
                if (component is T) return (T)component;
            }
            return null;
        }
        #endregion


        #region Mortality Component
        //yep, all entity mortal

        public delegate void OnDamageReceiveEventHandler(ref Damage damage);
        public event OnDamageReceiveEventHandler OnDamageReceive = delegate { };
        public event Action OnDamageReceived = delegate { };
        public event Action OnFatalDamageReceive = delegate { };
        public event Action OnDie = delegate { };

        
        public virtual void ReceiveDamage(Damage damage)
        {
            OnDamageReceive.Invoke(ref damage);
            if(0 != damage.Value)
            {
                Characteristics.TotalHP -= damage.Value;
                if (Characteristics.TotalHP < 0)
                {
                    OnFatalDamageReceive.Invoke();
                    if (Characteristics.TotalHP < 0)
                    {
                        Die();
                    }
                }
                _animator.SetTrigger("DamageReceived");
                Rigidbody2D.AddForce(damage.PushVector);
                EffectsSystem effectsSystem = GetEntityComponent<EffectsSystem>();
                if (effectsSystem)
                    effectsSystem.AddUniqueEffectOnTime(new EffectImmortality(effectsSystem), Characteristics.ImmortalTimeAfterGetDamage);
            }
            OnDamageReceived.Invoke();
        }

        protected virtual void Die()
        {
            _animator.SetBool("Died", true);
            OnDie.Invoke();
        }

        protected virtual void Start()
        {
            _characteristics.Entity = this;
        }
        #endregion
    }
}
