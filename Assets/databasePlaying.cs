using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Everytime a user navigates to the home screen, it will add the date and time they entered.
// I'm doing this to see if users are actually playing my game or not.
// It will create a unique hash for each user and save it into playerprefs, which will be the unique identifer.
public class databasePlaying : MonoBehaviour {

    string uniqueSystemIde;

    // Use this for initialization
    void Start () {

        uniqueSystemIde = PlayerPrefs.GetString("uniqueId");

        if (uniqueSystemIde == null)
        {

            // this creates a random string that looks like
            // QhduAHneI. This will be the unique identifier
            Guid newGuid = Guid.NewGuid();
            uniqueSystemIde = Convert.ToBase64String(newGuid.ToByteArray());
            uniqueSystemIde = uniqueSystemIde.Replace("=", "");
            uniqueSystemIde = uniqueSystemIde.Replace("+", "");
      

            PlayerPrefs.SetString("uniqueId", uniqueSystemIde);
        }


        StartCoroutine(Upload());

    }
	

    // this will update the user's score
    IEnumerator Upload()
    {

        WWWForm form = new WWWForm();

        form.AddField("username", PlayerPrefs.GetString("Username"));
        form.AddField("deviceId", uniqueSystemIde);


        UnityWebRequest www = UnityWebRequest.Post("http://107.170.227.172/mainMenuDatabase.php", form);
        yield return www.SendWebRequest();

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
