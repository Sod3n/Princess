using Assets.Project2DExample.World.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityComponent : MonoBehaviour
{
    public Entity Entity { get; set; }
    public virtual Type[] Dependencies { get; set; }
}
