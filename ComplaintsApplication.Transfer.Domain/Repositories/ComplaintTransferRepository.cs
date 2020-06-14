using ComplaintsApplication.Common.Model;
using ComplaintsApplication.Transfer.Domain.Interfaces;
using Nest;
using System;

namespace ComplaintsApplication.Transfer.Domain.Repositories
{
    public class ComplaintTransferRepository : IComplaintTransferRepository
    {
        public void TransferInsertComplaint(Complaints complaint)
        {
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"));

            settings.DefaultIndex("complaintstore");
            ElasticClient esClient = new ElasticClient(settings);
            Complaints comp = new Complaints
            {
                Id = complaint.Id,
                ComplaintDescription = complaint.ComplaintDescription,
                ComplaintBy = complaint.ComplaintBy,
                ComplaintDate = complaint.ComplaintDate,
                IsResolved = complaint.IsResolved
            };
            esClient.Index<Complaints>(comp, i => i
                                              .Index("complaintstore")
                                              .Id(complaint.Id)
                                              .Refresh(Elasticsearch.Net.Refresh.True));
        }

        public void TransferUpdateComplaint(int Id, Complaints complaint)
        {
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            settings.DefaultIndex("complaintstore");
            ElasticClient esClient = new ElasticClient(settings);
            Complaints comp = new Complaints
            {
                Id = complaint.Id,
                ComplaintDescription = complaint.ComplaintDescription,
                ComplaintBy = complaint.ComplaintBy,
                ComplaintDate = complaint.ComplaintDate,
                IsResolved = complaint.IsResolved
            };

            esClient.Index<Complaints>(comp, i => i
                                           .Index("complaintstore")
                                           .Id(complaint.Id)
                                           .Refresh(Elasticsearch.Net.Refresh.True));
        }

        public void TransferDeleteComplaint(int id)
        {
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            settings.DefaultIndex("complaintstore");
            ElasticClient esClient = new ElasticClient(settings);
            esClient.Delete<Complaints>(new Id(id));
            //var delRequest = new DeleteRequest(indexName, id);
            //delRequest.Refresh = Elasticsearch.Net.Refresh.True;
            esClient.Delete(new DocumentPath<Complaints>(new Id(id)));
        }
    }
}
