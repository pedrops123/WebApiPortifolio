﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Portifolio.Domain.Query.Configurations
{
    public abstract class DapperCustomSearch<T, F> where T : class
    {
        private IConfigurationRoot _conf;
        protected string _connectionStrings
        {
            get => _conf.GetConnectionString("DefaultConnection");
        }

        public DapperCustomSearch() => _conf = ConfigurationRootFactory.SetConfigurationRootBuilder();
        
        public virtual async Task<T> GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStrings))
            {
                SqlBuilder builder = new SqlBuilder();

                builder.Where("Id = @id", new { id = id });

                var queryResult = builder.AddTemplate($"SELECT * FROM { typeof(T).Name } /**where**/");

                var result = (await connection.QueryAsync<T>(queryResult.RawSql, queryResult.Parameters)).FirstOrDefault();

                return result;
            }
        }

        public virtual async Task<List<T>> GetList(F filter)
        {
            List<KeyValuePair<string, string>> Params = new List<KeyValuePair<string, string>>();
            var ListProperties = typeof(F).GetProperties();

            foreach (PropertyInfo property in ListProperties)
            {
                var value = typeof(F).GetProperty(property.Name).GetValue(filter);

                if (value != null)
                {
                    var Type = value.GetType();

                    switch (Type.Name.ToLower())
                    {
                        case "string":
                            if (!String.IsNullOrEmpty((string)value))
                            {
                                Params.Add(new KeyValuePair<string, string>(property.Name, (string)value));
                            }
                            break;
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(_connectionStrings))
            {
                SqlBuilder builder = new SqlBuilder();

                var queryResult = builder.AddTemplate($"SELECT * FROM { typeof(T).Name } /**where**/");

                foreach (KeyValuePair<string, string> KeyValue in Params)
                {
                    var value = KeyValue.Value.GetType();
                    switch (value.Name.ToLower())
                    {
                        case "string":
                            builder.Where($"{ KeyValue.Key } = '{ KeyValue.Value }'");
                        break;
                    }
                }

                var result = (await connection.QueryAsync<T>(queryResult.RawSql, queryResult.Parameters)).ToList();

                return result;
            }
        }
    }
}