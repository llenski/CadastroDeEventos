using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence.Repositorios
{
    public class EventoPersist : IEventoPersist
    {
        private readonly ProEventosContext _context;
        public EventoPersist(ProEventosContext context)
        {
            _context = context;
        }
        public async Task<Evento[]> GetALlEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                .Include(e => e.Lotes) 
                                .Include(e => e.RedesSociais);

            if(includePalestrantes)
            {
                query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(ep => ep.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                .Include(e => e.Lotes) 
                                .Include(e => e.RedesSociais);

            if(includePalestrantes)
            {
                query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(ep => ep.Palestrante);
            }
            
            query = query.AsNoTracking().OrderBy(e => e.Id)
                        .Where(e => e.Id == eventoId);
 
            return await query.FirstOrDefaultAsync();        
        }

        public async Task<Evento[]> GetALlEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                .Include(e => e.Lotes) 
                                .Include(e => e.RedesSociais);

            if(includePalestrantes)
            {
                query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(ep => ep.Palestrante);
            }
            
            query = query.AsNoTracking().OrderBy(e => e.Id)
                        .Where(e => e.Tema.ToLower()
                            .Contains(tema.ToLower()));

            return await query.ToArrayAsync();        
        }
    }
}