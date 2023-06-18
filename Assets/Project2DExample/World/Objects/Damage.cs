using Assets.Project2DExample.World.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Objects
{
    public enum DamageType
    {
        Common = 0
    }
    [Serializable]
    public class Damage
    {
        [SerializeField] private DamageType _type = DamageType.Common;
        public DamageType Type 
        { 
            get { return _type; }
            set { _type = value; }
        }
        [SerializeField] private float _value;
        public float Value
        {
            get { return _value; }
            set 
            { 
                _value = value;
                if(_value < 0)
                    _value = 0;
            }
        }

        [SerializeField] Entity _owner;
        public Entity Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        [SerializeField] Vector2 _pushVector;
        public Vector2 PushVector
        { 
            get { return _pushVector; }
            set { _pushVector = value; }
        }
        public Damage(DamageType type, float value, Vector2 pushVector)
        {
            _type = type;
            _value = value;
            _pushVector = pushVector;
        }
        public Damage Copy()
        {
            return new Damage(Type, Value, PushVector);    
        }
    }
}
