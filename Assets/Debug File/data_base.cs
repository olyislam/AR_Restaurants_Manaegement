using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google;
using Firebase.Auth;
using System;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;


    public class data_base : MonoBehaviour
    {
        private User an_User = new User();

        #region connection
        void Start()
        {
            // Set up the Editor before calling into the realtime database.
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://sign-ebff6.firebaseio.com/");

            // Get the root reference location of the database.
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        }

        #endregion connection

        #region post_and_replace_total_obj
        private void post_and_replace(string name)
        {
            User n_user = new User();
            n_user.Username = "oly";
            n_user.Email = "olyislam17@gmail.com";


            string json = JsonUtility.ToJson(n_user);

            // reference.Child("users").Child(userId).SetRawJsonValueAsync(json);

            FirebaseDatabase.DefaultInstance.RootReference.Child(name).SetRawJsonValueAsync(json);
        }
        #endregion post_and_replace_total_obj

        #region replace_value_from_any_single_path

        void replace_value_from_this_path(string name)
        {
            User an_user = new User();
            an_user.Username = "oly";
            an_user.Email = "olyislam17@gmail.com";

            FirebaseDatabase.DefaultInstance.RootReference.Child(name).Child("email").SetValueAsync(name);
        }
        #endregion replace_value_from_any_single_path


        #region retrive_data


        void retrive_data_from_database(string name)
        {
            FirebaseDatabase.DefaultInstance.RootReference.Child(name)
            .GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                    Debug.Log("error from retrive");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    // Do something with snapshot...

                    retived_data_storeing_here(snapshot);

                }
            });

        }

        void retived_data_storeing_here(DataSnapshot snapshot)
        {
            
            Debug.Log("total child" + snapshot.ChildrenCount);

            string json = snapshot.GetRawJsonValue();
            an_User = JsonUtility.FromJson<User>(json);
            
            Debug.Log("<color=red>name : </color>" + an_User.Username);
            Debug.Log("<color=red> email : </color>" + an_User.Email );       
     
        }


        #endregion retrive_data
    }
