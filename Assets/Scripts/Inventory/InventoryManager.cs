using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Dictionary<int, ItemDetails> _itemDetailsDictionary;
    
    [SerializeField]
    private SoItemDetailsList soItemDetailsList;

    void Start(){
        _itemDetailsDictionary = new();
        foreach(var item in soItemDetailsList.itemDetailsList){
            _itemDetailsDictionary.Add(item.code, item);
        }
    }

    public ItemDetails GetItemDetails(int code){
        _ = _itemDetailsDictionary.TryGetValue(code, out ItemDetails itemDetails);
        return itemDetails;
    }
}
