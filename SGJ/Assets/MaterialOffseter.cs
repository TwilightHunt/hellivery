using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialOffseter : MonoBehaviour
{
    [SerializeField] float offsetSpeed;
    Material material;
    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }
    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset = new Vector2(material.mainTextureOffset.x + offsetSpeed * Time.deltaTime, material.mainTextureOffset.y);
    }
}
