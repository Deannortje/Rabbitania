﻿using System;
using System.Collections.Generic;

namespace backend_api.User.Models.Responses
{
    public class GetUserResponse
    {
        private String response { get; set; }
        private String firstname { get; set; }
        private String lastname { get; set; }
        
        private List<int> pinnedIDs { get; set; }
        private int userID { get; set; }
        private int phoneNumber { get; set; }
        private String userImage { get; set; }
        private String description { get; set; }
        // public bool isOnline { get; set; }
        private bool isAdmin { get; set; }
        private int empLevel { get; set; }
        private int UserRole { get; set; }
        private int OfficeLocation { get; set; }
        
        private User.User user;
        public GetUserResponse(String resp)
        {
            this.response = resp;
        }

        public GetUserResponse(User.User user, String firstname, String lastname, int emplvl, bool isadmin, String desc, int userid, int number, int role, String image, int office, List<int> pinnedids)
        {
            this.description = desc;
            this.UserRole = role;
            this.firstname = firstname;
            this.lastname = lastname;
            this.empLevel = emplvl;
            this.isAdmin = isadmin;
            this.userID = userid;
            this.phoneNumber = number;
            this.userImage = image;
            this.OfficeLocation = office;
            for (int i = 0; i < pinnedids.Count; i++)
                this.pinnedIDs[i] = pinnedids[i];
            
            this.user = user;

        }
    }
}