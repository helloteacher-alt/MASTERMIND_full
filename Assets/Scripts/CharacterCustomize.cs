using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();

        // dropdown.options.Clear();

        DropdownSelected(dropdown);

        // List<string> items = new List<string>();

    }

    void DropdownSelected(Dropdown dropdown){
        int index = dropdown.value;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
