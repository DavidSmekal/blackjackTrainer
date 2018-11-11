using UnityEngine;

public class Cards : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    public Sprite[] cardFront;
    public Sprite cardBack;
    public Sprite cardBack2;
    public Sprite cardBack3;
    public Sprite cardBack4;
    public Sprite cardBack5;
    public Sprite cardBack6;


    public int cardIndex;


    public void showFace()
    {

        spriteRenderer.sprite = cardFront[cardIndex];

    }

    //this method could change the sprites. for example, i could have if something = 1, change it to cardback2, etc.
    public void showBack(string x)
    {
        if (x == "Red")
        {
            spriteRenderer.sprite = cardBack;
        }
        if (x == "Green")
        {
            spriteRenderer.sprite = cardBack2;
        }
        if (x == "Blue")
        {
            spriteRenderer.sprite = cardBack3;
        }
        if (x == "Brick")
        {
            spriteRenderer.sprite = cardBack4;
        }
        if (x == "Grass")
        {
            spriteRenderer.sprite = cardBack5;
        }
        if (x == "Sky")
        {
            spriteRenderer.sprite = cardBack6;
        }
    }



    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //if the playerpreference is empty, we need to set the default skin to red
        if (!(PlayerPrefs.HasKey("Skin")))
        {
            spriteRenderer.sprite = cardBack;
        }

    }

}
