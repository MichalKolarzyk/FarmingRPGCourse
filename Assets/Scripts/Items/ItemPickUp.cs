using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){
        if(!collision.TryGetComponent<Item>(out var item))
            return;
        
        print(item.itemDefinition.description);

    }
}
