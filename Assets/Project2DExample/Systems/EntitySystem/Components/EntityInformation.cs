using Assets.Project2DExample.World.Components;
using EntitySystem.Abstract;
using EntitySystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace EntitySystem.Components
{
    public class EntityInformation : EntityComponent
    {
        public override Type[] Dependencies { get; set; } =
        {
            typeof(Characteristics),
        };


        [SerializeField] Transform _currentHP;
        public Transform CurrentHP
        {
            get { return _currentHP; }
            set { _currentHP = value; }
        }
        [SerializeField] List<TMP_Text> _skillsCooldown;
        public List<TMP_Text> SkillsCooldown
        {
            get { return _skillsCooldown; }
            set { _skillsCooldown = value; }
        }


        float CurrentHPStartLocalScaleX = 0;
        void Start()
        {
            Entity.OnDamageReceived += ChangeCurrentHP;
            CurrentHPStartLocalScaleX = CurrentHP.localScale.x;
        }

        void ChangeCurrentHP()
        {
            Characteristics characteristics = Entity.GetEntityComponent<Characteristics>();
            CurrentHP.localScale = new Vector2(characteristics.TotalHP / characteristics.MaxHP * CurrentHPStartLocalScaleX, CurrentHP.localScale.y);
        }
    }
}
