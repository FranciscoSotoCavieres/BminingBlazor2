using Models.TimeTracking;
using System;
using System.Collections.Generic;

namespace BminingBlazor.Services
{
    public interface ITimeTrackingService
    {
        void AddUserTimeTracking(int userId, int projectId, DateTime timeTrackingDate, double trackedHours);
        List<TimeTrackingModel> GetUserTrackingModel(int userId, DateTime from, DateTime to);
        void RejectCargaDeHoras();
        void ApproveCargaDeHoras();
        void GetUserCargaDeHoras();
    }
}