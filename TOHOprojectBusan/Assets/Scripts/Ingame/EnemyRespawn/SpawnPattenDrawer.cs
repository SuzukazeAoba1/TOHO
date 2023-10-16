//using UnityEngine;
//using UnityEditor;

//[CustomPropertyDrawer(typeof(SpawnPatten))]
//public class SpawnPattenDrawer : PropertyDrawer
//{
//    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//    {
//        // Using BeginProperty / EndProperty on the parent property means that
//        // prefab override logic works on the entire property.
//        EditorGUI.BeginProperty(position, label, property);

//        // Draw label
//        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

//        // Don't make child fields be indented
//        var indent = EditorGUI.indentLevel;
//        EditorGUI.indentLevel = 0;


//        float x1 = 40,
//         x2 = x1 + 76,
//         x3 = x2 + 41,
//         x4 = x3 + 41,
//         x5 = x4 + 41,
//         x6 = x5 + 42;

//        // Calculate rects
//        var spawntimeRect   = new Rect(x1, position.y, 75, position.height);
//        var enemyidRect     = new Rect(x2, position.y, 40, position.height);
//        var spawnposidRect  = new Rect(x3, position.y, 40, position.height);
//        var moveidRect      = new Rect(x4, position.y, 40, position.height);
//        var barrageidRect   = new Rect(x5, position.y, 40, position.height);
//        var spawnfilpRect   = new Rect(x6, position.y, 20, position.height);

//        // Draw fields - pass GUIContent.none to each so they are drawn without labels
//        EditorGUI.PropertyField(spawntimeRect, property.FindPropertyRelative("m_spawntime"), GUIContent.none);
//        EditorGUI.PropertyField(enemyidRect, property.FindPropertyRelative("m_enemyid"), GUIContent.none);
//        EditorGUI.PropertyField(spawnposidRect, property.FindPropertyRelative("m_spawnposid"), GUIContent.none);
//        EditorGUI.PropertyField(moveidRect, property.FindPropertyRelative("m_movesequenceid"), GUIContent.none);
//        EditorGUI.PropertyField(barrageidRect, property.FindPropertyRelative("m_barragesequenceid"), GUIContent.none);
//        EditorGUI.PropertyField(spawnfilpRect, property.FindPropertyRelative("m_spawnfilp"), GUIContent.none);

//        // Set indent back to what it was
//        EditorGUI.indentLevel = indent;

//        EditorGUI.EndProperty();
//    }
//}