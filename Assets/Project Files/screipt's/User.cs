using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class User //this calss use for anuser object that object will stored to database 
{
    public string Username;
    public string Email;
    public string Password;
    public string ID;
    public Uri PhotoUrl;




    public User()
    {
        this.Username = null;
        this.Email = null;
        this.ID = null;
        this.PhotoUrl = null;
    }

    public User(Firebase.Auth.FirebaseUser FbaseUser, string password)
    {
        this.Password = password;
        this.ID = FbaseUser.UserId;
        this.Email = FbaseUser.Email;
        this.PhotoUrl = FbaseUser.PhotoUrl;
        this.Username = FbaseUser.DisplayName;
    }

}

