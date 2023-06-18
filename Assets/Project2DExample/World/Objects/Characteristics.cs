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
    public class Characteristics : MonoBehaviour
    {
        [SerializeField] private Entity _entity;
        public Entity Entity
        {
            get
            {
                return _entity;
            }
            set
            {
                _entity = value;
            }
        }

        [Header("Mover Settings")]
        [SerializeField] protected float _baseMoveSpeed;
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
            set
            {
                _baseMoveSpeed = value;
            }
        }


        [Header("Mortality Settings")]
        [SerializeField] protected float _baseHP;
        public float HP
        {
            get
            {
                return _baseHP + OverHP;
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
                    OverHP = OverHP - (HP - value);
                    if (OverHP < 0)
                    {
                        _baseHP += OverHP;
                        OverHP = 0;
                    }
                }
            }
        }
        [SerializeField] protected float _baseMaxHP;
        public float MaxHP
        {
            get
            {
                return _baseMaxHP;
            }
            set
            {
                _baseMaxHP = value;
            }
        }
        [SerializeField] protected float _baseOverHP;
        public float OverHP
        {
            get
            {
                return _baseOverHP;
            }
            set
            {
                _baseOverHP = value;
            }
        }
        [SerializeField] protected float _immortalTimeAfterGetDamage = 0;
        public float ImmortalTimeAfterGetDamage
        {
            get
            {
                return _immortalTimeAfterGetDamage;
            }
            set
            {
                _immortalTimeAfterGetDamage = value;
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
