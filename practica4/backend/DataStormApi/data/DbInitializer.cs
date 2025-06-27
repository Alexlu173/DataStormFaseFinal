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

            var operacionAlfa = new Operacion { Nombre = "Alfa", Estado = "Activa", FechaInicio = DateTime.now(), FechaFin = DateTime.now().AddDays(2)};
            var operacionBeta = new Operacion { Nombre = "Beta", Estado = "Planificada", FechaInicio = DateTime.now(), FechaFin = DateTime.now().AddDays(2)};
            var operacionDelta = new Operacion { Nombre = "Delta", Estado = "Completada", FechaInicio = DateTime.now(), FechaFin = DateTime.now().AddDays(2)};

            var operaciones = new Operacion[]
            {
                new Pizza
                    { 
                        Name = "Meat Lovers", 
                        Sauce = tomatoSauce, 
                        Toppings = new List<Topping>
                            {
                                pepperoniTopping, 
                                sausageTopping, 
                                hamTopping, 
                                chickenTopping
                            }
                    },
                new Pizza
                    { 
                        Name = "Hawaiian", 
                        Sauce = tomatoSauce, 
                        Toppings = new List<Topping>
                            {
                                pineappleTopping, 
                                hamTopping
                            }
                    },
                new Pizza
                    { 
                        Name="Alfredo Chicken", 
                        Sauce = alfredoSauce, 
                        Toppings = new List<Topping>
                            {
                                chickenTopping
                            }
                        }
            };

            context.Pizzas.AddRange(pizzas);
            context.SaveChanges();
        }
    }
}