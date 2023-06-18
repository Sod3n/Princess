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
        [SerializeField] Projectile ProjectilePrefab;
        [SerializeField] GameObject ProjectileHeap;
        protected override void MakeAttack(Attack attack)
        {
            _entity.Animator.SetInteger("Attack", attack.Id);
            _entity.AddUniqueEffectOnTime(new EffectStun(_entity), attack.WeeknessTime);
            Damage damage = new Damage(attack.DamageType, _entity.Characteristics.Attack * attack.Multiplier, new Vector2());
            ProjectilePrefab.DamageZone.Damage = damage;
            ProjectilePrefab.DamageZone.gameObject.SetActive(true);
            ProjectilePrefab.Rigidbody2D.AddForce(_cursorDirection * attack.DamagePushForce, ForceMode2D.Force);
            _entity.Rigidbody2DMover.StopMove();
            _entity.Rigidbody2D.AddForce(_cursorDirection * attack.AttakerPushForce, ForceMode2D.Force);
        }
    }
}
