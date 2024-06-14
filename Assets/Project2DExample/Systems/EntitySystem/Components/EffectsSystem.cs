using Assets.Project2DExample.World.Components;
using EntitySystem.Abstract;
using EntitySystem.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EntitySystem.Components
{
    public class EffectsSystem : EntityComponent
    {

        [SerializeField] private List<CharacteristicsEffect> _characteristicsEffects = new List<CharacteristicsEffect>();
        public List<CharacteristicsEffect> CharacteristicsEffects
        {
            get
            {
                return _characteristicsEffects;
            }
            set
            {
                _characteristicsEffects = value;
            }
        }

        [SerializeField] private List<Effect> _uniqueEffects = new List<Effect>();
        public List<Effect> UniqueEffects
        {
            get
            {
                return _uniqueEffects;
            }
            set
            {
                _uniqueEffects = value;
            }
        }

        #region Effects interactions

        public void AddCharacteristicsEffect(CharacteristicsEffect characteristicEffect)
        {
            var effects = from c in CharacteristicsEffects
                          where c.GUID == characteristicEffect.GUID
                          select c;
            if (effects.Count() > 0) return;
            characteristicEffect.EffectsSystem = this;
            CharacteristicsEffects.Add(characteristicEffect);
        }
        public void AddCharacteristicsEffectOnTime(CharacteristicsEffect characteristicEffect, float timeInSec)
        {
            AddCharacteristicsEffect(characteristicEffect);

            StartCoroutine(CoroutinRemoveEffectOnTime(characteristicEffect, timeInSec));
        }
        public void AddUniqueEffect(Effect effect)
        {
            if (!UniqueEffects.Contains(effect))
            {
                effect.EffectsSystem = this;
                UniqueEffects.Add(effect);
            }
        }
        public void AddUniqueEffectOnTime(Effect effect, float timeInSec)
        {
            AddUniqueEffect(effect);

            StartCoroutine(CoroutinRemoveEffectOnTime(effect, timeInSec));
        }
        public IEnumerator CoroutinRemoveEffectOnTime(Effect effect, float timeInSec)
        {
            yield return new WaitForSeconds(timeInSec);
            //Effect e = Effects.Find(x => x.Tag == effect.Tag);
            effect.Remove();
        }
        #endregion
    }

}
