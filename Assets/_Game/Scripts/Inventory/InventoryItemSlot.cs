using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlot : MonoBehaviour
{
    public Image itemImage;
    public Button button;
    private void Awake()
    {
        var i = GetComponentsInChildren<Image>();
        itemImage = i[1];
        button = GetComponent<Button>();
    }
     public void SetSprite(Sprite sprite)
    {
        itemImage.sprite = sprite;
    }
}
