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
            var agente1 = new Agente { Nombre = "Agente 1", NombreAgente="Pedro", Apellido="Ramirez", email="agente1@gmail.com", password="123" ,rango = "Líder", Activo = true, EquipoId = equipoAlpha.Id };
            var agente2 = new Agente { Nombre = "Agente 2", NombreAgente="Alonso", Apellido="Perez", email="agente2@gmail.com", password="1233",rango = "Especialista", Activo = true, EquipoId = equipoAlpha.Id };
            var agente3 = new Agente { Nombre = "Agente 3", NombreAgente="Maria", Apellido="Sanchez", email="agente3@gmail.com", password="1234",rango = "Técnico", Activo = true, EquipoId = equipoBeta.Id };
            var agente4 = new Agente { Nombre = "Agente 4",NombreAgente="Alejandro", Apellido="Luna", email="agente4@gmail.com", password="1232", rango = "Operativo", Activo = true, EquipoId = equipoDelta.Id };
            context.Agentes.AddRange(agente1, agente2, agente3, agente4);
            context.SaveChanges();
        }

    }
}