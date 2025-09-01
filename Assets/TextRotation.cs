using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class TextRotation : MonoBehaviour
{
  TextMeshPro m_textMeshPro;
  Transform m_transform;

    void Awake()
    {
        m_textMeshPro = GetComponent<TextMeshPro>();
        m_transform = GetComponent<Transform>();
    }

    void Update()
    {
        rotate();
    }
    void rotate()
    {
        float fixRotation = -transform.rotation.y;
        m_textMeshPro.rectTransform.rotation = Quaternion.Euler( 90f, fixRotation, 0f);
    }
}
