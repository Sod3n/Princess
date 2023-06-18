using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Objects
{
    [Serializable]
    public class Currencies
    {
        [SerializeField] int _gold;
        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }
    }
}
