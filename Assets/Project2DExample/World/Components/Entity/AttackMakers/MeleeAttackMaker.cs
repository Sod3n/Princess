using Assets.Project2DExample.World.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Project2DExample.World.Objects.UniqueEffects;
using System.Collections;

namespace Assets.Project2DExample.World.Components
{
    public class MeleeAttackMaker : AttackMaker
    {
        [SerializeField] private DamageZone _damageZone;
        public DamageZone DamageZone
        {
            get { return _damageZone; }
        }
        protected override void MakeAttack(Attack attack)
        {
            _entity.Animator.SetInteger("Attack", attack.Id);
            _entity.AddUniqueEffectOnTime(new EffectStun(_entity), attack.WeeknessTime);
            Damage damage = new Damage(attack.DamageType, _entity.Characteristics.Attack * attack.Multiplier, _cursorDirection * attack.DamagePushForce);
            DamageZone.Damage = damage;
            DamageZone.Active = true;
            _entity.Rigidbody2DMover.StopMove();
            _entity.Rigidbody2D.AddForce(_cursorDirection * attack.AttakerPushForce, ForceMode2D.Force);
            StartCoroutine(DisableDamageZone(attack.DamageTime));
        }

        IEnumerator DisableDamageZone(float time)
        {
            yield return new WaitForSeconds(time);
            DamageZone.Active = false;
        }
    }
}
