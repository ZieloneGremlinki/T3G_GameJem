using TMPro;
using UnityEngine;

namespace GreenGremlins
{
    public class VersionMenu : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<TMP_Text>().text = $"Version {Application.version}";
        }
    }
}
