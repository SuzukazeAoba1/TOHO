//using UnityEngine;
//using UnityEditor;

//[CustomPropertyDrawer(typeof(MovePatten))]
//public class MovePattenDrawer : PropertyDrawer
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

//        float firstX = 100, secX = firstX + 95, thirdX = secX + 108;

//        // Calculate rects
//        var pattenIdRect = new Rect(firstX, position.y, 90, position.height);
//        var speedRect = new Rect(secX, position.y, 105, position.height);
//        var posRect = new Rect(thirdX, position.y, 110, position.height);

//        // Draw fields - pass GUIContent.none to each so they are drawn without labels
//        EditorGUI.PropertyField(pattenIdRect, property.FindPropertyRelative("m_pattenId"), GUIContent.none);
//        EditorGUI.PropertyField(speedRect, property.FindPropertyRelative("m_spd"), GUIContent.none);
//        EditorGUI.PropertyField(posRect, property.FindPropertyRelative("m_Pos"), GUIContent.none);

//        // Set indent back to what it was
//        EditorGUI.indentLevel = indent;

//        EditorGUI.EndProperty();
//    }
//}
