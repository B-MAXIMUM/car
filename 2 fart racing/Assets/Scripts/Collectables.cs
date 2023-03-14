using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private int _value = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
     if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("I was hit by player");
       
            if(this.gameObject.CompareTag("Coin"))
            {
             LevelManager.Instance.UpdateLevelCoinCount(_value);
            }

            if(this.gameObject.CompareTag("Gas Can"))
            {
                LevelManager.Instance.UpdateGasAmount(_value);
                LevelManager.Instance.SetGasFillAmount(_value);
            }
            Destroy(this.gameObject);
        }

    }

}
