using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicesHost
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService2" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        void DoWork();
    }
}
