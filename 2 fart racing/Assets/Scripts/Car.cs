using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _sidespeed = 5f;
    [SerializeField] private float _boostAmount = 20f;
    [SerializeField] private bool _crossedFinishLine = false;
    [SerializeField] private bool _Done;

    private float _borderwall = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool Done()
    {
        return _Done;
    }
    // Update is called once per frame
    void Update()
    {
        if(LevelManager.Instance.startgame())
        {
            carMovement();
        }
    }
    private void carMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * _sidespeed * Time.deltaTime *horizontalInput);

        if(transform.position.x > _borderwall)
        {
            transform.position = new Vector3(_borderwall, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -_borderwall)
        {
            transform.position = new Vector3(-_borderwall, transform.position.y, transform.position.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            LevelManager.Instance.GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("finish"))
        {
           _Done = true;
           LevelManager.Instance.winner();
        }
        if(other.gameObject.CompareTag("Start"))
        {
            LevelManager.Instance.StartGasMeter();
            Debug.Log("start gas meter");
        }
        if(other.gameObject.CompareTag("Boosh"))
        {
            StartCoroutine(SetBoost());
        }
    }

    IEnumerator SetBoost()
    {
        float currentSpeed = _moveSpeed;
        _moveSpeed = currentSpeed + _boostAmount;
        yield return new WaitForSeconds(3f);
        _moveSpeed = currentSpeed;
    }

}
