using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer _meshrender;
    public float animationspeed = 1f;

    private void Awake()
    {
        _meshrender = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        _meshrender.material.mainTextureOffset += new Vector2(animationspeed * Time.deltaTime, 0);
    }
}
