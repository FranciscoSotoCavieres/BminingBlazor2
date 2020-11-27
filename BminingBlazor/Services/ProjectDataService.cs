﻿using Data;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using BminingBlazor.ViewModels.Project;
using Data;
using Microsoft.Extensions.Configuration;
using Models;
using ProjectModel = Models.ProjectModel;
>>>>>>> master

namespace BminingBlazor.Services
{
    public class ProjectDataService : IProjectDataService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IConfiguration _configuration;
        public ProjectDataService(IDataAccess dataAccess, IConfiguration configuration)
        {
            _dataAccess = dataAccess;
            _configuration = configuration;
        }
        public async Task<int> CreateProject(ViewModels.Project.CreateProjectViewModel project)
        {

            if (project.Id_Proyecto > 0)
            {
                var sql =
                    "insert into Integrantes_Proyecto (Integrantes_Proyecto.Id_Usuario,Integrantes_Proyecto.Id_Proyecto,Integrantes_Proyecto.Project_Hours) " +
                    " Values (@Id_Usuario,@Id_Proyecto,@HoursProject)";
                await _dataAccess.SaveData(sql, project, _configuration.GetConnectionString("default"));
                return project.Id_Proyecto;
            }
            else
            {
                var sql =
                    "insert into Proyecto (Proyecto.Cod_Proyecto,Proyecto.Nombre_Proyecto,Proyecto.Cod_TipoProyecto,Proyecto.Fecha_Inicio,Proyecto.Fecha_Fin,Proyecto.Id_Creador,Proyecto.Id_JefeProyecto,Proyecto.Id_Cliente,Proyecto.Id_Status)" +
                    " Values (@Cod_Proyecto,@Nombre_Proyecto,@Cod_TipoProyecto,@Fecha_Inicio,@Fecha_Fin,@Id_Creador,@Id_JefeProyecto,@Id_Cliente,@Id_Status)";
                await _dataAccess.SaveData(sql, project, _configuration.GetConnectionString("default"));

                sql =
                    "select Proyecto.Id_Proyecto " +
                    $"from {TableConstants.TablaProyecto} " +
                    $"  where Proyecto.Cod_Proyecto = '{project.Cod_Proyecto}';";

                var items = await _dataAccess.LoadData<ProjectModel, dynamic>(sql, new { },
                    _configuration.GetConnectionString("default"));

                return items.First().Id_proyecto;
            }

        }
        //TODO Insertar metodos add en create project
        public async Task<int> AddProjectCreator(ProjectModel createProjectView)
        {
            var sql =
                "Update Proyecto" +
                " set Proyecto.Id_Creador=@Id_Creador" +
                " where Proyecto.Id_Proyecto=@Id_proyecto ";
            await _dataAccess.UpdateData(sql, createProjectView, _configuration.GetConnectionString("default"));



            return 0;

        }
        //TODO Insertar metodos add en create project
        public async Task<int> AddJefeProyecto(ProjectModel createProjectView)
        {
            var sql =
                "Update Proyecto" +
                " set Proyecto.Id_JefeProyecto=@Id_JefeProyecto" +
                " where Proyecto.Id_Proyecto=@Id_proyecto ";
            await _dataAccess.UpdateData(sql, createProjectView, _configuration.GetConnectionString("default"));



            return 0;

        }
        //TODO Insertar metodos add en create project
        public async Task<int> AddCliente(ProjectModel createProjectView)
        {
            var sql =
                "Update Proyecto" +
                " set Proyecto.Id_Cliente=@Id_Cliente" +
                " where Proyecto.Id_Proyecto=@Id_proyecto ";
            await _dataAccess.UpdateData(sql, createProjectView, _configuration.GetConnectionString("default"));



            return 1;

        }
        //TODO viewmodel de entrada sin (retorno numerico?)
        public async Task<int> EditPaymentStatus(EstadoPagoModel estadopago)
        {
            var sql =
                "Update EstadoPago" +
                " set EstadoPago.Cod_TipoEstadoPago=@Cod_TipoEstadoPago" +
                " where EstadoPago.Cod_EstadoPago=@Cod_EstadoPago ";
            ;
            await _dataAccess.UpdateData(sql, estadopago, _configuration.GetConnectionString("default"));
            return 1;

        }



