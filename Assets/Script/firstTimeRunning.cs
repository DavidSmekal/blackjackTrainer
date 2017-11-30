using UnityEngine;
using UnityEngine.SceneManagement;

public class firstTimeRunning : MonoBehaviour {

    public GameObject tutorialPopup;

	void Start () {

       int firstPlay = PlayerPrefs.GetInt("FirstPlay");

        if (firstPlay == 0)
        {
            tutorialPopup.SetActive(true);

            PlayerPrefs.SetInt("FirstPlay", 1);
        
        }
        else
        {
            tutorialPopup.SetActive(false);
        }
        

	}
	

	

    public void yes()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void no()
    {
        tutorialPopup.SetActive(false);
    }
}
