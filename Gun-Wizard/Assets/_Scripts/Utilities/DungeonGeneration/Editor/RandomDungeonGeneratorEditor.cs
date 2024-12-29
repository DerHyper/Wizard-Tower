using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AbstractDungeonGenerater), true)]
public class RandomDungeonGeneratorEditor : Editor
{
   AbstractDungeonGenerater generator;

   private void Awake()
   {
    generator = (AbstractDungeonGenerater)target;
   }

   public override void OnInspectorGUI()
   {
        base.OnInspectorGUI();
        if(GUILayout.Button("Create Dungeon"))
        {
            generator.GenerateDungeon();
        }
   }
}