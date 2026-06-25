using UnityEngine;

public class DissolveDriver : MonoBehaviour
{
    public Renderer targetRenderer;
    public string propertyName = "_DissolveAmount";

    private int propertyId;

    public float duration = 1.5f;
    public bool pingPong = true;

    private float elpased;

    private MaterialPropertyBlock block;

    private void Awake()
    {
        propertyId = Shader.PropertyToID(propertyName);
        block = new MaterialPropertyBlock();
    }

    private void Update()
    {
        elpased += Time.deltaTime;
        float amount = pingPong ? Mathf.PingPong(elpased / duration, 1f) : Mathf.Clamp01(elpased / duration);
        targetRenderer.GetPropertyBlock(block);
        block.SetFloat(propertyId, amount);
        targetRenderer.SetPropertyBlock(block);
    }
}
