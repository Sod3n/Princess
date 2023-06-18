using Assets.Project2DExample.Hardware;
using Assets.Project2DExample.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample
{
    public enum ControllsType
    {
        None,
        KeyboardControlls

    }
    public class ControllsSelector : MonoBehaviour
    {
        public static bool BlockControlls { get; set; } = false;

        [SerializeField] private ControllsType _type = ControllsType.KeyboardControlls;
        public ControllsType Type
        {
            get { return _type; }
            set 
            { 
                _type = value;
                OnControllsTypeChange(Controlls);
            }
        }   

        public event Action<IControlls> OnControllsTypeChange = delegate { };


        private IControlls[] _controlls =
        {
            new NoneControlls(),
            new KeyboardControlls()
        };

        public IControlls Controlls
        {
            get
            {
                if (BlockControlls) return _controlls[0];
                _controlls[(int)ControllsType.KeyboardControlls] = StaticObjects.Settings.KeyboardControlls;
                return _controlls[(int)_type];
            }
        }
    }
}
