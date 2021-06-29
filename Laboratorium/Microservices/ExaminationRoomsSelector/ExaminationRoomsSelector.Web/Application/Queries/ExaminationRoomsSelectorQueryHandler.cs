namespace ExaminationRoomsSelector.Web.Application.Queries
{
    using ExaminationRoomsSelector.Web.Application.DataServiceClients;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ExaminationRoomsSelectorQueryHandler : IExaminationRoomsSelectorHandler
    {
        private readonly IExaminationRoomsServiceClient examinationRoomsServiceClient;
        private readonly IDoctorsServiceClient doctorsServiceClient;

        public ExaminationRoomsSelectorQueryHandler(IExaminationRoomsServiceClient examinationRoomsServiceClient, IDoctorsServiceClient doctorsServiceClient)
        {
            this.examinationRoomsServiceClient = examinationRoomsServiceClient;
            this.doctorsServiceClient = doctorsServiceClient;
        }

        public async Task<List<Pair>> GetExaminationRoomsSelectionAsync()
        {
            var doctors = await doctorsServiceClient.GetAllDoctorsAsync();
            var rooms = await examinationRoomsServiceClient.GetAllExaminationRoomsAsync();

            return PairRoomDoctor(doctors, rooms);
        }
        public List<Pair> PairRoomDoctor(IEnumerable<Dtos.DoctorDto> doctors, IEnumerable<Dtos.ExaminationRoomDto> rooms)
        {
            IEnumerable<Dtos.ExaminationRoomDto> roomsort = rooms.OrderByDescending(room => room.Certifications.Count());
            IEnumerable<Dtos.DoctorDto> doctorsort = doctors.OrderByDescending(doctors => doctors.Specializations.Count());
            
            var pairs = new List<Pair>();
            int max = 0;
            int common = 0;
    
            Pair maxPair = null;
            var useddocs = new List<Dtos.DoctorDto>();
            var usedrooms = new List<Dtos.ExaminationRoomDto>();
            int maxCert = 0;
            bool search = true;
            try
            {
                if(doctors.Count() == 0 || rooms.Count()==0)
                    throw new ArgumentException("List must not be empty");

                foreach (var doc in doctorsort)
                {
                    maxPair = null;
                    max = 0;
                    maxCert = doc.Specializations.Count();
                    search = true;
                    int i = maxCert;
                    while (search && i>=0)
                    {
                        foreach (var r in roomsort)
                        {
                            List<String> cerifications = new List<string>();
                            foreach (int cert in r.Certifications)
                                cerifications.Add(cert.ToString());
                            List<String> diff = (cerifications.Intersect(doc.Specializations)).ToList<String>();
                            common = diff.Count();
                            Console.WriteLine(common + " " + doc.Surname + " " + r.Number);
                            if (common == i && !useddocs.Contains(doc) && !usedrooms.Contains(r))
                            {
                                //max = common;
                                maxPair = new Pair(doc, r);
                                search = false;
                            }
                        }
                        i--;
                    }
                    if (maxPair != null)
                    {
                        pairs.Add(maxPair);
                        useddocs.Add(maxPair.doctor);
                        usedrooms.Add(maxPair.room);
                    }
                    Console.WriteLine(maxPair.doctor.Surname + " " + maxPair.room.Number);
                    Console.WriteLine("------------------");
                }
                if(pairs.Count() != doctors.Count())
                {
                    var leftDoctors = doctorsort.Except(useddocs).ToList();
                    var leftRooms = rooms.Except(usedrooms).ToList();
                    foreach(var doc in leftDoctors)
                    {
                        var r = leftRooms[0];
                        pairs.Add(new Pair(doc, r));
                        leftRooms.Remove(r);
                    }
                }
                
            } catch (Exception e)
            {
                throw new ArgumentException(e.ToString());
            }
            return pairs;
        }
    }
}

