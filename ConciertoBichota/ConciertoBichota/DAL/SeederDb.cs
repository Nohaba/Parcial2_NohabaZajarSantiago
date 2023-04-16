using ConciertoBichota.DAL.Entities;
using Microsoft.Win32;

namespace ConciertoBichota.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;

        public SeederDb(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeedAsync() 
        {
            await _context.Database.EnsureCreatedAsync();
            await TsTickets();

            await _context.SaveChangesAsync();
        }

        private async Task TsTickets()
        {
            if (!_context.Tickets.Any())
            {
                for (int i = 1; i <= 50000; i++)
                {

                    _context.Tickets.Add(new ConcertDB
                    {
                        UseDate = null,
                        IsUsed = false,
                        EntranceGate = null
                    });
                   
                }
              

            }
        }
    }
}
