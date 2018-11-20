using System.Collections.Generic;
using FogApi.Models;

namespace FogApi.Interfaces
{
    public interface IRepository
    {
        Thing GetThing(int id);
        IEnumerable<Thing> GetThings();
        Entity GetEntity(int id);
        IEnumerable<Entity> GetEntities();
        HistoryEntry GetHistoryEntry(int id);
        IEnumerable<HistoryEntry> GetHistoryEntries();
    }
}