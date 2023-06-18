using Assets.Project2DExample.UI;
using Assets.Project2DExample.World.Objects;
using Assets.Project2DExample.World.Objects.UniqueEffects;
using Assets.Project2DExample.World.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Project2DExample.World.Components
{
    
    public class Entity : MonoBehaviour
    {
        #region Components
        [SerializeField] private EntityType _type;
        public EntityType Type { get { return _type; } }

        [SerializeField] private ControllsSelector _controllsSelector;
        public ControllsSelector ControllsSelector
        {
            get { return _controllsSelector; }
            set { _controllsSelector = value; }
        }

        private List<IEntityComponent> _entityComponents;

        public List<IEntityComponent> EntityComponents 
        {
            get {  return _entityComponents; }
            set { _entityComponents = value; }
        }
        

        [SerializeField] private Characteristics _characteristics;
        public Characteristics Characteristics
        {
            get { return _characteristics; }
            set { _characteristics = value; }
        }
        [SerializeField] private List<CharacteristicsEffect> _characteristicsEffects = new List<CharacteristicsEffect>();
        public List<CharacteristicsEffect> CharacteristicsEffects
        {
            get
            {
                return _characteristicsEffects;
            }
            set
            {
                _characteristicsEffects = value;
            }
        }
        [SerializeField] private List<Effect> _uniqueEffects = new List<Effect>();
        public List<Effect> UniqueEffects
        {
            get
            {
                return _uniqueEffects;
            }
            set
            {
                _uniqueEffects = value;
            }
        }
        [SerializeField] private Rigidbody2DMover _rigidbody2DMover;
        public Rigidbody2DMover Rigidbody2DMover
        {
            get { return _rigidbody2DMover; }
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
        [SerializeField] private AttackMaker _attackMaker;
        public AttackMaker AttackMaker
        {
            get { return _attackMaker; }
        }
        [SerializeField] private Flipper _flipper;
        public Flipper Flipper
        {
            get { return _flipper; }
        }
        [SerializeField] EntityInformation _entityInformation;
        public EntityInformation EntityInformation
        {
            get { return _entityInformation; }
            set { _entityInformation = value; }
        }
        #endregion


        #region Mortality Component
        //yep, all entity mortal

        public delegate void OnDamageReceiveEventHandler(ref Damage damage);
        public event OnDamageReceiveEventHandler OnDamageReceive = delegate { };
        public event Action OnFatalDamageReceive = delegate { };
        public event Action OnDie = delegate { };

        float CurrentHPStartLocalScaleX = 0;
        public virtual void ReceiveDamage(Damage damage)
        {
            OnDamageReceive.Invoke(ref damage);
            if(0 != damage.Value)
            {
                Characteristics.HP -= damage.Value;
                if (Characteristics.HP < 0)
                {
                    OnFatalDamageReceive.Invoke();
                    if (Characteristics.HP < 0)
                    {
                        Die();
                    }
                }
                _animator.SetTrigger("DamageReceived");
                Rigidbody2D.AddForce(damage.PushVector);
                AddUniqueEffectOnTime(new EffectImmortality(this), Characteristics.ImmortalTimeAfterGetDamage);
            }
            _entityInformation.CurrentHP.localScale = new Vector2(Characteristics.HP / Characteristics.MaxHP * CurrentHPStartLocalScaleX, _entityInformation.CurrentHP.localScale.y);
        }
        protected virtual void Die()
        {
            _animator.SetBool("Died", true);
            OnDie.Invoke();
        }

        protected virtual void Start()
        {
            _characteristics.Entity = this;
            CurrentHPStartLocalScaleX = _entityInformation.CurrentHP.localScale.x;
        }
        #endregion


        #region Effects interactions

        public void AddUniqueEffect(Effect effect)
        {
            if (!UniqueEffects.Contains(effect))
            {
                UniqueEffects.Add(effect);
            }
                
        }
        public void AddUniqueEffectOnTime(Effect effect, float timeInSec)
        {
            AddUniqueEffect(effect);
            
            StartCoroutine(CoroutinRemoveEffectOnTime(effect, timeInSec));
        }
        public IEnumerator CoroutinRemoveEffectOnTime(Effect effect, float timeInSec)
        {
            yield return new WaitForSeconds(timeInSec);
            //Effect e = Effects.Find(x => x.Tag == effect.Tag);
            effect.Remove();
        }
        #endregion
    }
}
