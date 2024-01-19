using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

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
    [SerializeField]
    private GameObject _thinnerCan1;
    [SerializeField]
    private GameObject _thinnerCan2;
    [SerializeField]
    private GameObject _gun;
    private float _speed = .003f;
    private bool _isSocket1 = false;
    private bool _isSocket2 = false;
    private bool _movingToward = false;
    public enum MoveState
    {
        Stay,
        Move,
        Stop
    }
    public MoveState currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = MoveState.Stay;
    }
    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case MoveState.Stay:
                _speed = 0;
                break;
            case MoveState.Move:
                _movingToward = true;
                _speed = .003f;
                StartCoroutine(BurnBoxMove());
                break;
            case MoveState.Stop:
                StopAllCoroutines();
                break;
        }
        if (transform.position != _boxEndPoint.transform.position && _movingToward == true)
        {
            currentState = MoveState.Move;
        }     
    }

    IEnumerator BurnBoxMove()
    {
        yield return new WaitForSeconds(.001f);
        if (transform.position != _boxEndPoint.transform.position)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,
                _boxEndPoint.transform.position, _speed);
        }
        else if (transform.position == _boxEndPoint.transform.position && _thinnerCan2.gameObject != null && _thinnerCan1.gameObject != null)
        {  
            _thinnerCan1.gameObject.SetActive(true);
            _thinnerCan2.gameObject.SetActive(true);
            currentState = MoveState.Stop;    
            Debug.Log("Did the method truly stop?");
        }
    }
    public void Socket1()
    {
        _isSocket1 = true;
    }
    public void Socket2()
    {
        _isSocket2 = true;
    }
    public void BothSockets()
    {
        if(_isSocket1 == true && _isSocket2 == true)
        {
            _gun.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NudgePoint")
        {
            currentState = MoveState.Move;
            Destroy(_disappearingBoxCollider.gameObject);
            _attachTransform.gameObject.SetActive(true);
            Destroy(_2ndPipe.gameObject, 1.5f);
        }
    }
}
