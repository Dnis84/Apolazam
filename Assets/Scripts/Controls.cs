using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Controls : MonoBehaviour
{
    [Header("Sliders")]
    [Tooltip("All ordered slides")]
    public GameObject[] allSlides;
    // Para el cambio de Slide
    [SerializeField]
    private int _currentSlideIndex = 0;
    private int currentSlideIndex
    {
        get { return _currentSlideIndex; }
        set
        {
            int _lastIndex = _currentSlideIndex;
            _currentSlideIndex = value;
            OnSlideChange(_lastIndex);
        }
    }
    [Header("Contents UI")]
    public GameObject Logo;
    public GameObject Controls_Panel;

    [Header("Controls UI")]
    public Button btnInicio;
    public Button btnPrevius;
    public Button btnHome;
    public Button btnNext;

    private void Awake()
    {
        btnInicio.onClick.AddListener(NextSlide);
        btnPrevius.onClick.AddListener(PrevSlide);
        btnHome.onClick.AddListener(GoHome);
        btnNext.onClick.AddListener(NextSlide);
    }

    private void Start()
    {
        currentSlideIndex = 0;
        Controls_Panel.SetActive(false);
    }

    private void OnDestroy()
    {
        btnInicio.onClick.RemoveListener(NextSlide);
        btnPrevius.onClick.RemoveListener(PrevSlide);
        btnHome.onClick.RemoveListener(GoHome);
        btnNext.onClick.RemoveListener(NextSlide);
    }

    void PrevSlide()
    {
        currentSlideIndex--;
    }

    void GoHome()
    {
        currentSlideIndex = 0;
    }
    void NextSlide()
    {
        currentSlideIndex++;
    }

    void OnSlideChange(int lastSelected)
    {
        allSlides[lastSelected].SetActive(false);

        Controls_Panel.SetActive(currentSlideIndex != 0); // Activate controls panel only if isnt the home Slide (0)

        if (currentSlideIndex == 1) // No Prev button
        {
            btnPrevius.gameObject.SetActive(false);
        }

        if (currentSlideIndex > 1 && currentSlideIndex < allSlides.Length - 1)
        {
            btnPrevius.gameObject.SetActive(true);
            btnNext.gameObject.SetActive(true);
        }

        if (currentSlideIndex == allSlides.Length - 1)
        {
            btnNext.gameObject.SetActive(false);
            Logo.gameObject.SetActive(false);
        }
        else
        {
            Logo.gameObject.SetActive(true);
            btnNext.gameObject.SetActive(true);
        }

        allSlides[currentSlideIndex].SetActive(true);
    }


}
