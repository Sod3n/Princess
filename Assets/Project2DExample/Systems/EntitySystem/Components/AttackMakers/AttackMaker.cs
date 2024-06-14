using EntitySystem.Abstract;
using EntitySystem.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EntitySystem.Components
{
    public abstract class AttackMaker : EntityComponent
    {
        [SerializeField] protected List<Attack> _attacks;

        protected Vector2 _cursorDirection = new Vector2();

        public delegate void OnAttackMakeEventHandler(ref Attack attack);
        public event OnAttackMakeEventHandler OnAttackMake = delegate { };

        private float _lastAttackTime = 0;
        private Attack _lastAttack = Attack.NullAttack;
        protected abstract void MakeAttack(Attack attack);

        private void ResetLastAttackTime()
        {
            _lastAttackTime = 0;
        }
        protected virtual void Start()
        {

        }
        protected virtual void Update()
        {
            if (Entity.ControllsSelector.Controlls.Attack)
            {
                _cursorDirection = (Entity.ControllsSelector.Controlls.Cursor - (Vector2)Entity.Rigidbody2D.transform.position).normalized;
                if (Entity.Characteristics.CanAttack)
                {
                    Attack findedAttack = GetNextAttack();
                    if (findedAttack != null)
                    {
                        _lastAttack = findedAttack;
                        OnAttackMake.Invoke(ref findedAttack);
                        MakeAttack(findedAttack);
                    }
                    ResetLastAttackTime();
                }
            }
        }
        protected Attack GetNextAttack()
        {
            var findedAttacks = from a in _attacks
                                where (a.Id == _lastAttack.PreviousAttackId)
                                orderby a.TimeToMake
                                where ((_lastAttackTime - a.WeeknessTime) < a.TimeToMake)
                                select a;
            Attack findedAttack = (from a in _attacks
                                   where a.Id == 1
                                   select a).First();
            if (findedAttacks.Count() > 0) findedAttack = findedAttacks.First();
            return findedAttack;
        }
    }
}
