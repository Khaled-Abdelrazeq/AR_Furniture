using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingScript : MonoBehaviour
{

    [SerializeField] private GameObject boundingBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GetComponent<Lean.Common.LeanSelectable>().IsSelected)
        {
            boundingBox.SetActive(true);
        }
        else
            boundingBox.SetActive(false);
    }
}
