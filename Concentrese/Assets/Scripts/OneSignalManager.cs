using System.Collections;
using System.Collections.Generic; // Esta es la libreria que requiere.
using UnityEngine;

public class OneSignalManager : MonoBehaviour
{
	void Start ()
    {
        OneSignal.StartInit("827ddd42-331d-4981-a0cb-e5163d7a16e7").HandleNotificationOpened(HandleNotificationOpened).EndInit();
	}

    private static void HandleNotificationOpened(OSNotificationOpenedResult result) { }
	
}
