﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DarboOrganizavimoPlatforma.Domains
{
    public class Assignment
    {
        public Guid AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public string AssignmentDescription { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime CompletedTime { get; set; }
        public CompletionStatus AssingmentStatus { get; set; }
        public ICollection<UserAssingment> UsersAssigned { get; set; }
        public Team Team { get; set; }
        public Guid TeamId { get; set; }
        public List<ATask> AssingmentTasks { get; set; }
    }
}