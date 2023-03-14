using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update [SerializeField] private int _CoinCount = 0;
    public TextMeshProUGUI CoincountText;
   
    void Start()
    {
        if(GameObject.Find("moneyyyyyyyyyyyyyyyyy") != null)
        {
            CoincountText.text = GameManager.Instance.GetCoinCount().ToString();
        }
        else 
        {
            Debug.Log("FUCK");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void raceistbutton()
    {
        SceneManager.LoadScene("Gamemode select");
    }
    public void SingleRaceistButton()
    {
        SceneManager.LoadScene("Sement");
    }
    public void CupRaceButt()
    {
        SceneManager.LoadScene("Cource 1");
    }
    public void backhome()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

