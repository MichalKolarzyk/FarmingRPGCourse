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
    private RectTransform rectTransform;
    private Vector3 mouseOffset = new(20, -20, 0);

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        SetModel(null);
    }

    public void Show(ItemDefinition model)
    {
        SetModel(model);
    }

    public void Hide()
    {
        SetModel(null);
    }

    private void SetModel(ItemDefinition model = null)
    {
        this.model = model;
        if (model == null || model.IsEmpty())
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
        textHeader1.text = model.description;
        textBody1.text = model.longDescription;
        UpdatePosition();
    }

    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition(){
        var newPosition = Input.mousePosition + mouseOffset;
        var height = rectTransform.rect.height;
        var scale = rectTransform.lossyScale;
        if (newPosition.y - height * 4 < 0)
        {
            newPosition = new Vector3(newPosition.x, height * scale.y, newPosition.z);
        }
        transform.position = newPosition;
    }
}
