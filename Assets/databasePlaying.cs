using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// everytime a user navigates to the home screen, it will add the date and time they entered.
// I'm doing this to see if users are actually playing my game or not.
public class databasePlaying : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        StartCoroutine(Upload());

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // this will update the user's score
    IEnumerator Upload()
    {

        WWWForm form = new WWWForm();

        form.AddField("username", PlayerPrefs.GetString("Username"));


        UnityWebRequest www = UnityWebRequest.Post("http://107.170.227.172/mainMenuDatabase.php", form);
        yield return www.Send();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            Debug.Log("ERROR CAN'T UPLOAD");

        }
        else

        {
            Debug.Log("Form upload complete!");


        }



    }

}
