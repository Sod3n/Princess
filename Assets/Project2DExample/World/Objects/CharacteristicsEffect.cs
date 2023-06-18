
using Assets.Project2DExample.World.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Objects
{
    public class CharacteristicsEffect : Effect
    {
        [SerializeField] protected Characteristics _characteristicsScales;
        public Characteristics CharacteristicsScales
        {
            get { return _characteristicsScales; }
            set { _characteristicsScales = value; }
        }
        [SerializeField] protected Characteristics _flatCharacteristics;

        public Characteristics FlatCharacteristics
        {
            get { return _flatCharacteristics; }
            set { _flatCharacteristics = value; }
        }
        public CharacteristicsEffect(Entity entity) : base(entity)
        {

        }
        public override void Remove()
        {
            Entity.CharacteristicsEffects.Remove(this);
        }
    }
}
