using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emissive_Switch : MonoBehaviour
{
    [SerializeField]
    private Material _emissiveMaterial;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnEmissionOnOrOff()
    {
        if (_emissiveMaterial.IsKeywordEnabled("_EMISSION"))
        {
            _emissiveMaterial.DisableKeyword("_EMISSION");
        }
        else
        {
            _emissiveMaterial.EnableKeyword("_EMISSION");
        }
    }

    private void OnDisable()
    {
        _emissiveMaterial.DisableKeyword("_EMISSION");
    }
}
