using ComplaintsApplication.Common.Model;
using ComplaintsApplication.ReadWrite.Domain.Interfaces;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComplaintsApplication.ReadWrite.Domain.Repositories
{
    public class ComplaintRepository : IComplaintRepository
    {
        public ComplaintRepository()
        {
        }

        public IEnumerable<Complaints> GetComplaints()
        {
            Complaints complaints = null;
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            settings.DefaultIndex("employeestore");
            ElasticClient esClient = new ElasticClient(settings);

            var response = esClient.Search<Complaints>(s => s.Query(q => q.MatchAll()));
            var employee1 = response.Hits.ToList();
            List<Complaints> empList = new List<Complaints>();
            foreach (var item in employee1)
            {
                complaints = new Complaints
                {
                    Id = item.Source.Id,
                    ComplaintDescription = item.Source.ComplaintDescription,
                    ComplaintBy = item.Source.ComplaintBy,
                    ComplaintDate = item.Source.ComplaintDate,
                    IsResolved = item.Source.IsResolved
                };
                empList.Add(complaints);
            }
            return empList;
        }

        public Complaints GetComplaintById(int Id)
        {
            Complaints complaints = null;
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            settings.DefaultIndex("employeestore");
            ElasticClient esClient = new ElasticClient(settings);

            var response = esClient.Search<Complaints>(s => s.Query(
                q => q.Term(fld => fld.Id, Id)));

            if (response != null)
            {
                var comp = response.Hits.FirstOrDefault();
                complaints = new Complaints
                {
                    Id = comp.Source.Id,
                    ComplaintDescription = comp.Source.ComplaintDescription,
                    ComplaintBy = comp.Source.ComplaintBy,
                    ComplaintDate = comp.Source.ComplaintDate,
                    IsResolved = comp.Source.IsResolved
                };
            }
            return complaints;
        }
    }
}
