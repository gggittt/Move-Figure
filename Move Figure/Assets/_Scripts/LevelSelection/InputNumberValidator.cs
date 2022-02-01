using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class InputNumberValidator : MonoBehaviour
{
    [SerializeField] private string _allowedChars = "0123456789";
    private InputField _component;

    
    private void Awake()
    {
        _component = GetComponent<InputField>();
        _component.onValidateInput += (input, charIndex, addedChar) => NumberValidate(addedChar);
    }

    private char NumberValidate(char charToValidate)
    {
        var isInsertedNumber = _allowedChars.Contains(charToValidate.ToString());
        if (isInsertedNumber == false)
        {
            charToValidate = '\0';
        }
        
        return charToValidate;
    }
}