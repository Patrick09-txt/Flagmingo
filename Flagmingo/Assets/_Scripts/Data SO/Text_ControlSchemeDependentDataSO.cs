using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/Text_ControlSchemeDependent")]
public class Text_ControlSchemeDependentDataSO : ScriptableObject
{
    [SerializeField] public string PickUpFlag_Text;
    [SerializeField] public string PickUpItem_Text;
    [SerializeField] public string InteractNPC_Text;
}
