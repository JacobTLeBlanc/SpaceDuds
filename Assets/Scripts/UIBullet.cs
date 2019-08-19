using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBullet : MonoBehaviour
{
    // Instance of class
    public static UIBullet instance { get; private set; }

    // Mask
    public Image mask;

    // Original size of mask
    float originalSize;
    
    void Awake()
    {
        // Make this object the only instance
        instance = this;
    }

    void Start()
    {
        // Get original size
        originalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        // Update size according to value
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
