using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringtoFront : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable(){
        transform.SetAsLastSibling();
    }
}