        //TODO Insertar creato debe tener este ademas de existir para agregar estados
        public async Task AddPaymentStatus(EstadoPagoModel estadopago)
        {
            string sql =
                "insert into EstadoPago (EstadoPago.Estado_Pago,EstadoPago.Id_Proyecto,EstadoPago.Cod_TipoEstadoPago,EstadoPago.IssueExpirationDate,EstadoPago.InvoiceExpirationDate) " +
                " Values (@Estado_Pago,@Id_Proyecto,@Cod_TipoEstadoPago,@IssueExpirationDate,@InvoiceExpirationDate)";
            await _dataAccess.SaveData(sql, estadopago, _configuration.GetConnectionString("default"));
        }

        public async Task AddMember(CreateProjectViewModel project)
        {
            string sql = "insert into Integrantes_Proyecto (Integrantes_Proyecto.Id_Usuario,Integrantes_Proyecto.Id_Proyecto,Integrantes_Proyecto.Project_Hours) " +
                         " Values (@Id_Usuario,@Id_Proyecto,@HoursProject)";
            await _dataAccess.SaveData(sql, project, _configuration.GetConnectionString("default"));
        }
        public async Task<List<TipoProyectoModel>> ReadProjectType()
        {
            string sql = $"select*from {TableConstants.TablaTipoProyecto}";
            var tipro = await _dataAccess.LoadData<TipoProyectoModel, dynamic>(sql, new { },
                _configuration.GetConnectionString("default"));
            return tipro;
        }
        public async Task<List<TipoEstadoPagoModel>> ReadPaymentStatusType()
        {
            string sql = $"select*from {TableConstants.TablaTipoEstadoPago}";
            var tipoep = await _dataAccess.LoadData<TipoEstadoPagoModel, dynamic>(sql, new { },
                _configuration.GetConnectionString("default"));
            return tipoep;
        }
        //TODO Insertar mover view model a su carpeta
        public async Task<List<ViewProyectoModel>> ReadProjects()
        {
            string sql =
<<<<<<< HEAD
                "select Proyecto.Id_Proyecto,Proyecto.Cod_Proyecto,Proyecto.Nombre_Proyecto,(Usuario.Email_Bmining) as Email_JefeProyecto,Cliente.Nombre_Cliente,Tipo_Proyecto.Tipo_Proyecto,(EstadoPago.Estado_Pago) as Tipo_Pago,Tipo_EstadoPago.TipoEstadoPago,EstadoPago.Cod_EstadoPago " +
                $"from {TableConstants.TablaProyecto},{TableConstants.TablaTipoEstadoPago},{TableConstants.TablaTipoProyecto},{TableConstants.TablaEstadoPago},{TableConstants.TablaUsuario},{TableConstants.TablaClientes} " +
                $"where Proyecto.Id_Proyecto=EstadoPago.Id_Proyecto " +
                $"and EstadoPago.Cod_TipoEstadoPago=Tipo_EstadoPago.Cod_TipoEstadoPago " +
                $"and Proyecto.Cod_TipoProyecto=Tipo_Proyecto.Cod_TipoProyecto " +
                $"and Usuario.Id=Proyecto.Id_JefeProyecto " +
                $"and Proyecto.Id_Cliente=Cliente.Id_Cliente";
            var proyectos =
=======
                "select Proyecto.Id_Proyecto,Proyecto.Cod_Proyecto,Proyecto.Nombre_Proyecto,(Usuario.Email_Bmining) as EmailProjectManager,StatusProject.Status,Tipo_Proyecto.Tipo_Proyecto,Cliente.Nombre_Cliente" +
                " from Proyecto,Usuario,StatusProject,Tipo_Proyecto,Cliente" +
                " where Proyecto.Id_JefeProyecto = Usuario.Id" +
                " and Proyecto.Id_Status = StatusProject.Id_Status" +
                " and Proyecto.Cod_TipoProyecto = Tipo_Proyecto.Cod_TipoProyecto" +
                " and Proyecto.Id_Cliente = Cliente.Id_Cliente";
            var projects =
>>>>>>> master
                await _dataAccess.LoadData<ViewProyectoModel, dynamic>(sql, new { },
                    _configuration.GetConnectionString("default"));
            return projects;
        }

       

