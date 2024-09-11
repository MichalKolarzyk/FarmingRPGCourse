using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ItemCodeDescriptionAttribute))]
public class ItemCodeDescription : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property) * 2;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
    //     EditorGUI.BeginProperty(position, label, property);
    //     if(property.propertyType == SerializedPropertyType.Integer){

    //         EditorGUI.BeginChangeCheck();

    //         var newValue = EditorGUI.IntField()

    //         if(EditorGUI.EndChangeCheck()){
    //             property.intValue = newValue;
    //         }

    //     }
    //     EditorGUI.EndProperty();
    }
}
