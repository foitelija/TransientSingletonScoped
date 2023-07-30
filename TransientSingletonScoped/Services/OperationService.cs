using TransientSingletonScoped.Interfaces;

namespace TransientSingletonScoped.Services
{
    public class OperationService : ITransient, ISingleton, IScoped
    {
        Guid _id;
        public OperationService()
        {
            _id = Guid.NewGuid();
        }
        public Guid GetOperationID()
        {
            return _id;
        }
    }
}
