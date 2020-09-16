using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject prefab;
    public GameObject pointer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handleClick()
    {
        var obj = Instantiate(prefab,pointer.transform.position,Quaternion.identity);
        obj.GetComponent<Placable>().pointer = pointer;
    }
}
