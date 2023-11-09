﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using src.Web.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Web.Common.Models.UserViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email is required XXX")]
        //[Remote(action: "CheckUserOnAD", controller: "Users")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "FirstName is required XXX")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }

        [Display(Name = "Last Login Date")]
        [DataType(DataType.Date)]
        [JsonConverter(typeof(JsonDateConverter))]
        public DateTime LastLoginDate { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        [Display(Name = "Last Updated Date")]
        public DateTime ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        [Display(Name = "Authorized Roles")]
        public string AuthorizedRoleNames { get; set; }

        public IList<int> AuthorizedRoleIds { get; set; }

        public IList<int> SelectedRoleIds { get; set; }
        [Required]
        public IList<SelectListItem> AvailableRoles { get; set; }

        public UserViewModel()
        {
            SelectedRoleIds = new List<int>();
            AvailableRoles = new List<SelectListItem>();
        }
    }
}
