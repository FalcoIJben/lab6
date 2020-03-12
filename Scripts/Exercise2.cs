using UnityEngine;

namespace Lab6.Scripts
{
    public class Exercise2 : MonoBehaviour
    {
	int iterations;
        int bailout = 2;
        int bottom = -1;
        float left = -2.5f;
        float right = 1;
        int top = 1;
	[SerializeField] private ComputeShader computeShader;
        [SerializeField] private RenderTexture renderTexture;
        [SerializeField] private Texture2D texture;

        private void Start()
        {
            renderTexture.enableRandomWrite = true;
            renderTexture.Create();
            
            var kernelIndex = computeShader.FindKernel("CSMain");
            
	    iterations = 100;
            bailout = 2;
            bottom = -1;
            left = -2.5f;
            right = 1;
            top = 1; 
            
            computeShader.SetTexture(kernelIndex, "_ColorGradient", texture);
            computeShader.SetTexture(kernelIndex, "_MandelbrotSet", renderTexture);
            computeShader.Dispatch(kernelIndex, renderTexture.width / 8, renderTexture.height / 8, 1);
        }

        private void OnDestroy()
        {
            renderTexture.Release();
        }

        private void Reset()
        {
            iterations = 100;
            bailout = 2;
            bottom = -1;
            left = -2.5f;
            right = 1;
            top = 1;
            computeShader = null;
            renderTexture = null;
            texture = null;
        }
    }
}
