using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParent : MonoBehaviour
{
    public GameObject box;
    private void OnDestroy()
    {
        Destroy(box);
    }
}
