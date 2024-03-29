using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int currentGold;
    public Text goldText;
    [SerializeField]AudioSource goldCollectSound;

    // Start is called before the first frame update
    void Start()
    {
        goldText.text = "Score: " + currentGold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddGold(int goldToAdd)
    {
        currentGold += goldToAdd;
        goldText.text = "Score: " + currentGold;
        goldCollectSound.Play();
    }

}
