using Assets.Project2DExample.World.Components;
using EntitySystem.Abstract;
using EntitySystem.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[InitializeOnLoadAttribute]
public static class AutoBuildEntity
{
    static AutoBuildEntity()
    {
        EditorApplication.hierarchyChanged += OnHierarchyChanged;
    }

    static void OnHierarchyChanged()
    {
        Entity[] entities = Array.ConvertAll(Resources.FindObjectsOfTypeAll(typeof(Entity)), item => (Entity)item);
        for(int i = 0; i < entities.Length; i++)
        {
            foreach(EntityComponent g in entities[i].GetComponentsInChildren<EntityComponent>())
                AddEntityComponentToEntity(entities[i], g);
            foreach(EntityComponent g in entities[i].GetComponents<EntityComponent>())
                AddEntityComponentToEntity(entities[i], g);

            RemoveEntityComponentsThatNotChildrensOfEntity(entities[i]);

            List<Type> attachedComponentsTypes = GetTypesOfEntityComponents(entities[i].EntityComponents);
            foreach (EntityComponent g in entities[i].GetComponentsInChildren<EntityComponent>())
                CheckDependencies(attachedComponentsTypes, g);
        }
    }

    static void RemoveEntityComponentsThatNotChildrensOfEntity(Entity entity)
    {
        for(int i = 0; i < entity.EntityComponents.Count; i++)
        {
            EntityComponent entityComponent = entity.EntityComponents[i];
            if (entityComponent == null || !entityComponent.transform.IsChildOf(entity.transform))
            {
                entity.EntityComponents.Remove(entityComponent);
                EditorUtility.SetDirty(entity.gameObject);
                i--;
                if(entityComponent != null)
                {
                    entityComponent.Entity = null;
                    EditorUtility.SetDirty(entityComponent.gameObject);
                }
                Debug.Log(entityComponent.GetType() + " detached from " + entity.name);
            }
        }
    }
    static void CheckDependencies(List<Type> attachedComponentsTypes, EntityComponent entityComponent)
    {
        if (entityComponent.Dependencies != null)
            foreach (var d in entityComponent.Dependencies)
            {
                if (!attachedComponentsTypes.Contains(d))
                {
                    Debug.LogError(entityComponent.GetType() + " at " + entityComponent.Entity.gameObject.name + " needs " + d.ToString() + " to work properly!", entityComponent.Entity.gameObject);
                }
            }
    }
    static void AddEntityComponentToEntity(Entity entity, EntityComponent entityComponent)
    {
        if (!entity.EntityComponents.Contains(entityComponent))
        {
            entity.EntityComponents.Add(entityComponent);
            EditorUtility.SetDirty(entity.gameObject);
            Debug.Log(entityComponent.GetType() + " attached to " + entity.name);
        }
        if (!entityComponent.Entity)
        {
            entityComponent.Entity = entity;
            EditorUtility.SetDirty(entityComponent.gameObject);
        }
    }
    static List<Type> GetTypesOfEntityComponents(List<EntityComponent> components)
    {
        List<Type> types = new List<Type>();
        foreach(var c in components)
        {
            types.Add(c.GetType());
        }
        return types;
    }
}
