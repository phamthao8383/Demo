using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace ShopClient_MVC.Models
{
    public class MappingData
    {
        //Singleton Pattern
        private static MappingData instance = null;
        public static MappingData GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MappingData();
                }
                try
                {
                    if (_mapper == null)
                    {
                        _mapper = Mapper.Instance();
                        //load db config 
                        string con = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                        //set db connectstring
                        _mapper.DataSource.ConnectionString = con;
                    }
                }
                catch
                {
                    _mapper = null;
                }
                return instance;
            }
        }

        public ISqlMapper MapperData { get => _mapper; }
        private static ISqlMapper _mapper = null;
    }
}