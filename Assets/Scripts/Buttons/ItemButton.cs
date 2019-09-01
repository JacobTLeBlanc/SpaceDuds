using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Items items;
    public int direction;

    private void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(changeItem);
    }

    void changeItem()
    {
        items.changeIndex(direction);
    }
}
