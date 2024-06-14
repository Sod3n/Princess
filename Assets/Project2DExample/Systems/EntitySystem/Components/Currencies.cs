using EntitySystem.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EntitySystem.Components
{
    [Serializable]
    public class Currencies : EntityComponent
    {
        [SerializeField] int _gold;
        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }
    }
}
