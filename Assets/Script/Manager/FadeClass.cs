using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FadeType
{
    In,
    Out,
}

public class FadeClass : MonoBehaviour
{
    Canvas m_canvas;
    CanvasScaler m_canvasScaler;
    Image m_fadeImage;

    [SerializeField] float m_fadeSpeed;
    float m_alfa;

    bool m_isFade = false;
    bool m_fadeEnd = false;
    public bool FadeEnd { get => m_fadeEnd; private set { m_fadeEnd = value; } }
    bool m_crrentFade = false;

    float m_r, m_g, m_b;

    FadeType m_fadeType;

    void Update()
    {
        if (!m_isFade) return;
        m_fadeImage.color = new Color(m_r, m_g, m_b, m_alfa);
        if (m_fadeType == FadeType.In)
        {
            m_alfa -= m_fadeSpeed;
            if (m_alfa < 0) m_fadeEnd = true;
        }
        else
        {
            m_alfa += m_fadeSpeed;
            if (m_alfa > 1) m_fadeEnd = true;
        }
    }

    public void SetCanvas(FadeType type)
    {
        if (m_crrentFade) return;
        else m_crrentFade = true;
        
        if (m_canvas == null) m_canvas = gameObject.AddComponent<Canvas>();
        m_canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        SetCanvasScaler();
        SetImage(type);

        m_fadeType = type;
        m_isFade = true;
    }

    void SetCanvasScaler()
    {
        if (m_canvasScaler == null) m_canvasScaler = gameObject.AddComponent<CanvasScaler>();

        m_canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        m_canvasScaler.referenceResolution = new Vector2(1600, 900);
    }

    void SetImage(FadeType type)
    {
        if (m_fadeImage == null) m_fadeImage = gameObject.AddComponent<Image>();

        if (type == FadeType.In) m_alfa = 1;
        else m_alfa = 0;

        m_fadeImage.color = Color.black;
        
        m_r = m_fadeImage.color.r;
        m_g = m_fadeImage.color.g;
        m_b = m_fadeImage.color.b;
    }
}
