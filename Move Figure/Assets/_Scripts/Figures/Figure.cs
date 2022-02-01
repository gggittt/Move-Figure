using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Figure : MonoBehaviour
{
    
    [SerializeField] protected int _size = 5;
    
    private void OnValidate()
    {
        SetScale();
    }

    protected virtual void SetScale()
    {
        transform.localScale = new Vector3(_size, _size, _size);
    }

}


