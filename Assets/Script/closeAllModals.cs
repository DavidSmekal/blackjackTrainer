using UnityEngine;

public class closeAllModals : MonoBehaviour {

    // this script will close every modal after I attach a button to it
    // this is the only programming here. the rest I need to set up in the unity inspect for each modal
    public GameObject modalWindow;

    public void closeModal()
    {
        modalWindow.SetActive(false);
    }
}
