using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _boxEndPoint;
    [SerializeField]
    private GameObject _disappearingBoxCollider;
    [SerializeField]
    private GameObject _attachTransform;
    [SerializeField]
    private GameObject _2ndPipe;
    private float _speed = .003f;
    private bool _didBoxMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BurnBoxMove();
    }

    private void BurnBoxMove()
    {
        if (transform.position != _boxEndPoint.transform.position && _didBoxMove == false)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,
                _boxEndPoint.transform.position, _speed);
        }
        else if (transform.position == _boxEndPoint.transform.position)
        {
            _didBoxMove = true;
            Debug.Log("Did the method stop?");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NudgePoint")
        {
            Destroy(_disappearingBoxCollider.gameObject);
            _attachTransform.gameObject.SetActive(true);
            _didBoxMove = false;
            Destroy(_2ndPipe.gameObject, 1.5f);
        }
    }
}
