using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence.Repositorios
{
    public class PalestrantesPersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;

        public PalestrantesPersist(ProEventosContext context)
        {
            _context = context;
        }
        public async Task<Palestrante[]> GetALlPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
                                        .Include(p => p.RedesSociais);

            if(includeEventos)
            {
                query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }
            
            query = query.OrderBy(p =>p.Id);

            return await query.ToArrayAsync();          
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
                                        .Include(p => p.RedesSociais);

            if(includeEventos)
            {
                query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }
            
            query = query.OrderBy(p => p.Id)
                    .Where(p=> p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();            
        }

        public async Task<Palestrante[]> GetALlPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
                                        .Include(p => p.RedesSociais);

            if(includeEventos)
            {
                query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }
            
                query = query.OrderBy(p => p.Id)
                            .Where(p => p.Nome.ToLower()
                                .Contains(nome.ToLower()));

                return await query.ToArrayAsync();          
            }
    }
}