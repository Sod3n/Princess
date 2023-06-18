﻿using Assets.Project2DExample.World.Objects;
using Assets.Project2DExample.World.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Components
{
    public class SkillsManager : MonoBehaviour
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private Skill[] _skills = new Skill[4];

        private void Update()
        {
            for (int i = 0; i < _skills.Length; i++)
            {
                if (_entity.ControllsSelector.Controlls.Skills.Count <= i) break;
                if(_skills[i] != null && _entity.ControllsSelector.Controlls.Skills[i])
                    _skills[i].TryActivate();
            }


            for(int i = 0; i < _skills.Length; i++)
            {
                if(_skills[i] == null || Mathf.Ceil(_skills[i].RemainCooldown) <= 0)
                {
                    _entity.EntityInformation.SkillsCooldown[i].text = "";
                }
                else
                {
                    _entity.EntityInformation.SkillsCooldown[i].text = Mathf.Ceil(_skills[i].RemainCooldown).ToString();
                }
            }
        }
    }
}
