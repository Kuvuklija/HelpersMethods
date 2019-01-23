﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HelpersMethods.Models{

    public class Person{
        //[HiddenInput(DisplayValue =true)]
        [ScaffoldColumn(false)]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address HomeAdress { get; set; }
        public bool IsApproved { get; set; }
        public Role Role { get; set; }
    }

    public class Address {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public enum Role {
        Admin,
        User,
        Guest
    }
}