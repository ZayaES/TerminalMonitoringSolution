using TerminalMonitoringSolution.DataAccess;
using TerminalMonitoringSolution.Entities;
using TerminalMonitoringSolution.IServices;

namespace TerminalMonitoringSolution.Services
{
    public class SerialNumberService : ISerialNumberService
    {
        private readonly ApplicationDbContext _context;

        public SerialNumberService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string GetNextSerialId(string entityType)
        {
            Dictionary<string, string> entitiesPrefix = new Dictionary<string, string>()
            {
                { "Custodians", "CST" },
                { "Terminals", "T" },
                { "TerminalInformation", "TI" },
                { "Transactions", "TRX" }
            };

            if (!entitiesPrefix.ContainsKey(entityType))
            {
                throw new ArgumentException("EntityType used does not exist");
            }

            string prefix = entitiesPrefix[entityType];

            var tracker = _context.SerialNumberTrackers
                .SingleOrDefault(t => t.EntityType == entityType);

            string newId;

            if (tracker == null)
            {
                newId = $"{prefix}0001";
                _context.SerialNumberTrackers.Add(new SerialNumberTracker
                {
                    EntityType = entityType,
                    LastUsedId = newId
                });
            }
            else
            {
                var lastUsedId = tracker.LastUsedId;
                var lastNumber = int.Parse(lastUsedId.Substring(prefix.Length));
                var nextNumber = lastNumber + 1;
                newId = $"{prefix}{nextNumber:D4}";

                tracker.LastUsedId = newId;
            }

            _context.SaveChanges();
            return newId;
        }
    }
}
