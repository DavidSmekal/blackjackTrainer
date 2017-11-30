using UnityEngine;

// this class handles changing the background to red or green
public class confirmationCardSwitch : MonoBehaviour
{


    // You cannot attach a sprite to a static field. Thus, if you go =
    // to a public method, you can bypass this.
    static SpriteRenderer spriteRenderer;

    public static Sprite statCorrect;
    public static Sprite statIncorrect;

    public Sprite correct;
    public Sprite incorrect;



    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        statCorrect = correct;
        statIncorrect = incorrect;
    }

    public static void changeCorrect()
    {

        spriteRenderer.sprite = statCorrect;

    }

    public static void changeIncorrect()
    {
        spriteRenderer.sprite = statIncorrect;
    }

}
