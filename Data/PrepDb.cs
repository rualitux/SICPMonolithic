using SICPMonolithic.Data;
using SICPMonolithic.Models;

namespace SICPMonolithic.Data
{
    public static class PrepDb
    {

        public static void PrepPopulation(IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.BienesPatrimoniales.Any())
            {
                Console.WriteLine("Seedeando data... checa el API sobrino");
                context.BienesPatrimoniales.AddRange(
                        new BienPatrimonial() { Denominacion = "Perro", CategoriaId = 1, Color = "Negro", ProcedimientoId = 1 },
                        new BienPatrimonial() { Denominacion = "Perro2", CategoriaId = 1, Color = "Dorado", ProcedimientoId = 1 },
                        new BienPatrimonial() { Denominacion = "Botecito 3", CategoriaId = 2, Marca = "Wanxin", ProcedimientoId = 2 }
                            );
                context.Enumerados.AddRange(
                        //1
                        new Enumerado() { Valor = "Animales", Padre =11 },
                        new Enumerado() { Valor = "Bote", Padre = 11 },
                        //3
                        new Enumerado() { Valor = "Donacion", Padre = 13 },
                        new Enumerado() { Valor = "Reposición", Padre = 13 },
                        //5
                        new Enumerado() { Valor = "Central", Padre = 14 },
                        new Enumerado() { Valor = "GERFFS", Padre = 15 },
                        new Enumerado() { Valor = "Activo", Padre = 16 },
                        //8
                        new Enumerado() { Valor = "A" , Padre = 17 },
                        new Enumerado() { Valor = "Bueno", Padre = 18 },
                        //10
                        new Enumerado() { Valor = "Alta", Padre = 12 },
                        new Enumerado() { Valor = "Categoria", Padre = 19 },
                        new Enumerado() { Valor = "TipoProcedimiento", Padre = 19 },
                        new Enumerado() { Valor = "Causal", Padre = 19 },
                        new Enumerado() { Valor = "Sede", Padre = 19 },
                        new Enumerado() { Valor = "Dependencia", Padre = 19 },
                        //16
                        new Enumerado() { Valor = "EstadoGeneral", Padre = 19 },
                        new Enumerado() { Valor = "Anexo", Padre = 19 },
                        new Enumerado() { Valor = "Estado Condicion", Padre = 19 },
                        new Enumerado() { Valor = "Enumerado" },
                        new Enumerado() { Valor = "Atalaya", Padre =14},
                        new Enumerado() { Valor = "GOREU", Padre = 15 }




                );
                context.Procedimientos.AddRange(
                        new Procedimiento() { NombreReferencial = "Alta Animales",
                            NumeroDocumento ="2706 AA GRU 2022-GERFFS-GRU",
                            //CausalString = "Donación",
                            CausalId = 3, 
                            //ProcedimientoTipoString = "Alta",
                            ProcedimientoTipoId = 10 },
                        new Procedimiento() { NombreReferencial = "Alta Navíos",
                            NumeroDocumento = "1488 AN GRU 2022-GERFFS-GRU",
                            //CausalString = "Reposición", 
                            CausalId = 4, 
                            //ProcedimientoTipoString = "Alta", 
                            ProcedimientoTipoId = 10 }

                    );
                context.ProcedimientoBiens.AddRange(
                    new ProcedimientoBien() { BienPatrimonialId = 1, BienPatrimonialString = "Perro", ProcedimientoId = 1, ProcedimientoString = "Alta Animales" }
                    );
                context.Areas.AddRange(
                    new Area() { Nombre = "Sistemas", SedeString = "Central", SedeId = 5, DependenciaString = "GERFFS", DependenciaId = 6, EstadoAreaString = "Activo", EstadoAreaId = 7 },
                new Area() { Nombre = "Patrimonio", SedeString = "Central", SedeId = 5, DependenciaString = "GERFFS", DependenciaId = 6, EstadoAreaString = "Activo", EstadoAreaId = 7 }
                    );
                context.Inventarios.AddRange(
                   new Inventario()
                   {
                       Cantidad = 1,
                       BienPatrimonialString = "Perro",
                       BienPatrimonialId = 1,
                       AreaString = "Sistemas",
                       AreaId = 1,
                       AnexoTipoString = "A",
                       AnexoTipoId = 8,
                       EstadoBienString = "Activo",
                       EstadoBienId = 7,
                       EstadoCondicionString = "Bueno",
                       EstadoCondicionId = 9
                   },
                   new Inventario()
                   {
                       Cantidad = 3,
                       BienPatrimonialString = "Botecito 3",
                       BienPatrimonialId = 3,
                       AreaString = "Patrimonio",
                       AreaId = 2,
                       AnexoTipoString = "A",
                       AnexoTipoId = 8,
                       EstadoBienString = "Activo",
                       EstadoBienId = 7,
                       EstadoCondicionString = "Bueno",
                       EstadoCondicionId = 9
                   }
                    );
                context.SaveChanges();

            }
            else
            {
                Console.WriteLine("Ya hay datos");
            }

        }
    }
}


