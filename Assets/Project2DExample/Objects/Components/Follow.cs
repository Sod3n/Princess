using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.World.Components
{
    public class Follow : MonoBehaviour
    {
        [SerializeField] GameObject _gameObject;
        [SerializeField] float _interpolation;
        [SerializeField] float _permanentZ = -10;
        private void FixedUpdate()
        {
            Vector2 vector2 = Vector2.Lerp(transform.position, _gameObject.transform.position, _interpolation);
            transform.position = new Vector3(vector2.x, vector2.y, _permanentZ);
        }
    }
}
