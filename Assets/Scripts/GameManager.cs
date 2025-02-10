using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] pins;

    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;


    private void Start()
    {
        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
    }

    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }

    private void SetPins()
    {
        if (pinCollection)
            foreach (Transform child in pinCollection.transform)
            {
                Destroy(child.gameObject);
            }

        Destroy(pinCollection);

        pinCollection = Instantiate(pinCollection, pinAnchor.transform.position, Quaternion.identity, transform);

        pins = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach(FallTrigger pin in pins)
            pin.OnPinFall.AddListener(IncrementScore);

    }



    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}
