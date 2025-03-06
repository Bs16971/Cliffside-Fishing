
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

public class WaypointGeneratroWindow : EditorWindow
{
    private Transform parentTransform;

    private int numberOfWaypoints = 10;

    private Vector3 boxCenter = Vector3.zero;

    private Vector3 boxSize = new Vector3(20f, 20f, 20f);

    private bool showDebugBox = true;

    private Color debugBoxColor = Color.yellow;

    private bool showWaypointGizmos = true;

    private float waypointGizmosSize = 0.5f;

    private Color waypointGizmoColor = Color.cyan;

    private List<GameObject> generatedWaypoints = new List<GameObject>();

    [MenuItem("Tools/Random Waypoint Generator")]

    public static void ShowWindow()
    {
        GetWindow<WaypointGeneratroWindow>("Random Waypoint Generator");
    }

    private void OnGUI()
    {
        parentTransform =
            (Transform)EditorGUILayout.ObjectField("Parent Transform", parentTransform, typeof(Transform), true);
        numberOfWaypoints = EditorGUILayout.IntField("Number of Waypoints", numberOfWaypoints);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Box Settings", EditorStyles.boldLabel);
        boxCenter = EditorGUILayout.Vector3Field("Box Center (World", boxCenter);
        boxSize = EditorGUILayout.Vector3Field("Box Size", boxSize);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Debug Visualization", EditorStyles.boldLabel);
        showDebugBox = EditorGUILayout.Toggle("Show Box in Scene", showDebugBox);
        debugBoxColor = EditorGUILayout.ColorField("Box Color", debugBoxColor);

        showWaypointGizmos = EditorGUILayout.Toggle("Show Waypoints in Scene", showWaypointGizmos);
        waypointGizmoColor = EditorGUILayout.ColorField("Waypoints Color", waypointGizmoColor);
        waypointGizmosSize = EditorGUILayout.Slider("Waypoint Gizmo Size", waypointGizmosSize, 0.1f, 0.2f);
        
        EditorGUILayout.Space();

        if (GUILayout.Button("Generate Random Waypoints"))
        {
            
        }

        if (GUILayout.Button("Clear Generated Waypoints"))
        {
            
        }
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
