using EntitySystem.Abstract;
using EntitySystem.Components;
using EntitySystem.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EntitySystem.Core
{
    [Serializable]
    public class Characteristics : EntityComponent
    {
        private T GetPropertyValue<T>(object src, string propName)
        {
            PropertyInfo propertyInfo = src.GetType().GetProperty(propName);
            if (propertyInfo == null) Debug.LogError(propName + " not exist!"); 
            return (T)propertyInfo.GetValue(src, null);
        }
        private float BaseFormula(string characteristicName, float baseValue)
        {
            EffectsSystem effectsSystem = Entity.GetEntityComponent<EffectsSystem>();
            if(!effectsSystem) return baseValue;
            foreach (CharacteristicsEffect effect in effectsSystem.CharacteristicsEffects)
            {
                float scale = 1;
                float flat = 0;
                if (effect.CharacteristicsScales)
                    scale = GetPropertyValue<float>(effect.CharacteristicsScales, characteristicName);
                if (effect.FlatCharacteristics)
                    flat = GetPropertyValue<float>(effect.FlatCharacteristics, characteristicName);
                baseValue += scale * baseValue + flat;
            }
            return baseValue;
        }
        private bool BaseFormula(string characteristicName, bool baseValue)
        {
            EffectsSystem effectsSystem = Entity.GetEntityComponent<EffectsSystem>();
            if (!effectsSystem) return baseValue;
            int counter = 0;
            foreach (CharacteristicsEffect effect in effectsSystem.CharacteristicsEffects)
            {
                if (!effect.FlatCharacteristics) continue;
                if (!GetPropertyValue<bool>(effect.FlatCharacteristics, characteristicName)) counter--;
                else counter++;
            }
            if (counter > 0) return true;
            if(counter == 0) return baseValue;
            if (counter < 0) return false;
            return true;
        }

        [Header("Mover Settings")]
        [SerializeField] protected float _baseMoveSpeed;
        public float BaseMoveSpeed
        {
            get => _baseMoveSpeed;
            set => _baseMoveSpeed = value;
        }
        public float MoveSpeed
        {
            get
            {
                float moveSpeed = BaseFormula(nameof(BaseMoveSpeed), _baseMoveSpeed);
                if (moveSpeed >= 0)
                    return moveSpeed;
                return 0;
            }
        }


        [Header("Mortality Settings")]
        [SerializeField] protected float _baseHP;
        public float BaseHP
        {
            get => _baseHP;
            set => _baseHP = value;
        }

        public float HP
        {
            get
            {
                float hp = _baseHP;
                if (hp >= MaxHP)
                    return MaxHP;
                return hp;
            }
        }
        public float TotalHP
        {
            get
            {
                return HP + OverHP;
            }
            set
            {
                if (HP < value)
                {
                    _baseHP = value - OverHP;
                    if (_baseHP > MaxHP)
                    {
                        _baseHP = MaxHP;
                    }
                }
                else if (HP > value)
                {
                    BaseOverHP = OverHP - (HP - value);
                    if (OverHP < 0)
                    {
                        _baseHP += OverHP;
                        BaseOverHP = 0;
                    }
                }
            }
        }
        [SerializeField] protected float _baseMaxHP;
        public float BaseMaxHP
        {
            get => _baseMaxHP;
            set => _baseMaxHP = value;
        }
        public float MaxHP
        {
            get
            {
                float maxHP = BaseFormula(nameof(BaseMaxHP), _baseMaxHP);
                return maxHP;
            }
        }
        [SerializeField] protected float _baseOverHP;
        public float BaseOverHP
        {
            get => _baseOverHP;
            set => _baseOverHP = value;
        }
        public float OverHP
        {
            get
            {
                float overHP = _baseOverHP;
                return overHP;
            }
        }
        [SerializeField] protected float _baseImmortalTimeAfterGetDamage = 0;
        public float BaseImmortalTimeAfterGetDamage
        {
            get => _baseImmortalTimeAfterGetDamage;
            set => _baseImmortalTimeAfterGetDamage = value;
        }
        public float ImmortalTimeAfterGetDamage
        {
            get
            {
                float immortal = BaseFormula(nameof(BaseImmortalTimeAfterGetDamage), _baseImmortalTimeAfterGetDamage);
                return immortal;
            }
        }


        [Header("Damage Settings")]
        [SerializeField] protected float _baseAttack;
        public float BaseAttack
        {
            get => _baseAttack;
            set => _baseAttack = value;
        }
        public float Attack
        {
            get
            {
                float attack = BaseFormula(nameof(BaseAttack), _baseAttack);
                return attack;
            }
        }
        [SerializeField] protected bool _baseCanAttack = true;
        public bool BaseCanAttack
        {
            get => _baseCanAttack;
            set => _baseCanAttack = value;
        }
        public bool CanAttack
        {
            get
            {
                bool canAttack = BaseFormula(nameof(BaseCanAttack), _baseCanAttack);
                return canAttack;
            }
            set
            {
                _baseCanAttack = value;
            }
        }


        [Header("Flip Settings")]
        [SerializeField] protected float _baseFlipForce;
        public float BaseFlipForce
        {
            get => _baseFlipForce;
            set => _baseFlipForce = value;
        }
        public float FlipForce
        {
            get
            {
                float flipForce = BaseFormula(nameof(BaseFlipForce), _baseFlipForce);
                return flipForce;
            }
            set
            {
                _baseFlipForce = value;
            }
        }
        [SerializeField] protected bool _baseCanFlip = true;
        public bool BaseCanFlip
        {
            get => _baseCanFlip;
            set => _baseCanFlip = value;
        }
        public bool CanFlip
        {
            get
            {
                bool canFlip = BaseFormula(nameof(BaseCanFlip), _baseCanFlip);
                return canFlip;
            }
            set
            {
                _baseCanFlip = value;
            }
        }
    }
}
