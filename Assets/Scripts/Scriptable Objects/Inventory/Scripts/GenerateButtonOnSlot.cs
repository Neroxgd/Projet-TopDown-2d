using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UI_Inventory))]
public class GenerateButtonOnSlot : Editor
{
    private bool ifGenerate = true;
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Generate Button On Slot"))
            ifGenerate = false;
        
        if(!ifGenerate)
        {
            Generation();
            ifGenerate = true;
        }
        base.OnInspectorGUI();
    }

    private void Generation()
    {
        UI_Inventory uI_Inventory = (UI_Inventory)target;
        for (int i = 0; i < uI_Inventory.Slot.childCount; i++)
            Instantiate(uI_Inventory.ButtonToInstanciat, uI_Inventory.Slot.GetChild(i).transform.position, Quaternion.identity, uI_Inventory.ButtonSelect);
    }
}
