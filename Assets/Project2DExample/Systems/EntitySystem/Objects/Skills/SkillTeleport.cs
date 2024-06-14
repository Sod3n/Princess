using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EntitySystem.Objects.Skills
{
    public class SkillTeleport : Skill
    {
        protected override void Activate()
        {
            _entity.Rigidbody2D.transform.position = _entity.ControllsSelector.Controlls.Cursor;
        }
    }
}
