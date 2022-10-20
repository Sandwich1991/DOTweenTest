using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MouseTracker : MonoBehaviour, IPointerClickHandler
{
    private Canvas _canvas;
    private Sequence _sequence;
    private RectTransform _canvasRect;
    private RectTransform _rect;
    private float _distance;
    private bool _isClicked = false;
    private Text _textComp;
    private float _timeSinceStart;

    private void Awake()
    {
        Intro.StepStart();
        
        _canvas = transform.parent.GetComponent<Canvas>();
        _canvasRect = _canvas.GetComponent<RectTransform>();
        _rect = GetComponent<RectTransform>();
        _textComp = GetComponent<Text>();
        _textComp.text = "클릭!";
        
        CanvasGroup cg = GetComponent<CanvasGroup>();

        _sequence = DOTween.Sequence()
            .AppendCallback(() => cg.alpha = 0)
            .AppendInterval(0.5f)
            .AppendCallback(() => cg.DOFade(1, 1));
    }

    private void Update()
    {
        CheckTimeAndChangeText();
        CheckDistanceBetweenMouse();
    }

    void CheckTimeAndChangeText()
    {
        if (_isClicked)
        {
            return;
        }
        
        _timeSinceStart += Time.unscaledDeltaTime;

        if (_timeSinceStart >= 3f)
        {
            _textComp.text = "잡아야지?";
        }

        if (_timeSinceStart >= 5f)
        {
            _textComp.text = "못잡겠지??";
        }

        if (_timeSinceStart >= 8f)
        {
            _textComp.text = "한심하지???";
        }
    }

    void CheckDistanceBetweenMouse()
    {
        _distance = (transform.position - Input.mousePosition).magnitude;

        bool isClose = _distance <= 500;

        if (isClose && !_isClicked)
        {
            Dodge();
        }
    }

    void Dodge()
    {
        float xPos = GetXpos();
        float yPos = GetYpos();

        _rect.DOAnchorPos(new Vector2(xPos, yPos), 0.1f);
    }

    float GetXpos()
    {
        Vector2 myPos = _rect.anchoredPosition;
        
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        float xPos = myPos.x;

        if (myPos.x <= mousePos.x)
        {
            xPos -= 50;
            
            if (xPos <= 100)
            {
                xPos = Random.Range(_canvasRect.rect.width / 2, _canvasRect.rect.width - 100);
            }
        }
        else
        {
            xPos += 50;

            if (xPos >=  _canvasRect.rect.width - 100)
            {
                xPos = Random.Range(100, _canvasRect.rect.center.x);
            }
        }

        return xPos;
    }
    
    float GetYpos()
    {
        Vector2 myPos = _rect.anchoredPosition;
        
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        float yPos = myPos.y;

        if (myPos.y <= mousePos.y)
        {
            yPos -= 50;
            
            if (yPos <= 100)
            {
                yPos = Random.Range(_canvasRect.rect.center.y, _canvasRect.rect.height - 100);
            }
        }
        else
        {
            yPos += 50;

            if (yPos >=  _canvasRect.rect.height - 100)
            {
                yPos = Random.Range(100, _canvasRect.rect.center.y);
            }
        }

        return yPos;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _isClicked = true;
        _textComp.DOText("Congratulations!", 1f)
            .OnComplete(() =>
            {
                GetComponent<CanvasGroup>().DOFade(0, 1f)
                    .OnComplete(() =>
                    {
                        Destroy(gameObject);
                        Intro.StepEnd();
                    });
            });
        
    }
}
