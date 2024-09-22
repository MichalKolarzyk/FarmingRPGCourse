using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventoryPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textHeader1 = null;
    [SerializeField] private TextMeshProUGUI textHeader2 = null;
    [SerializeField] private TextMeshProUGUI textHeader3 = null;
    [SerializeField] private TextMeshProUGUI textBody1 = null;
    [SerializeField] private TextMeshProUGUI textBody2 = null;
    [SerializeField] private TextMeshProUGUI textBody3 = null;
    private ItemDefinition model;

    void Start(){
        SetModel(null);
    }

    public void Show(ItemDefinition model){
        SetModel(model);
    }

    public void Hide(){
        SetModel(null);
    }

    private void SetModel(ItemDefinition model = null){
        this.model = model;
        if(model == null){
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
        textHeader1.text = model.description;

    }
}
