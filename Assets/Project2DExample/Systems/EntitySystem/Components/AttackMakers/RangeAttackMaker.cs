using Assets.Project2DExample.World.Components;
using EntitySystem.Objects;
using EntitySystem.Objects.UniqueEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EntitySystem.Components
{
    public class RangeAttackMaker : AttackMaker
    {
        public override Type[] Dependencies { get; set; } =
        {
            typeof(Rigidbody2DMover),
            typeof(EffectsSystem),
        };

        [SerializeField] Projectile ProjectilePrefab;
        [SerializeField] GameObject ProjectileHeap;

        protected override void MakeAttack(Attack attack)
        {
            Entity.Animator.SetInteger("Attack", attack.Id);
            EffectsSystem effectsSystem = Entity.GetEntityComponent<EffectsSystem>();
            effectsSystem.AddUniqueEffectOnTime(new EffectStun(effectsSystem), attack.WeeknessTime);
            Damage damage = new Damage(attack.DamageType, Entity.Characteristics.Attack * attack.Multiplier, new Vector2());
            ProjectilePrefab.DamageZone.Damage = damage;
            ProjectilePrefab.DamageZone.gameObject.SetActive(true);
            ProjectilePrefab.Rigidbody2D.AddForce(_cursorDirection * attack.DamagePushForce, ForceMode2D.Force);
            Entity.GetEntityComponent<Rigidbody2DMover>().StopMove();
            Entity.Rigidbody2D.AddForce(_cursorDirection * attack.AttakerPushForce, ForceMode2D.Force);
        }
    }
}
