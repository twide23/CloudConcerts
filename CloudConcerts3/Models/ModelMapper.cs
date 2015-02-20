using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudConcerts3.Models
{
    public class ModelMapper
    {
        public static GigViewModel ConvertToGigViewModel(Gig gig)
        {
            return new GigViewModel
            {
                GigID = gig.GigID,
                Name = gig.Name,
                HostID = gig.HostID,
                Host = gig.Host,
                StartTime = gig.StartTime,
                EndTime = gig.EndTime,
                Description = gig.Description,
                Compensation = gig.Compensation,
                isPublic = gig.isPublic,
                hasUserApplied = false
            };
        }

        public Gig ConvertToGig(GigViewModel gigVM)
        {
            return new Gig
            {
                GigID = gigVM.GigID,
                Name = gigVM.Name,
                HostID = gigVM.HostID,
                Host = gigVM.Host,
                StartTime = gigVM.StartTime,
                EndTime = gigVM.EndTime,
                Description = gigVM.Description,
                Compensation = gigVM.Compensation,
                isPublic = gigVM.isPublic
            };
        }

        public static ConcertViewModel ConvertToConcertViewModel(Concert concert)
        {
            return new ConcertViewModel
            {
                ConcertID = concert.ConcertID,
                Name = concert.Name,
                Description = concert.Description,
                HostName = concert.Host.VenueName,
                StartTime = concert.StartTime,
                EndTime = concert.EndTime,
                TicketPrice = concert.TicketPrice,
                isPublic = concert.isPublic
            };
        }

        public Concert ConvertToConcert(ConcertViewModel concertVM)
        {
            return new Concert
            {
                ConcertID = concertVM.ConcertID,
                Name = concertVM.Name,
                Description = concertVM.Description,
                StartTime = concertVM.StartTime,
                EndTime = concertVM.EndTime,
                TicketPrice = concertVM.TicketPrice,
                isPublic = concertVM.isPublic
            };
        }
    }
}