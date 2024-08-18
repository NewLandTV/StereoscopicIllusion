using System;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Transform { get; private set; }

    [Serializable]
    public struct TransformData
    {
        [SerializeField]
        private Vector3 position;
        public Vector3 Position => position;
        [SerializeField]
        private Vector3 rotation;
        public Vector3 Rotation => rotation;
    }

    [SerializeField]
    private TransformData[] transformDatas;

    private void Awake()
    {
        Transform = GetComponent<Transform>();
    }

    private void Update()
    {
        for (int i = 1; i <= transformDatas.Length; i++)
        {
            if (!Input.GetKeyDown((KeyCode)(i + 48)))
            {
                continue;
            }

            TransformData data = transformDatas[i - 1];
            Vector3 position = data.Position;
            Quaternion rotation = Quaternion.Euler(data.Rotation);

            Transform.SetLocalPositionAndRotation(position, rotation);

            break;
        }
    }
}
