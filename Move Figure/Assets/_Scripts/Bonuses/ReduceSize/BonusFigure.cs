using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BonusFigure : MonoBehaviour
{
    
    [SerializeField] private int _size = 4;
    [SerializeField] private int _bonusAmount = 1;
    public int BonusAmount => _bonusAmount;

    private void OnValidate()
    {
        transform.localScale = new Vector3(_size, _size, _size);
    }

    private void OnMouseDown()
    {
        FindObjectOfType<BonusSelector>().SelectBonus(this);
        
    }
}


