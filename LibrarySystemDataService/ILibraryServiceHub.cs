using System;
using System.Collections.Generic;
using System.ServiceModel;
using EntitiesCore;

namespace LibrarySystemDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ILibraryServiceHub
    {
        [OperationContract]
        bool Insert(SampleTestCollection entity);

        [OperationContract]
        bool Update(SampleTestCollection entity);

        [OperationContract]
        bool Delete(SampleTestCollection entity);

        [OperationContract]
        IList<SampleTestCollection> GetAll();

        [OperationContract]
        SampleTestCollection GetById(Guid id);
    }
}
