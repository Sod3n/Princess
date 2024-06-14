using EntitySystem.Components;
using EntitySystem.Core;
using EntitySystem.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffZone : MonoBehaviour
{
    [SerializeField] CharacteristicsEffect _characteristicsEffect;
    [SerializeField] float _buffTime = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity entity = collision.GetComponent<Entity>();
        if (entity)
        {
            EffectsSystem effectsSystem = entity.GetEntityComponent<EffectsSystem>();
            effectsSystem.AddCharacteristicsEffectOnTime(_characteristicsEffect, _buffTime);
        }
    }
}
