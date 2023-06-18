using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Objects
{
    [Serializable]
    public class Attack
    {
        [SerializeField] private int _id = 0;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        [SerializeField] private int _previousAttackId;
        public int PreviousAttackId
        {
            get
            {
                return _previousAttackId;
            }
            set
            {
                _previousAttackId = value;
            }
        }
        [SerializeField] private float _damageTime = 0;
        public float DamageTime
        {
            get
            {
                return _damageTime;
            }
            set
            {
                _damageTime = value;
            }
        }
        [SerializeField] private float _weeknessTime = 0;
        public float WeeknessTime
        {
            get
            {
                return _weeknessTime;
            }
            set
            {
                _weeknessTime = value;
            }
        }
        [SerializeField] private float _timeToMake = 0;
        public float TimeToMake
        {
            get
            {
                return _timeToMake;
            }
            set
            {
                _timeToMake = value;
            }
        }
        [SerializeField] private float _multiplier = 0;
        public float Multiplier
        {
            get
            {
                return _multiplier;
            }
            set
            {
                _multiplier = value;
            }
        }
        [SerializeField] private float _damagePushForce = 0;
        public float DamagePushForce
        {
            get
            {
                return _damagePushForce;
            }
            set
            {
                _damagePushForce = value;
            }
        }
        [SerializeField] private float _attakerPushForce = 0;
        public float AttakerPushForce
        {
            get
            {
                return _attakerPushForce;
            }
            set
            {
                _attakerPushForce = value;
            }
        }
        [SerializeField] private DamageType _damageType = 0;
        public DamageType DamageType
        {
            get
            {
                return _damageType;
            }
            set
            {
                _damageType = value;
            }
        }

        public Attack(int id, int previousAttackId, float damageTime, float weeknessTime, float timeToMake, float multiplier, float damagePushForce, float attakerPushForce, DamageType damageType)
        {
            Id = id;
            PreviousAttackId = previousAttackId;
            WeeknessTime = weeknessTime;
            TimeToMake = timeToMake;
            Multiplier = multiplier;
            DamagePushForce = damagePushForce;
            DamageType = damageType;
            DamageTime = damageTime;
            AttakerPushForce = attakerPushForce;
        }

        public static Attack NullAttack = new Attack(0, 0, 0, 0, 0, 0, 0, 0, DamageType.Common);
    }
}
