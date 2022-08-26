using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application.Servicos
{
    public class PalestrantesService : IPalestrantesService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPalestrantePersist _palestrantePersist;

        public PalestrantesService(IGeralPersist geralPersist, IPalestrantePersist palestrantePersist)
        {
            _geralPersist = geralPersist;
            _palestrantePersist = palestrantePersist;
        }
        public async Task<Palestrante> AddPalestrante(Palestrante model)
        {
            try
            {
                _geralPersist.Add<Palestrante>(model);
                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _palestrantePersist.GetPalestranteByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("AddPalestrante() Error: " + ex.Message);
            }
        }
        
        public async Task<Palestrante> UpdatePalestrante(int palestranteId, Palestrante model)
        {
            try
            {   
                var palestrante = await _palestrantePersist.GetPalestranteByIdAsync(palestranteId);

                if(palestrante == null) return null;     

                model.Id = palestrante.Id;

                _geralPersist.Update<Palestrante>(model);
                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _palestrantePersist.GetPalestranteByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("UpdatePalestrante() Error: " + ex.Message);
            }
        }

        public async Task<bool> DeletePalestrante(int palestranteId)
        {
            try
            {
                var palestrante = await _palestrantePersist.GetPalestranteByIdAsync(palestranteId);

                if(palestrante == null) 
                    throw new Exception("Palestrante para Delete não encontrado: " + palestranteId.ToString());      

                _geralPersist.Delete<Palestrante>(palestrante);  

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("DeletePalestrante() Error: " + ex.Message);
            }
         }

        public Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            try
            {
               var palestrantes = _palestrantePersist.GetALlPalestrantesAsync(includeEventos);

                if(palestrantes != null) return null;

                return palestrantes;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllPalestrantesAsync() Error: " + ex.Message);
            }
        }

        public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            try
            {
               var palestrantes = _palestrantePersist.GetALlPalestrantesByNomeAsync(nome, includeEventos);
                
                if(palestrantes != null) return null;

                return palestrantes;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllPalestrantesByNomeAsync() Error: " + ex.Message);
            }
        }

        public Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            try
            {
               var palestrante = _palestrantePersist.GetPalestranteByIdAsync(palestranteId, includeEventos);

                if(palestrante != null) return null;

                return palestrante;
            }
            catch (Exception ex)
            {
                throw new Exception("GetPalestranteByIdAsync() Error: " + ex.Message);
            }
        }
    }
}