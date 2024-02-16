using AcumaticaWorkWave.API.Domain;
using AcumaticaWorkWave.DAC;

namespace AcumaticaWorkWave.BLC
{
    internal interface WWISyncWWEntity
    {
        void SyncWWOrder(WWSync row);
    }
}