using Common.Module.Interface;
using Common.Module.Models;
using Data.Module.Provider;
using FileReader.Module.Interface;
using FileReader.Module.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Data.Module.Helper
{
    public class Factory<T> : IFactory<T>
    {
        private readonly IUnityContainer unityContainer;
        public Factory()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<IFileReader<T>, CSVFileReaderManager<T>>("CSV");
            unityContainer.RegisterType<IDataManager<LPDatModel>, LPDataManager<LPDatModel>>();
            unityContainer.RegisterType<IDataManager<TOUDataModel>, TOUDataManager<TOUDataModel>>();
            unityContainer.RegisterType<IFileReaderDataManager<LPDatModel>, LPDataManager<LPDatModel>>();
            unityContainer.RegisterType<IFileReaderDataManager<TOUDataModel>, TOUDataManager<TOUDataModel>>();
        }

        public IFileReader<T> GetFileReaderInstance(string fileType)
        {
            var instance = unityContainer.Resolve<IFileReader<T>>(fileType);
            return instance;

        }

        public IDataManager<T> GetDataManagerInstance()
        {
            var instance = unityContainer.Resolve<IDataManager<T>>();
            return instance;

        }

        public IFileReaderDataManager<T> GetFileReaderDataManagerInstance()
        {
            var instance = unityContainer.Resolve<IFileReaderDataManager<T>>();
            return instance;

        }
    }
}
