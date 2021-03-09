using UnityEngine;
using UnityEngine.UI;

public class ScoreChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;
    public Text text;
    void Start()
    {
        text.text = score.ToString();
    }

    // Update is called once per frame
    public void ScoreGoal()
    {
        score++;
        text.text = score.ToString();
    }
}
