using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace BlackMoonServers {
    namespace SendRequests
    {
        public class SendRequests
        {
            private string basepingurl = "";
            private string username;
            private string salt = "";
            public void TestConnection()
            {

            }
            IEnumerator TestConnectionCoroutine()
            {

                yield return new WaitForSeconds(2f);

                //Create Form
                WWWForm form = new WWWForm();
                form.AddField("username", username);
                form.AddField("salt", salt);
                UnityWebRequest uwr = UnityWebRequest.Post(basepingurl, form);
                //Send Request
                yield return uwr.SendWebRequest();

                if (uwr.isNetworkError)
                {
                    Debug.Log("Error While Sending: " + uwr.error);
                    Debug.Log("User is offline or server is down");

                }
                else
                {
                    Debug.Log("Received: " + uwr.downloadHandler.text);
                    if (uwr.downloadHandler.text == "0")
                    {


                        Debug.Log("User is Registered go to Menu");


                    }
                    else if (uwr.downloadHandler.text == "1")
                    {


                        Debug.Log("Username or Password is Wrong");


                    }
                }
            }
        }
    }
}
