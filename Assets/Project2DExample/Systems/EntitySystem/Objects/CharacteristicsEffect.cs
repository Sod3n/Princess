using EntitySystem.Components;
using EntitySystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EntitySystem.Objects
{
    [Serializable]
    public class CharacteristicsEffect : Effect
    {
        public string GUID { get; set; }
        [SerializeField] protected Characteristics _characteristicsScales = new Characteristics();
        public Characteristics CharacteristicsScales
        {
            get { return _characteristicsScales; }
            set { _characteristicsScales = value; }
        }
        [SerializeField] protected Characteristics _flatCharacteristics = new Characteristics();

        public Characteristics FlatCharacteristics
        {
            get { return _flatCharacteristics; }
            set { _flatCharacteristics = value; }
        }
        public CharacteristicsEffect(EffectsSystem effectsSystem) : base(effectsSystem)
        {
            GUID = Guid.NewGuid().ToString();
        }
        public override void Remove()
        {
            EffectsSystem.CharacteristicsEffects.Remove(this);
        }
    }
}
