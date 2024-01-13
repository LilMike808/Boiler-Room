using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    public GameObject _topLock;
    [SerializeField]
    private GameObject _bottomLock;
    [SerializeField]
    private GameObject _Key1;
    [SerializeField]
    private GameObject _Key2;
    [SerializeField]
    private GameObject _flame;
    [SerializeField]
    private GameObject _spark;
    [SerializeField]
    private GameObject _chains;
    private bool _isKey1 = false;
    private bool _isKey2 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHover()
    {
        if(this.gameObject.activeSelf == true)
        {
            this.gameObject.SetActive(false);
        }
        else if(this.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(true);
        }
    }

    public void TurnKey1()
    {
        _isKey1 = true;
    }
    public void TurnKey2()
    {
        _isKey2 = true;
    }
    public void AreBothKeysIn()
    {
        if (_isKey1 == true && _isKey2 == true)
        {
            _flame.gameObject.SetActive(true);
            Destroy(_Key1.gameObject, 2);
            Destroy(_Key2.gameObject, 4);
            Destroy(_bottomLock.gameObject, 3);
            Destroy(_topLock.gameObject, 5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HammerHead")
        {
            _spark.gameObject.SetActive(true);
            Destroy(_chains.gameObject);
        }
    }

}
