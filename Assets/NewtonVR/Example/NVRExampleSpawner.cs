using UnityEngine;
using System.Collections;
using NewtonVR;
using UnityEngine.Events;

namespace NewtonVR.Example
{
    public class NVRExampleSpawner : MonoBehaviour
    {
        public NVRButton Button;

        public GameObject ToCopy;

        public UnityEvent OnButtonPressed;

        private void Update()
        {
            if (Button.ButtonDown)
            {
                GameObject newGo = GameObject.Instantiate(ToCopy);
                newGo.transform.position = this.transform.position + new Vector3(0, 1, 0);
                newGo.transform.localScale = ToCopy.transform.lossyScale;
                OnButtonPressed.Invoke();
            }
        }
    }
}