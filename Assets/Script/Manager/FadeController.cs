using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    private Canvas m_canvas;
    private Image m_image;

    private bool isOut = false;
    public bool isScene = false;

    private float time = 0;
    private float fadeTime = 1.0f;

    void Update()
    {
        if (isOut)
        {
            time += Time.deltaTime / fadeTime;

            if (time >= 1.0f)
            {
                time = 1.0f;
                isOut = false;
                isScene = true;
                Debug.Log("終了");
            }

            m_image.color = new Color(0, 0, 0, time);
        }
    }

    public void FadeOut()
    {
        if (m_image == null) CreateFadeObject();
        m_image.color = Color.black;
        m_canvas.enabled = true;
        isOut = true;
    }

    /// <summary>
    /// フェードアウトさせるためのゲームオブジェクトの生成
    /// </summary>
    void CreateFadeObject()
    {
        //CreateCanvas
        GameObject fadeObject = new GameObject("Fide");
        m_canvas = fadeObject.AddComponent<Canvas>();
        fadeObject.AddComponent<GraphicRaycaster>();
        fadeObject.AddComponent<GameManager>();
        m_canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        m_canvas.sortingOrder = 100;

        //CreateImage
        m_image = new GameObject("image").AddComponent<Image>();
        m_image.transform.SetParent(m_canvas.transform, false);
        m_image.rectTransform.anchoredPosition = Vector3.zero;
        m_image.rectTransform.sizeDelta = new Vector2(999, 999);
    }
}
