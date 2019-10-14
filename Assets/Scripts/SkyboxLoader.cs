using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TheGamedevGuru
{
    public class SkyboxLoader : MonoBehaviour
    {
        [SerializeField] private List<AssetReference> _skyboxMaterials = null;
        
        IEnumerator Start()
        {
            var wait = new WaitForSeconds(3f);
            var currentIndex = 0;
            while (true)
            {
                var opHandle = _skyboxMaterials[currentIndex++ % _skyboxMaterials.Count].LoadAssetAsync<Material>();
                yield return opHandle;
                RenderSettings.skybox = opHandle.Result;
                yield return wait;
            }
        }
    }
}
