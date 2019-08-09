using UnityEngine;
using UnityEngine.UI;

namespace EasyFloatingText
{
    /// <summary>
    /// 对象类型 2D或者3D
    /// </summary>
    public enum ObjectType
    {
        Type3D,
        Type2D,
    }
    /// <inheritdoc />
    /// <summary>
    /// 漂浮文字，用于角色头部显示信息
    /// </summary>
    public class FloatingText : MonoBehaviour
    {
        private Text _text;
        private RectTransform _rect;
        private Vector2 _offsetPos = new Vector2(0, 30);
        private ObjectType _modelType = ObjectType.Type3D;
        public FloatingText()
        {
            Target = null;
            Camera = null;
        }

        private void Awake()
        {
            _text = GetComponent<Text>();
            _rect = GetComponent<RectTransform>();
        }

        private void Start()
        {
            _text.alignment = TextAnchor.MiddleCenter;
        }



        /// <summary>
        /// 设置漂浮文字
        /// </summary>
        public string TextValue
        {
            get { return _text.text; }
            set { _text.text = value; }
        }

        /// <summary>
        /// 设置偏移量
        /// </summary>
        public Vector2 OffsetPos
        {
            get { return _offsetPos; }
            set { _offsetPos = value; }
        }

        /// <summary>
        /// 设置跟随对象
        /// </summary>
        public Transform Target { get; set; }

        /// <summary>
        /// 设置相机
        /// </summary>
        public Camera Camera { get; set; }

        /// <summary>
        /// 模型类型：3D或者2D（挂载对应的2D/3D碰撞体）
        /// </summary>
        public ObjectType ModelType
        {
            get { return _modelType; }
            set { _modelType = value; }
        }

        private void Update()
        {
            if (Target == null || Camera == null) return;
            var worldToScreenPoint = RectTransformUtility.WorldToScreenPoint(Camera, CaculatePosition());
            var screenPos = worldToScreenPoint + OffsetPos;
            _rect.position = screenPos;
        }


        private Vector3 CaculatePosition()
        {
            Vector3 targetPosition;
            if (ModelType == ObjectType.Type3D)
            {
                var targetCollider = Target.GetComponent<Collider>();

                if (targetCollider != null)
                {
                    targetPosition = Target.GetComponent<Collider>().bounds.center +
                                     (((Vector3.up * Target.GetComponent<Collider>().bounds.size.y) * 0.5f));
                }
                else
                {
                    Debug.Log("Gameobject未找到Collider");
                    targetPosition = Target.position;
                }
            }
            else
            {
                var targetCollider = Target.GetComponent<Collider2D>();
                if (targetCollider != null)
                {
                    targetPosition = targetCollider.bounds.center +
                                     (((Vector3.up * targetCollider.bounds.size.y) * 0.5f));
                }
                else
                {
                    Debug.Log("Gameobject未找到Collider2D");
                    targetPosition = Target.position;
                }
            }
            return targetPosition;
        }
    }
}
