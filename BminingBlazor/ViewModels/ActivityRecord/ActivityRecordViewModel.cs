﻿using System;
using System.Collections.Generic;

namespace BminingBlazor.ViewModels.ActivityRecord
{
    public class ActivityRecordViewModel
    {
        public int MyId { get; set; }
        public List<ActivityRecordMemberViewModel> OurMembers { get; set; }
        public List<ActivityRecordCommitmentViewModel> OurCommitments { get; set; }
        public string MySecurityReflection { get; set; }
        public string MyNotes { get; set; }
        public DateTime MyDate { get; set; }
        public double? MyDurationHours { get; set; }
        public string MyTitle { get; set; }
        public string MyPlace { get; set; }
        public string MyProjectName { get; set; }
        public string MyProjectCode { get; set; }
        public int MyProjectId { get; set; }

        public ActivityRecordViewModel()
        {
            OurMembers = new List<ActivityRecordMemberViewModel>();
            OurCommitments =new List<ActivityRecordCommitmentViewModel>();
        }
    }
}