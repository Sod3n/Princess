using EntitySystem.Abstract;
using EntitySystem.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EntitySystem.Components
{
    public class SkillsManager : EntityComponent
    {
        public override Type[] Dependencies { get; set; } =
        {
            typeof(EntityInformation),
        };

        [SerializeField] private Skill[] _skills = new Skill[4];

        private void Update()
        {
            for (int i = 0; i < _skills.Length; i++)
            {
                if (Entity.ControllsSelector.Controlls.Skills.Count <= i) break;
                if(_skills[i] != null && Entity.ControllsSelector.Controlls.Skills[i])
                    _skills[i].TryActivate();
            }


            for(int i = 0; i < _skills.Length; i++)
            {
                if(_skills[i] == null || Mathf.Ceil(_skills[i].RemainCooldown) <= 0)
                {
                    Entity.GetEntityComponent<EntityInformation>().SkillsCooldown[i].text = "";
                }
                else
                {
                    Entity.GetEntityComponent<EntityInformation>().SkillsCooldown[i].text = Mathf.Ceil(_skills[i].RemainCooldown).ToString();
                }
            }
        }
    }
}
