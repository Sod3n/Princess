using EntitySystem.Core;
using EntitySystem.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Components
{
    public class DamageZone : MonoBehaviour
    {
        [SerializeField] protected Damage _damage = new Damage(DamageType.Common, 0, Vector2.zero);
        [SerializeField] protected List<EntityType> _enemies = new List<EntityType>();
        [SerializeField] protected List<EntityType> _friends = new List<EntityType>();
        [SerializeField] protected bool _active = false;

        public Damage Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public delegate void OnDamageMakeEventHandler(ref Damage damage);
        public event OnDamageMakeEventHandler OnDamageMake = delegate { };

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!_active) return;
            Entity entity = collision?.GetComponent<Entity>();
            if (entity == null) return;
            if (!((_enemies.Count == 0) || ((_enemies.Contains(entity.Type))))) return;
            if (!((_friends.Count == 0 || ((!_friends.Contains(entity.Type)))))) return;
            Damage damage = Damage.Copy();
            OnDamageMake.Invoke(ref damage);
            entity.ReceiveDamage(damage);
        }
    }
}
