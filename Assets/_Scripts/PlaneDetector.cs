using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaneDetector : MonoBehaviour
{
    [SerializeField] private GameObject _question;
    [SerializeField] private TMP_Text _questionText;
    [SerializeField] private TMP_Text _answer_1;
    [SerializeField] private TMP_Text _answer_2;

    [SerializeField] private string[] _questions;

    [SerializeField] private GameObject _correct;
    [SerializeField] private GameObject _wrong;
    [SerializeField] private GameObject _portal;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameLevelCounter _gameLevelCounter;

    private List<string> _aArticle = new List<string>
    {
    "Wolf", "Pen", "Child", "Spoon", "Plate", "Mouse", "Ruler", "Teacher", "Boy", "Pencil", "Cherry", "Bus",
    "Dog", "Car", "Bike", "Tree", "House", "Cat", "Girl", "Book", "Chair", "Lamp", "Desk", "Table", "Phone", "Guitar", "Shirt",
    "Cup", "Ball", "Fan", "Game", "Fish", "Bird", "Song", "Leaf", "Bottle", "Shoe", "Computer", "Notebook", "Bag", "Hat", "Carpet",
    "Map", "Road", "Window", "Closet", "Plant", "Picture", "Mirror", "Candle", "Wall", "Brush", "Ring", "Watch",
    "Toy", "Box", "Clock", "Couch", "Fork", "Knife", "Letter", "Folder", "Magazine", "Newspaper", "Poster", "Backpack", "Cake",
    "Statue", "Tower", "Bridge", "Mountain", "River", "Forest", "Valley", "Shore", "Garden", "Ship", "Boat", "Plane", "Train",
    "Rocket", "Spacecraft", "Bike", "Motorcycle", "Helicopter", "Submarine", "Taxi", "Bus", "Truck", "Pillow", "Painter", "Manager",
    "Student", "Principal", "Piano", "Violin", "Cabinet", "Globe", "Drawer", "Calendar", "Carpet", "Ladder", "Hammer", "Nail",
    "Screw", "Drill", "Saw", "Shovel", "Wrench", "Pliers", "Basket"
    };

    private List<string> _anArticle = new List<string>
    {
    "Apple", "Hour", "Orange", "Elephant", "Umbrella", "Eye", "Airplane", "Onion", "Armchair", "Igloo", "Insect", "Owl", "Iceberg",
    "Island", "Engine", "Iron", "Octopus", "Ice cream", "Idea", "Author", "Eagle", "Eraser", "Envelope", "Ankle", "Illustration",
    "Instrument", "Image", "Instinct", "Ostrich", "Agency", "Exam", "Exile", "Amulet", "Artist", "Invitation", "Event", "Empire",
    "Apartment", "Armor", "Introduction", "Article", "Instance", "Experience", "Adventure", "Operation", "Advantage", "Invention",
    "Option", "Organization", "Obstacle", "Affair", "Exhibition", "Animal", "Outline", "Operation", "Opinion", "Attitude", "Illusion",
    "Occupation", "Output", "Activity", "Incident", "Excuse", "Experiment", "Ambition", "Investment", "Occasion", "Outcome", "Analysis",
    "Impact", "Alternative", "Appetite", "Attempt", "Effort", "Explanation", "Application", "Agenda", "Entertainment", "Understanding",
    "Observation", "Entity", "Anxiety", "Affection", "Obstacle", "Area", "Issue", "Application", "Arrangement", "Ambition", "Uncle",
    "Army", "Answer", "Event", "Offer", "Advantage", "Arrangement", "Opportunity", "Outfit", "Accent", "Obligation", "Issue"
    };


    [SerializeField] private GameObject[] _hearts;
    private int _heartIndex = 0;

    private void Start()
    {
        NewQuestion();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text == "A")
        {
            if (_aArticle.Contains(_questionText.text))
            {
                StartCoroutine(ShowCorrect());
            }
            else
            {
                MinusHeart();
                StartCoroutine(ShowWrong());
            }

            NewQuestion();
        }
        else if (collision.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text == "An")
        {
            if (_anArticle.Contains(_questionText.text))
            {
                StartCoroutine(ShowCorrect());
            }
            else
            {
                MinusHeart();
                StartCoroutine(ShowWrong());
            }

            NewQuestion();
        }
    }

    private void NewQuestion()
    {
        _question.transform.position = new Vector2(12, 0);
        int questionIndex = Random.Range(0, _questions.Length);
        _questionText.text = _questions[questionIndex];

        int answerIndex = Random.Range(0, 2);
        if (answerIndex == 0)
        {
            _answer_1.text = "A";
            _answer_2.text = "An";
        }
        else
        {
            _answer_1.text = "An";
            _answer_2.text = "A";
        }
    }

    private IEnumerator ShowCorrect()
    {
        _gameLevelCounter.IncreaseScore();

        _correct.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        _correct.SetActive(true);
        float aColor = 1f;
        yield return new WaitForSeconds(0.5f);
        while (_correct.GetComponent<Image>().color.a > 0)
        {
            _correct.GetComponent<Image>().color = new Color(1, 1, 1, aColor -= 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        _correct.SetActive(false);
    }

    private IEnumerator ShowWrong()
    {
        _wrong.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        _wrong.SetActive(true);
        float aColor = 1f;
        yield return new WaitForSeconds(0.5f);
        while (_wrong.GetComponent<Image>().color.a > 0)
        {
            _wrong.GetComponent<Image>().color = new Color(1, 1, 1, aColor -= 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        _wrong.SetActive(false);
    }

    private void MinusHeart()
    {
        _hearts[_heartIndex].SetActive(false);
        _heartIndex++;

        if (_heartIndex == 3)
        {
            StartCoroutine(GameOverBehavior());
        }
    }

    private IEnumerator GameOverBehavior()
    {
        GameObject portal = Instantiate(_portal);
        portal.transform.position = new Vector3(0, -5, 0);
        QuestionMovement.QuestionSpeed = 0;
        yield return new WaitForSeconds(2.5f);
        Destroy(portal);
        _gameOver.SetActive(true);
        Time.timeScale = 0;
    }
}