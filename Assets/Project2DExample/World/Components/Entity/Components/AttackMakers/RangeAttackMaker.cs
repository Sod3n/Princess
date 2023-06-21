using Assets.Project2DExample.World.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Project2DExample.World.Objects.UniqueEffects;

namespace Assets.Project2DExample.World.Components
{
    public class RangeAttackMaker : AttackMaker
    {
        public override Type[] Dependencies { get; set; } =
        {
            typeof(Rigidbody2DMover),
        };

        [SerializeField] Projectile ProjectilePrefab;
        [SerializeField] GameObject ProjectileHeap;

        protected override void MakeAttack(Attack attack)
        {
            Entity.Animator.SetInteger("Attack", attack.Id);
            Entity.AddUniqueEffectOnTime(new EffectStun(Entity), attack.WeeknessTime);
            Damage damage = new Damage(attack.DamageType, Entity.Characteristics.Attack * attack.Multiplier, new Vector2());
            ProjectilePrefab.DamageZone.Damage = damage;
            ProjectilePrefab.DamageZone.gameObject.SetActive(true);
            ProjectilePrefab.Rigidbody2D.AddForce(_cursorDirection * attack.DamagePushForce, ForceMode2D.Force);
            Entity.GetEntityComponent<Rigidbody2DMover>().StopMove();
            Entity.Rigidbody2D.AddForce(_cursorDirection * attack.AttakerPushForce, ForceMode2D.Force);
        }
    }
}
