using Assets.Project2DExample.World.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Objects
{
    [Serializable]
    public class Characteristics : EntityComponent
    {
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
                float moveSpeed = _baseMoveSpeed;
                foreach (CharacteristicsEffect effect in Entity.CharacteristicsEffects)
                {
                    moveSpeed += effect.CharacteristicsScales.MoveSpeed * _baseMoveSpeed + effect.FlatCharacteristics.MoveSpeed;
                }
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
                foreach (CharacteristicsEffect effect in Entity.CharacteristicsEffects)
                {
                    hp += effect.CharacteristicsScales.HP * _baseMoveSpeed + effect.FlatCharacteristics.HP;
                }
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
                float maxHP = _baseMaxHP;
                foreach (CharacteristicsEffect effect in Entity.CharacteristicsEffects)
                {
                    maxHP += effect.CharacteristicsScales.MaxHP * _baseMoveSpeed + effect.FlatCharacteristics.MaxHP;
                }
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
                foreach (CharacteristicsEffect effect in Entity.CharacteristicsEffects)
                {
                    overHP += effect.CharacteristicsScales.OverHP * _baseMoveSpeed + effect.FlatCharacteristics.OverHP;
                }
                return overHP;
            }
        }
        [SerializeField] protected float _immortalTimeAfterGetDamage = 0;
        public float BaseImmortalTimeAfterGetDamage
        {
            get => _immortalTimeAfterGetDamage;
            set => _immortalTimeAfterGetDamage = value;
        }
        public float ImmortalTimeAfterGetDamage
        {
            get
            {
                float immortal = _immortalTimeAfterGetDamage;
                foreach (CharacteristicsEffect effect in Entity.CharacteristicsEffects)
                {
                    immortal += effect.CharacteristicsScales.ImmortalTimeAfterGetDamage * _baseMoveSpeed + effect.FlatCharacteristics.ImmortalTimeAfterGetDamage;
                }
                return immortal;
            }
        }


        [Header("Damage Settings")]
        [SerializeField] protected float _attack;
        public float Attack
        {
            get
            {
                return _attack;
            }
            set
            {
                _attack = value;
            }
        }
        [SerializeField] protected bool _canAttack = true;
        public bool CanAttack
        {
            get
            {
                return _canAttack;
            }
            set
            {
                _canAttack = value;
            }
        }


        [Header("Flip Settings")]
        [SerializeField] protected float _flipForce;
        public float FlipForce
        {
            get
            {
                return _flipForce;
            }
            set
            {
                _flipForce = value;
            }
        }
        [SerializeField] protected bool _canFlip = true;
        public bool CanFlip
        {
            get
            {
                return _canFlip;
            }
            set
            {
                _canFlip = value;
            }
        }
    }
}
