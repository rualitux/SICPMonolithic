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
        void CreateBien(int enumeradoId, BienPatrimonial bien);
        bool BienExists(int bienPatrimonialId);


        //Procedimientos
      

        //Areas
        //IEnumerable<BienPatrimonial> GetBienesForAreas(int areaId);

     

        //Inventarios
        IEnumerable<Inventario> GetInventariosForArea(int areaId);

        IEnumerable<Inventario> GetAllInventarios();
        void CreateInventario(int bienPatrimonialId, int areaId, int anexoTipoId, int estadoCondicionId, int estadoBienId, Inventario inventario);
        bool InventarioExists(int inventarioId);
        Inventario GetInventarioById(int inventarioId);
        public void DarAlta(Alta alta);



        //ProcedimientoBien
        IEnumerable<ProcedimientoBien> GetBienesByProcedimiento(int procedimientoId);
        IEnumerable<ProcedimientoBien> GetProcedimientosByBien(int bienPatrimonialId);


        IEnumerable<ProcedimientoBien> GetAllProcedimientoBienes();
        void CreateProcedimientoBien(int bienPatrimonialId, int procedimientoId, ProcedimientoBien procedimientoBien);
        bool ProcedimientoBienesExists(int procedimientoBienId);
        ProcedimientoBien GetProcedimientoBienById(int procedimientoBienId);
    }
}