        public async Task<int> ReadIdProjectManager(int idProject)
        {
            string sql = "select Proyecto.Id_JefeProyecto " +
                         $" from {TableConstants.TablaProyecto} " +
                         $" where Proyecto.Id_Proyecto={idProject}";
            var idManager =
                await _dataAccess.LoadData<ProjectModel, dynamic>(sql, new { }, _configuration.GetConnectionString("default"));
            return idManager.First().Id_JefeProyecto;
        }
        public async Task<List<MemberProjectEditModel>> ReadMembers(int idProject)
        {
            string sql = "select Usuario.Id, Usuario.Email_Bmining,Usuario.Nombre ,Usuario.Apellido_Paterno,Usuario.Apellido_Materno,Usuario.Rut,Usuario.Cargo,Usuario.Telefono,Usuario.Direccion,Integrantes_Proyecto.Cod_Integrantes  " +
                         $" from {TableConstants.TablaUsuario},{TableConstants.TablaIntegrantes}" +
                         $" where Integrantes_Proyecto.Id_Proyecto={idProject}" +
                         $" and Usuario.Id=Integrantes_Proyecto.Id_Usuario";

            var members =
                await _dataAccess.LoadData<MemberProjectEditModel, dynamic>(sql, new { },
                    _configuration.GetConnectionString("default"));
            return members;
        }
        public async Task DeleteMember(int memberId)
        {
            string sql = "Delete " +
                         $"from {TableConstants.TablaIntegrantes} " +
                         $"where Integrantes_Proyecto.Cod_Integrantes=@memberId";
            await _dataAccess.DeleteData(sql, new { memberID = memberId }, _configuration.GetConnectionString("default"));

        }

        public async Task DeleteProyecto(int id_proyecto)
        {
            string sql = "Delete " +
                         $" from {TableConstants.TablaProyecto} " +
                         $" where Proyecto.Id_Proyecto=@id_proyecto";
            await _dataAccess.DeleteData(sql, new { Id_Proyecto = id_proyecto },
                _configuration.GetConnectionString("default"));
        }
        public async Task<int> CreateCliente(ClienteModel cliente)
        {
            var sql =
                "insert into Cliente (Cliente.Nombre_Cliente)" +
                " Values (@Nombre_Cliente)";
            await _dataAccess.SaveData(sql, cliente, _configuration.GetConnectionString("default"));


            return 0;

        }


        public async Task<List<ClienteModel>> ReadCliente()
        {
            string sql = $"select*from {TableConstants.TablaClientes}";
            var clientes = await _dataAccess.LoadData<ClienteModel, dynamic>(sql, new { },
                _configuration.GetConnectionString("default"));
            return clientes;
        }

        public async Task<List<ViewProyectoModel>> ReadProjectsOwnedByUser(int userId)
        {
            string sql =
                "select Proyecto.Id_Proyecto,Proyecto.Cod_Proyecto,Proyecto.Nombre_Proyecto,(Usuario.Email_Bmining) as Email_JefeProyecto,Cliente.Nombre_Cliente,Tipo_Proyecto.Tipo_Proyecto,(EstadoPago.Estado_Pago) as Tipo_Pago,Tipo_EstadoPago.TipoEstadoPago,EstadoPago.Cod_EstadoPago " +
                $"from {TableConstants.TablaProyecto},{TableConstants.TablaTipoEstadoPago},{TableConstants.TablaTipoProyecto},{TableConstants.TablaEstadoPago},{TableConstants.TablaUsuario},{TableConstants.TablaClientes} " +
                $"where Proyecto.Id_Proyecto=EstadoPago.Id_Proyecto " +
                $"and EstadoPago.Cod_TipoEstadoPago=Tipo_EstadoPago.Cod_TipoEstadoPago " +
                $"and Proyecto.Cod_TipoProyecto=Tipo_Proyecto.Cod_TipoProyecto " +
                $"and Usuario.Id=Proyecto.Id_JefeProyecto " +
                $"and Proyecto.Id_Cliente=Cliente.Id_Cliente";
            var projectViewModels = await _dataAccess.LoadData<ViewProyectoModel, dynamic>(sql, new { },
                    _configuration.GetConnectionString("default"));
            return projectViewModels;
        }

        public async Task<List<StatusProjectModel>> GetAvailableProjectStatus()
        {
            string sql = $"select*from {TableConstants.TablaStatusProject}";
            var statusProject = await _dataAccess.LoadData<StatusProjectModel, dynamic>(sql, new { },
                _configuration.GetConnectionString("default"));
            return statusProject;
        }
    }
}
