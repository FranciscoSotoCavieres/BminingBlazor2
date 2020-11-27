﻿using BminingBlazor.ViewModels.Projects;
using BminingBlazor.ViewModels.User;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BminingBlazor.Services
{
    public interface IProjectDataService
    {
        Task<int> CreateProject(ProyectoModel proyecto);
        Task AddMember(IntegranteModel integrante);
        Task<List<TipoProyectoModel>> ReadProjectType();
        Task<List<TipoEstadoPagoModel>> ReadPaymentStatusType();
        Task AddPaymentStatus(EstadoPagoModel estadopago);
        Task<int> AddProjectCreator(ProyectoModel proyecto);
        Task<int> AddJefeProyecto(ProyectoModel proyecto);
        Task<int> AddCliente(ProyectoModel proyecto);
        Task<List<ViewProyectoModel>> ReadProjects();
        Task<int> ReadProjectManagerId(int id_proyecto);
        Task<List<MemberProjectEditModel>> ReadMembers(int idProject);
        Task<int> EditPaymentStatus(EstadoPagoModel estadopago);
        Task DeleteMember(int memberId);
        Task DeleteProyecto(int id_proyecto);
        Task<int> CreateCliente(ClienteModel cliente);
        Task<List<ClienteModel>> ReadCliente();
        Task<List<ViewProyectoModel>> ReadProjectsOwnedByUser(int userId);
        Task<List<StatusProjectModel>> GetAvailableProjectStatus();
    }


    public interface IFranciscoProjectDataService
    {
        Task<List<ProjectViewModel>> ReadProjectsOwnedByUser(int userId);
        Task<List<UserViewModel>> GetMembersByProject(int projectId);
    }

}