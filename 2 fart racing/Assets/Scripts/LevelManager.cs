using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int _coincount = 0;
    [SerializeField] private int _maxgasAmount = 10;
    [SerializeField] private int _currentgas = 10;
    [SerializeField] private bool _isGameActive = false;
    [SerializeField] private float _distanceTravelled = 0;
    [SerializeField] private Vector2 _startPos, _endPos;
    private float _distanceTraveled;

    public static LevelManager Instance;
    
    public GameObject PausePanel;
    public GameObject winnerP;
    public GameObject GameoverPanel;
    public Transform PlayerCar;
    public Slider Gass;
    public TextMeshProUGUI CoinCountText;
    public TextMeshProUGUI CurrentDistanceWon, CurrentDistanceLost;
    public TextMeshProUGUI BestDistanceWon, BestDistanceLost;
    public TextMeshProUGUI GasAmountText;
    public TextMeshProUGUI CountDown;
    private int _countdownTimer = 3;
    void Awake() 
    {
        Instance = this;
    }
    void Start()
    {
        _startPos = PlayerCar.position;
        Time.timeScale = 1;
        CoinCountText.text = _coincount.ToString();
        GasAmountText.text = _maxgasAmount.ToString();
        SetMaxGasMeter(_maxgasAmount);
        StartCoroutine(StartCountdownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public bool startgame()
    {
        //_isGameActive = true;
        return _isGameActive;
    }
    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameOver()
    {
        _endPos = PlayerCar.position;
        CalculateDistanceTraveled();
        GameManager.Instance.CoinCountupdate(_coincount);
        Time.timeScale = 0;
        GameoverPanel.SetActive(true);
    }
    public void winner()
    {
        _endPos = PlayerCar.position;
        CalculateDistanceTraveled();
        GameManager.Instance.CoinCountupdate(_coincount);
        Time.timeScale = 0;
        winnerP.SetActive(true);
    }
    public void Cum()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void home()
    {
        SceneManager.LoadScene(0);
    }
    public void NextScene()
    {
        int currentSceneIndex;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex +1);
    }
    public void CupComplete()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void CalculateDistanceTraveled()
    {
        float totalDistance = _endPos.y - _startPos.y;
        Debug.Log(totalDistance);
        GameManager.Instance.SetBestDist(totalDistance);
        float bestDistance = GameManager.Instance.GetBestDist();
        CurrentDistanceLost.text = ((int)totalDistance).ToString();
        CurrentDistanceWon.text = ((int)totalDistance).ToString();
        BestDistanceLost.text = ((int)bestDistance).ToString();
        BestDistanceWon.text = ((int)bestDistance).ToString();
    }
    public void play()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void SetMaxGasMeter(int amount) // slider value
    {
        Gass.maxValue = amount;
        Gass.value = amount;
    }
    public void SetGasFillAmount(int amount)
    {
        if(_currentgas < _maxgasAmount)
        {
            _currentgas += amount;
            Gass.value = _currentgas;
        }
    }
    public void UpdateGasAmount(int amount) // tech value
    {
        if(_currentgas < _maxgasAmount)
        {
        _maxgasAmount += amount;
        GasAmountText.text = _maxgasAmount.ToString();
        }
        
    }
    public void UpdateLevelCoinCount(int amount)
    {
        _coincount += amount;
        CoinCountText.text = _coincount.ToString();
    }
    public void StartGasMeter()
    {
        StartCoroutine(updateGasMeter());
    }
    IEnumerator StartCountdownTimer()
    {
        yield return new WaitForSeconds(0.25f);
        CountDown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        while( _countdownTimer > 0)
        {
            CountDown.text =  _countdownTimer.ToString();
            yield return new WaitForSeconds(1f);
            _countdownTimer--;//_countdownTimer = _cauntdownTimer - 1;
        }
        CountDown.text ="Run Bitch Ruuuunnn";
        _isGameActive = true;
        yield return new WaitForSeconds(1);
        CountDown.gameObject.SetActive(false);
    }
    IEnumerator updateGasMeter()
    {
        while(_currentgas > 0)
        {
            yield return new WaitForSeconds(3f);
            _currentgas--;
            GasAmountText.text = _currentgas.ToString();
            Gass.value = _currentgas;
        }
        GameOver();
    }
}
