using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int _CoinCount = 0;
    public static GameManager Instance;
    [SerializeField] private float _bestDist = 0;
    public void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void raceistbutton()
    {
        SceneManager.LoadScene("Gamemode select");
    }
    public void CoinCountupdate(int amount)
    {
        _CoinCount += amount;
    }
    public int GetCoinCount()
    {
        return _CoinCount;
    }
    public void SetBestDist(float amount)
    {
        if(_bestDist < amount)
        {
            _bestDist = amount;
        }
    }
    public float GetBestDist()
    {
        return _bestDist;
    }
}
