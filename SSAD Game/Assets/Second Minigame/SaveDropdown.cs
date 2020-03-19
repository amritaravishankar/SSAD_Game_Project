using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class SaveDropdown : MonoBehaviour
{
    const string PrefName = "optionvalue";
    // Start is called before the first frame update
    
    private Dropdown _dropdown;

    void Awake()
    {
        _dropdown = GetComponent<Dropdown>();
        _dropdown.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(PrefName, _dropdown.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        _dropdown.value = PlayerPrefs.GetInt(PrefName, 0);
    }

}
