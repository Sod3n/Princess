using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using Assets.Project2DExample.World.Components;
using EntitySystem.Objects;
using EntitySystem.Objects.UniqueEffects;

namespace EntitySystem.Components
{
    public class MeleeAttackMaker : AttackMaker
    {
        public override Type[] Dependencies { get; set; } =
        {
            typeof(Rigidbody2DMover),
            typeof(EffectsSystem),
        };

        [SerializeField] private DamageZone _damageZone;
        public DamageZone DamageZone
        {
            get { return _damageZone; }
        }
        protected override void MakeAttack(Attack attack)
        {
            Entity.Animator.SetInteger("Attack", attack.Id);
            EffectsSystem effectsSystem = Entity.GetEntityComponent<EffectsSystem>();
            effectsSystem.AddUniqueEffectOnTime(new EffectStun(effectsSystem), attack.WeeknessTime);
            Damage damage = new Damage(attack.DamageType, Entity.Characteristics.Attack * attack.Multiplier, _cursorDirection * attack.DamagePushForce);
            DamageZone.Damage = damage;
            DamageZone.Active = true;
            Entity.GetEntityComponent<Rigidbody2DMover>().StopMove();
            Entity.Rigidbody2D.AddForce(_cursorDirection * attack.AttakerPushForce, ForceMode2D.Force);
            StartCoroutine(DisableDamageZone(attack.DamageTime));
        }

        IEnumerator DisableDamageZone(float time)
        {
            yield return new WaitForSeconds(time);
            DamageZone.Active = false;
        }
    }
}
