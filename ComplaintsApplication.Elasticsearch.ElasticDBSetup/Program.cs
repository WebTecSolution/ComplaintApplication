using ComplaintsApplication.Common.Model;
using Nest;
using System;

namespace ComplaintsApplication.Elasticsearch.ElasticDBSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started creating Database in Elastic search");
            CreateIndex();
            CreateMappings();
            Console.WriteLine("Database created.");
        }

        /// <summary>
        /// complaintstore DB creating in the elasticsearch
        /// </summary>
        public static void CreateIndex()
        {
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            settings.DefaultIndex("complaintstore");
            ElasticClient client = new ElasticClient(settings);
            client.Indices.Delete(Indices.Index("complaintstore"));
            client.Indices.Delete(Indices.Index("employeestore"));
            var indexSettings = client.Indices.Exists("complaintstore");
            if (!indexSettings.Exists)
            {
                var indexName = Indices.Index("complaintstore");
                var response = client.Indices.Create(indexName);
            }

            if (indexSettings.Exists)
            {
                Console.WriteLine("Created");
            }

        }

        /// <summary>
        /// Complaints Mapping
        /// </summary>
        public static void CreateMappings()
        {
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            settings.DefaultIndex("complaintstore");
            ElasticClient esClient = new ElasticClient(settings);
            esClient.Map<Complaints>(m =>
            {
                var putMappingDescriptor = m.Index(Indices.Index("complaintstore")).AutoMap();
                return putMappingDescriptor;
            });
        }
    }
}
