using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlot : MonoBehaviour
{
    public Sprite itemSprite;
    public Button button;
    private void Awake()
    {
        var i = GetComponentsInChildren<Image>();
        itemSprite = i[1].sprite;
        button = GetComponent<Button>();
    }
}
