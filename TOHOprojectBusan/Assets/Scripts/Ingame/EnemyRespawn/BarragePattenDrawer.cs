using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(BarrageData))]
public class BarragePattenDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;


        float x1 = 85,
         x2 = x1 + 41,
         x3 = x2 + 51,
         x4 = x3 + 31,
         x5 = x4 + 31,
         x6 = x5 + 31;

        // Calculate rects
        var Rect1 = new Rect(x1, position.y, 40, position.height);
        var Rect2 = new Rect(x2, position.y, 50, position.height);
        var Rect3 = new Rect(x3, position.y, 30, position.height);
        var Rect4 = new Rect(x4, position.y, 30, position.height);
        var Rect5 = new Rect(x5, position.y, 30, position.height);
        var Rect6 = new Rect(x6, position.y, 40, position.height);

        // Draw fields - pass GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(Rect1, property.FindPropertyRelative("m_barrageid"), GUIContent.none);
        EditorGUI.PropertyField(Rect2, property.FindPropertyRelative("m_angle"), GUIContent.none);
        EditorGUI.PropertyField(Rect3, property.FindPropertyRelative("m_distance"), GUIContent.none);
        EditorGUI.PropertyField(Rect4, property.FindPropertyRelative("m_basespeed"), GUIContent.none);
        EditorGUI.PropertyField(Rect5, property.FindPropertyRelative("m_addspeed"), GUIContent.none);
        EditorGUI.PropertyField(Rect6, property.FindPropertyRelative("m_delay"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
