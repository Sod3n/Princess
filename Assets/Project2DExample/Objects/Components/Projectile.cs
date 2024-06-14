using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Components
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] DamageZone _damageZone;
        [SerializeField] Rigidbody2D _rigidbody2d;
        public DamageZone DamageZone { get { return _damageZone; } set { _damageZone = value; } }
        public Rigidbody2D Rigidbody2D { get { return _rigidbody2d; } set { _rigidbody2d = value; } }
    }
}
