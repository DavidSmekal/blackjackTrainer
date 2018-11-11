using UnityEngine;

public class howToPlay : MonoBehaviour
{

    public GameObject modalWindow;
    public GameObject closeModal;

    public void Start()
    {
        modalWindow.SetActive(false);
    }
    public void viewCheatSheet()
    {
        // this shows the modal pop up
        modalWindow.SetActive(true);
    }

    public void closeCheatSheet()
    {
        modalWindow.SetActive(false);
    }
}
