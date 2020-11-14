using Models.TimeTracking;
using System;
using System.Collections.Generic;

namespace BminingBlazor.Services
{
    public class TimeTrackingService : ITimeTrackingService
    {
        public TimeTrackingService()
        {
        }

        public void AddUserTimeTracking(int userId, int projectId, DateTime timeTrackingDate, double trackedHours)
        {
            var trackingHourModel = new TimeTrackingModel
            {
                CreationDate = DateTime.UtcNow,
                ProjectId = projectId,
                TimeTrackingDate = timeTrackingDate,
                TimeTrackingStatus = TimeTrackingStatus.WaitingForApproval,
                TrackedHours = trackedHours,
                UserId = userId
            };
        }
        public List<TimeTrackingModel> GetUserTrackingModel(int userId, DateTime from, DateTime to)
        {
            return new List<TimeTrackingModel>();
        }

        public void RejectCargaDeHoras()
        {
            throw new System.NotImplementedException();
        }

        public void ApproveCargaDeHoras()
        {
            throw new System.NotImplementedException();
        }

        public void GetUserCargaDeHoras()
        {
            throw new System.NotImplementedException();
        }
    }
}