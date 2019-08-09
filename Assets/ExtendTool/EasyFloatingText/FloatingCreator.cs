using UnityEngine;
using UnityEngine.UI;

namespace EasyFloatingText
{
    /// <summary>
    /// 漂浮文字创建器
    /// </summary>
    public class FloatingCreator
    {
        public GameObject Create()
        {
            GameObject root = null;
            var canvasRoot = GameObject.Find("FloatingText");
            if (canvasRoot == null)
            {
                root = new GameObject("FloatingText");
                var canvas = root.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                var scaler = root.AddComponent<CanvasScaler>();
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                scaler.referenceResolution = new Vector2(1280, 720);
                scaler.matchWidthOrHeight = 1;
                root.AddComponent<GraphicRaycaster>();
            }
            else
                root = canvasRoot;
            var res = new DefaultControls.Resources();
            var text = DefaultControls.CreateText(res);
            text.transform.SetParent(root.transform);
            text.transform.localPosition = Vector3.zero;
            text.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 50);
            text.AddComponent<FloatingText>();
            text.GetComponent<Text>().fontSize = 30;
            return text;
        }
    }
}
