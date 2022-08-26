using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application.Servicos
{
    public class EventosService : IEventosService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        public EventosService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("AddEvento() Error: " + ex.Message);
            }
        }
        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = _eventoPersist.GetEventoByIdAsync(eventoId);

                if(evento == null) return null;    
                
                model.Id = evento.Id;

                _geralPersist.Update<Evento>(model);                
                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id);
                }
                return null; 
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateEvento() Error: " + ex.Message);
            }                 
        }
        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId);

                if(evento == null) 
                    throw new Exception("Evento para Delete não encontrado: " + eventoId.ToString());      

                _geralPersist.Delete<Evento>(evento);  

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteEvento() Error: " + ex.Message);
            }        
        }

        public Task<Evento[]> GetALlEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = _eventoPersist.GetALlEventosAsync(includePalestrantes);
                
                if(eventos == null) return null;
   
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception("GetALlEventosAsync() Error: " + ex.Message);
            }        
        }

        public Task<Evento[]> GetALlEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var evento = _eventoPersist.GetALlEventosByTemaAsync(tema, includePalestrantes);

                if(evento == null) return null;
   
                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception("GetALlEventosByTemaAsync() Error: " + ex.Message);
            }        
        }

        public Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);
                
                if(evento == null) return null;
   
                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception("GetEventoByIdAsync() Error: " + ex.Message);
            }        
        }
    }
}