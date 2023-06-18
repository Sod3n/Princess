using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Project2DExample.World.UI
{
    public class EntityInformation : MonoBehaviour
    {
        [SerializeField] Transform _currentHP;
        public Transform CurrentHP
        {
            get { return _currentHP; }
            set { _currentHP = value; }
        }
        [SerializeField] List<TMP_Text> _skillsCooldown;
        public List<TMP_Text> SkillsCooldown
        {
            get { return _skillsCooldown; }
            set { _skillsCooldown = value; }
        }
    }
}
