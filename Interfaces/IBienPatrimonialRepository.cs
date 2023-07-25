using Microsoft.EntityFrameworkCore.Storage;
using SICPMonolithic.Dtos;
using SICPMonolithic.Models;

namespace SICPMonolithic.Interfaces
{
    public interface IBienPatrimonialRepository
    {
        bool Save();    

        //Bienes patrimoniales
        IEnumerable<BienPatrimonial> GetBienesForEnumerados (int enumeradoId);
        IEnumerable<BienPatrimonial> GetAllBienes();
        BienPatrimonial GetBienById(int id);
        void CreateBien(BienPatrimonial bien);
        void UpdateBien (BienPatrimonial bien);
        bool BienExists(int bienPatrimonialId);
        IDbContextTransaction CrearTransaccion();
        //Ignorar por mientras ;P
        void CreateProcedimiento(Procedimiento procedimiento);
        //Inventarios
        IEnumerable<Inventario> GetInventariosForArea(int areaId);

        IEnumerable<Inventario> GetAllInventarios();
        void CreateInventario(Inventario inventario);
        bool InventarioExists(int inventarioId);
        void UpdateInventario(Inventario inventario);

        Inventario GetInventarioById(int inventarioId);

        //Ajuste de Inventario
        IEnumerable<Ajuste> GetAllAjustes();
        Ajuste GetAjusteById(int ajusteId);
        void CreateAjuste(Ajuste ajuste);
        void UpdateAjuste(Ajuste ajuste);
        bool AjusteExists(int ajusteId);

        //AjusteDetalles
        IEnumerable<AjusteDetalle> GetAllAjusteDetalles();
        AjusteDetalle GetAjusteDetalleById(int ajusteDetalleId);
        void CreateAjusteDetalle(AjusteDetalle ajusteDetalle);
        void UpdateAjusteDetalle(AjusteDetalle ajusteDetalle);

        //Extra
        Ajuste AjusteNuevoInventario(Inventario inventario);
        AjusteDetalle AjusteDetalleNuevoInventario(Ajuste ajuste, Inventario inventario);








    }
}
