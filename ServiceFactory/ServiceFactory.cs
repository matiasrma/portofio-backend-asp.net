using AccesoADatos;
using AccesoADatos.Repositorio;
using ILogicaDominio;
using InterfazAccesoADatos;
using LogicaDominio;
using Microsoft.Extensions.DependencyInjection;

namespace Service
{
    public class ServiceFactory
    {
        private readonly IServiceCollection services;

        public ServiceFactory(IServiceCollection _services)
        {
            this.services = _services;
        }

        public void AddCustomServices()
        {
            services.AddScoped<IConexionDB, ConexionDB>();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<ILogicaUsuario, LogicaUsuario>();

            services.AddScoped<ISocialRepositorio, SocialRepositorio>();
            services.AddScoped<ILogicaSocial, LogicaSocial>();

            services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
            services.AddScoped<ILogicaPersona, LogicaPersona>();

            services.AddScoped<IAcercaDeRepositorio, AcercaDeRepositorio>();
            services.AddScoped<ILogicaAcercaDe, LogicaAcercaDe>();

            services.AddScoped<IExperienciaRepositorio, ExperienciaRepositorio>();
            services.AddScoped<ILogicaExperiencia, LogicaExperiencia>();

            services.AddScoped<ISkillRepositorio, SkillRepositorio>();
            services.AddScoped<ILogicaSkill, LogicaSkill>();

            services.AddScoped<IProyectoRepositorio, ProyectoRepositorio>();
            services.AddScoped<ILogicaProyecto, LogicaProyecto>();
        }
    }
}