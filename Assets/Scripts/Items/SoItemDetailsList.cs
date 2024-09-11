using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDetailsList", menuName = "ScriptableObjects/Item/ItemDetailsList")]
public class SoItemDetailsList : ScriptableObject
{
    [SerializeField]
    public List<ItemDetails> itemDetailsList;
}
