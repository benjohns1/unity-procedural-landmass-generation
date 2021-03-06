﻿using UnityEngine;
using UnityEditor;

namespace WorldGenerator
{
    [CustomEditor(typeof(TerrainGenerator))]
    public class TerrainEditor : Editor
    {
        TerrainGenerator terrainGenerator;
        Editor worldEditor;
        Editor globalHeightMapEditor;
        Editor meshSettingsEditor;

        private void OnEnable()
        {
            terrainGenerator = (TerrainGenerator)target;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (terrainGenerator == null)
            {
                return;
            }
            DrawSettingsEditors();

            if (GUILayout.Button("Generate Terrain"))
            {
                terrainGenerator.GenerateTerrain();
            }
            if (GUILayout.Button("Clear All Terrain Chunks"))
            {
                terrainGenerator.ClearTerrainChunks();
            }
        }
        
        private void DrawSettingsEditors()
        {
            if (terrainGenerator.worldSettings != null)
            {
                WorldSettings settings = terrainGenerator.worldSettings;
                DrawSettingsEditor(settings, ref terrainGenerator.worldFoldout, ref worldEditor);
                DrawSettingsEditor(settings.globalHeightMapSettings, ref settings.globalHeightMapSettingsFoldout, ref globalHeightMapEditor);
                DrawSettingsEditor(settings.meshSettings, ref settings.meshSettingsFoldout, ref meshSettingsEditor);
            }
        }

        void DrawSettingsEditor(Object settings, ref bool foldout, ref Editor editor)
        {
            if (settings == null)
            {
                return;
            }
            foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                if (!foldout)
                {
                    return;
                }
                CreateCachedEditor(settings, null, ref editor);
                editor.OnInspectorGUI();
            }
        }
    }
}