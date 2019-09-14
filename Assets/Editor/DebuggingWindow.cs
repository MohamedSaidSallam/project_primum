﻿using UnityEditor;
using UnityEngine;

public class DebuggingWindow : EditorWindow
{
    private int dmgAmount, healAmount;
    private bool healthSectionFoldState;


    [MenuItem("Window/DebuggingWindow")]
    public static void ShowWindow()
    {
        GetWindow<DebuggingWindow>("DebuggingWindow").Show();
    }

    private void OnGUI()
    {
        if (EditorApplication.isPlaying)
        {
            HealthSection();
        }
        else
        {
            GUILayout.Label("not in play mode", EditorStyles.miniLabel);
        }

    }

    private void HealthSection()
    {
        healthSectionFoldState = EditorGUILayout.Foldout(healthSectionFoldState, "Health");
        if (healthSectionFoldState)
        {
            dmgAmount = EditorGUILayout.IntField("Damage Amount", dmgAmount);
            if (GUILayout.Button("Damage Player"))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>().Damage(dmgAmount);
            }

            healAmount = EditorGUILayout.IntField("Heal Amount", healAmount);
            if (GUILayout.Button("Heal Player"))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>().Heal(healAmount);
            }
        }
    }
}
