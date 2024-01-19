using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEditor.Animations;
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
    [SerializeField]
    private GameObject _gunSpark;
    [SerializeField]
    private GameObject _explosion1;
    [SerializeField] 
    private GameObject _explosion2;
    [SerializeField] 
    private GameObject _explosion3;
    [SerializeField] 
    private GameObject _boxFlame;
    [SerializeField]
    private GameObject _cageFlame;
    [SerializeField]
    private GameObject _cagebox;
    [SerializeField]
    private GameObject _burnBox;
    [SerializeField]
    private GameObject _thinnerCan1;
    [SerializeField]
    private GameObject _thinnerCan2;
    [SerializeField]
    private GameObject _oilCan;
    [SerializeField]
    private GameObject _smoke1;
    [SerializeField]
    private GameObject _smoke2;
    [SerializeField]
    private GameObject _explosionPointLight1;
    [SerializeField]
    private GameObject _explosionPointLight2;
    [SerializeField] 
    private GameObject _explosionPointLight3;
    [SerializeField] 
    private GameObject _igniteSpark;
    private bool _isKey1 = false;
    private bool _isKey2 = false;
    private bool _isGunHovering = false;

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
    //Next 3 methods cover gunshot.
    public void GunCheck()
    {
        _isGunHovering = true;
    }
    public void GunExits()
    {
        _isGunHovering = false;
    }
    public void GunHover()
    {
        if(_isGunHovering == true)
        {
            _gunSpark.gameObject.SetActive(true);
            StartCoroutine(UpInFlames());
        }
    }

    IEnumerator UpInFlames()
    {
        yield return new WaitForSeconds(.06f);
        _igniteSpark.gameObject.SetActive(true);
        _explosion1.gameObject.SetActive(true);
        _explosion2.gameObject.SetActive(true);
        yield return new WaitForSeconds(.7f);
        _explosionPointLight1.gameObject.SetActive(true);
        _explosionPointLight2.gameObject.SetActive(true);
        _burnBox.gameObject.SetActive(false);
        Destroy(_thinnerCan1.gameObject);
        Destroy(_thinnerCan2.gameObject);
        _boxFlame.gameObject.SetActive(true);
        _smoke1.gameObject.SetActive(true);
        yield return new WaitForSeconds(.3f);       
        yield return new WaitForSeconds(.2f);
        _cageFlame.gameObject.SetActive(true);
        _smoke2.gameObject.SetActive(true);
        yield return new WaitForSeconds(.2f);
        _explosion3.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        Destroy(_oilCan.gameObject);
        yield return new WaitForSeconds(.2f);
        _cagebox.gameObject.SetActive(false);
        _explosionPointLight3.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);        
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
