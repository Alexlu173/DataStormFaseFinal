using DataStormApi.Models;

namespace DataStormApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Operaciones.Any()
                && context.Equipos.Any()
                && context.Agentes.Any())
            {
                return;   // DB has been seeded
            }

            // Crear operaciones
            var operacionAlfa = new Operacion
            {
                Nombre = "Alfa",
                Estado = Operacion.EstadoOperacion.Completada,
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now.AddDays(2)
            };
            var operacionBeta = new Operacion
            {
                Nombre = "Beta",
                Estado = Operacion.EstadoOperacion.Planificada,
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now.AddDays(2)
            };
            var operacionDelta = new Operacion
            {
                Nombre = "Delta",
                Estado = Operacion.EstadoOperacion.Activa,
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now.AddDays(2)
            };

            context.Operaciones.AddRange(operacionAlfa, operacionBeta, operacionDelta);
            context.SaveChanges();

            // Crear equipos
            var equipoAlpha = new Equipo { Nombre = "Equipo Alpha", especialidad = "Reconocimiento", OperacionId = operacionAlfa.Id };
            var equipoBeta = new Equipo { Nombre = "Equipo Beta", especialidad = "Asalto", OperacionId = operacionBeta.Id };
            var equipoDelta = new Equipo { Nombre = "Equipo Delta", especialidad = "Rescate", OperacionId = operacionDelta.Id };

            context.Equipos.AddRange(equipoAlpha, equipoBeta, equipoDelta);
            context.SaveChanges();

            // Crear agentes
            var agente = new Agente { Nombre = "John", Apellidos = "Perez", Rango = "Líder", Email = "john@test.com", Password = "xxx", Salt = "xxx", Activo = true, EquipoId = equipoAlpha.Id};
            var agente1 = new Agente { Nombre = "Agente 1", Apellidos="Ramirez", Email="agente1@gmail.com", Password="123", Rango = "Líder", Salt="xxx", Activo = true, EquipoId = equipoAlpha.Id };
            var agente2 = new Agente { Nombre = "Agente 2", Apellidos="Perez", Email="agente2@gmail.com", Password="1233", Rango = "Especialista", Salt="xxx", Activo = true, EquipoId = equipoAlpha.Id };
            var agente3 = new Agente { Nombre = "Agente 3", Apellidos="Sanchez", Email="agente3@gmail.com", Password="1234", Rango = "Técnico", Salt="xxx", Activo = true, EquipoId = equipoBeta.Id };
            var agente4 = new Agente { Nombre = "Agente 4", Apellidos="Luna", Email="agente4@gmail.com", Password="1232", Rango = "Operativo", Activo = true, Salt="xxx", EquipoId = equipoDelta.Id };
            context.Agentes.AddRange(agente1, agente2, agente3, agente4);
            context.SaveChanges();
        }

    }
}