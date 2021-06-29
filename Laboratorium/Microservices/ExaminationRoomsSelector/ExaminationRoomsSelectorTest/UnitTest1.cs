namespace ExaminationRoomSelectorTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ExaminationRoomsSelector.Web.Application.Queries;
    using System.Collections.Generic;
    using ExaminationRoomsSelector.Web.Application.Dtos;
    using ExaminationRoomsSelector.Web.Application.DataServiceClients;
    using System;
    using System.Linq;
    using System.Diagnostics;

    [TestClass]
    public class UnitTest1
    {
        private IExaminationRoomsServiceClient examinationRoomsServiceClient;
        private IDoctorsServiceClient doctorsServiceClient;

        private static readonly List<ExaminationRoomDto> examinationRooms = new List<ExaminationRoomDto>()
        {
            new ExaminationRoomDto("01", new List<string>{"1"}),
            new ExaminationRoomDto("02", new List<string>{"1", "2"}),
            new ExaminationRoomDto("03", new List<string>{"5", "7" }),
            new ExaminationRoomDto("101", new List<string>{ "6", "3", "5"}),
            new ExaminationRoomDto("102", new List<string>{"3", "2"}),
            new ExaminationRoomDto("103", new List<string>{"2", "1", "5"}),
            new ExaminationRoomDto("104", new List<string>{"5"}),
            new ExaminationRoomDto("105a", new List<string>{ "12"}),
            new ExaminationRoomDto("105b", new List<string>{ "7", "6", "5"}),
            new ExaminationRoomDto("201", new List<string>{ "9", "7", "8"}),
            new ExaminationRoomDto("202", new List<string>{"10", "1"}),
            new ExaminationRoomDto("203", new List<string>{ "1"}),
            new ExaminationRoomDto("204a", new List<string>{ "4"}),
            new ExaminationRoomDto("204b", new List<string>{ "7", "6"}),
            new ExaminationRoomDto("301", new List<string>{ "6", "5"}),
            new ExaminationRoomDto("302", new List<string>{ "5", "4"}),
            new ExaminationRoomDto("303", new List<string>{ "5", "3"}),
            new ExaminationRoomDto("401", new List<string>{ "8", "1", "2"}),
            new ExaminationRoomDto("402", new List<string>{"1"}),
            new ExaminationRoomDto("403", new List<string>{"2", "4"})
        };

        private static readonly List<DoctorDto> doctors = new List<DoctorDto>()
        {
            new DoctorDto("Jan", "Kowalski", 8200, new List<string>{ "3"}),
            new DoctorDto("Janina", "Nowak", 8000, new List<string>{"1","6"}),
            new DoctorDto("Kamil", "Laszuk",9890, new List<string>{"1","4","2"}),
            new DoctorDto("Albert", "Kral", 9200, new List<string>{"5","7","2"}),
            new DoctorDto("Wanda", "Chalicka", 9500, new List<string>{"1","7"}),
            new DoctorDto("Marian", "Bam", 7000, new List<string>{"5","4"}),
            new DoctorDto("Konrad", "Wimek", 7000, new List<string> { "8" }),
            new DoctorDto("Anna", "Jarmin", 8000, new List<string> { "6", "4" }),
            new DoctorDto("Anna", "Astra", 8600, new List<string> { "7", "8" }),
            new DoctorDto("Jakub", "Wolkowski", 9600, new List<string> { "2", "7", "4" })
    };
        private static readonly List<Pair> goodPairs = new List<Pair>()
            {
                new Pair(new DoctorDto("Albert", "Kral", 9200, new List<string>{"5","7","2"}), new ExaminationRoomDto("03", new List<string>{"5", "7" })),
                new Pair(new DoctorDto("Jakub", "Wolkowski", 9600, new List<string> { "2", "7", "4" }), new ExaminationRoomDto("204a", new List<string>{ "4"})),
                new Pair(new DoctorDto("Wanda", "Chalicka", 9500, new List<string>{"1","7"}),new ExaminationRoomDto("203", new List<string>{ "1"})),
                new Pair(new DoctorDto("Marian", "Bam", 7000, new List<string>{"5","4"}),new ExaminationRoomDto("302", new List<string>{ "5", "4"})),
                new Pair(new DoctorDto("Konrad", "Wimek", 7000, new List<string> { "8" }),new ExaminationRoomDto("401", new List<string>{ "8", "1", "2"})),
                new Pair(new DoctorDto("Jan", "Kowalski", 8200, new List<string>{ "3"}), new ExaminationRoomDto("102", new List<string>{"3", "2"})),
                new Pair(new DoctorDto("Kamil", "Laszuk",9890, new List<string>{"1","4","2"}), new ExaminationRoomDto("403", new List<string>{"2", "4"})),
                new Pair( new DoctorDto("Janina", "Nowak", 8000, new List<string>{"1","6"}), new ExaminationRoomDto("402", new List<string>{"1"})),
                new Pair(new DoctorDto("Anna", "Jarmin", 8000, new List<string> { "6", "4" }),new ExaminationRoomDto("301", new List<string>{ "6", "5"})),
                new Pair(new DoctorDto("Anna", "Astra", 8600, new List<string> { "7", "8" }),new ExaminationRoomDto("201", new List<string>{ "9", "7", "8"}))
            };

        private static readonly List<ExaminationRoomDto> examinationRooms2 = new List<ExaminationRoomDto>
        {
            new ExaminationRoomDto("02", new List<string>{"1", "2"}),
            new ExaminationRoomDto("03", new List<string>{"5", "7" }),
            new ExaminationRoomDto("102", new List<string>{"3", "2"}),
            new ExaminationRoomDto("103", new List<string>{"2", "1", "5"}),
            new ExaminationRoomDto("104", new List<string>{"5"}),
            new ExaminationRoomDto("105a", new List<string>{ "12"}),
            new ExaminationRoomDto("202", new List<string>{"10", "1"}),
            new ExaminationRoomDto("203", new List<string>{ "1"}),
            new ExaminationRoomDto("204a", new List<string>{ "4"}),
            new ExaminationRoomDto("204b", new List<string>{ "7", "6"}),
            new ExaminationRoomDto("301", new List<string>{ "6", "5"}),
            new ExaminationRoomDto("302", new List<string>{ "5", "4"}),
        };

        private static readonly List<DoctorDto> doctors2 = new List<DoctorDto>()
        {
            new DoctorDto("Jan", "Kowalski", 8200, new List<string>{ "3"}),
            new DoctorDto("Albert", "Kral", 9200, new List<string>{"5","7","2"}),
            new DoctorDto("Wanda", "Chalicka", 9500, new List<string>{"1","7"}),
            new DoctorDto("Marian", "Bam", 7000, new List<string>{"5","4"}),
            new DoctorDto("Konrad", "Wimek", 7000, new List<string> { "8" }),
            new DoctorDto("Jakub", "Wolkowski", 9600, new List<string> { "2", "7", "4" })
        };
        private static readonly List<Pair> goodPairs2 = new List<Pair>()
            {
                new Pair(new DoctorDto("Albert", "Kral", 9200, new List<string>{"5","7","2"}), new ExaminationRoomDto("03", new List<string>{"5", "7" })),
                new Pair(new DoctorDto("Jakub", "Wolkowski", 9600, new List<string> { "2", "7", "4" }), new ExaminationRoomDto("204a", new List<string>{ "4"})),
                new Pair(new DoctorDto("Wanda", "Chalicka", 9500, new List<string>{"1","7"}),new ExaminationRoomDto("203", new List<string>{ "1"})),
                new Pair(new DoctorDto("Marian", "Bam", 7000, new List<string>{"5","4"}),new ExaminationRoomDto("302", new List<string>{ "5", "4"})),
                new Pair(new DoctorDto("Konrad", "Wimek", 7000, new List<string> { "8" }),new ExaminationRoomDto("105a", new List<string>{ "12"})),
                new Pair(new DoctorDto("Jan", "Kowalski", 8200, new List<string>{ "3"}), new ExaminationRoomDto("102", new List<string>{"3", "2"}))
            };
        private static readonly List<ExaminationRoomDto> examinationRooms3 = new List<ExaminationRoomDto>
        {
            new ExaminationRoomDto("01", new List<string>{"1"}),
            new ExaminationRoomDto("101", new List<string>{ "6", "4", "5"}),
            new ExaminationRoomDto("102", new List<string>{"3", "2"}),
            new ExaminationRoomDto("105a", new List<string>{ "12"}),
            new ExaminationRoomDto("105b", new List<string>{ "7", "6", "5"}),
            new ExaminationRoomDto("201", new List<string>{ "9", "7", "2"}),
            new ExaminationRoomDto("203", new List<string>{ "1", "6"}),
            new ExaminationRoomDto("204a", new List<string>{ "4"}),
            new ExaminationRoomDto("301", new List<string>{ "4", "5"}),
            new ExaminationRoomDto("401", new List<string>{ "8", "1", "2"}),
            new ExaminationRoomDto("402", new List<string>{"1"}),
        };

        private static readonly List<DoctorDto> doctors3 = new List<DoctorDto>()
        {
            new DoctorDto("Janina", "Nowak", 8000, new List<string>{"1","6"}),
            new DoctorDto("Albert", "Kral", 9200, new List<string>{"5","7","2"}),
            new DoctorDto("Marian", "Bam", 7000, new List<string>{"5","4"}),
            new DoctorDto("Konrad", "Wimek", 7000, new List<string> { "8" }),
            new DoctorDto("Anna", "Jarmin", 8000, new List<string> { "6", "4" }),
            new DoctorDto("Jakub", "Wolkowski", 9600, new List<string> { "2", "7", "4" })
    };
        private static readonly List<Pair> goodPairs3 = new List<Pair>()
            {
                new Pair(new DoctorDto("Albert", "Kral", 9200, new List<string>{"5","7","2"}), new ExaminationRoomDto("201", new List<string>{ "9", "7", "2"})),
                new Pair(new DoctorDto("Jakub", "Wolkowski", 9600, new List<string> { "2", "7", "4" }), new ExaminationRoomDto("204a", new List<string>{ "4"})),
                new Pair(new DoctorDto("Marian", "Bam", 7000, new List<string>{"5","4"}), new ExaminationRoomDto("301", new List<string>{ "4", "5"})),
                new Pair(new DoctorDto("Konrad", "Wimek", 7000, new List<string> { "8" }),new ExaminationRoomDto("401", new List<string>{ "8", "1", "2"})),
                new Pair(new DoctorDto("Janina", "Nowak", 8000, new List<string>{"1","6"}), new ExaminationRoomDto("203", new List<string>{ "1", "6"})),
                new Pair(new DoctorDto("Anna", "Jarmin", 8000, new List<string> { "6", "4" }), new ExaminationRoomDto("101", new List<string>{ "6", "4", "5"}))
            };

        private static readonly List<ExaminationRoomDto> examinationRoomsBig = new List<ExaminationRoomDto>()
        {
            new ExaminationRoomDto("01", new List<string>{"1"}),
            new ExaminationRoomDto("02", new List<string>{"1", "2"}),
            new ExaminationRoomDto("03", new List<string>{"5", "7" }),
            new ExaminationRoomDto("101", new List<string>{ "6", "3", "5"}),
            new ExaminationRoomDto("102", new List<string>{"3", "2"}),
            new ExaminationRoomDto("103", new List<string>{"2", "1", "5"}),
            new ExaminationRoomDto("104", new List<string>{"5"}),
            new ExaminationRoomDto("105a", new List<string>{ "12"}),
            new ExaminationRoomDto("105b", new List<string>{ "7", "6", "5"}),
            new ExaminationRoomDto("201", new List<string>{ "9", "7", "8"}),
            new ExaminationRoomDto("202", new List<string>{"10", "1"}),
            new ExaminationRoomDto("203", new List<string>{ "1"}),
            new ExaminationRoomDto("204a", new List<string>{ "4"}),
            new ExaminationRoomDto("204b", new List<string>{ "7", "6"}),
            new ExaminationRoomDto("301", new List<string>{ "6", "5"}),
            new ExaminationRoomDto("302", new List<string>{ "5", "4"}),
            new ExaminationRoomDto("303", new List<string>{ "5", "3"}),
            new ExaminationRoomDto("401", new List<string>{ "8", "1", "2"}),
            new ExaminationRoomDto("402", new List<string>{"1"}),
            new ExaminationRoomDto("403", new List<string>{"2", "4"})
        };

        private static readonly List<DoctorDto> doctorsBig = new List<DoctorDto>()
        {
            new DoctorDto("Jan", "Kowalski", 8200, new List<string>{ "3"}),
            new DoctorDto("Janina", "Nowak", 8000, new List<string>{"1","6"}),
            new DoctorDto("Kamil", "Laszuk",9890, new List<string>{"1","4","2"}),
            new DoctorDto("Albert", "Kral", 9200, new List<string>{"5","7","2"}),
            new DoctorDto("Wanda", "Chalicka", 9500, new List<string>{"1","7"}),
            new DoctorDto("Marian", "Bam", 7000, new List<string>{"5","4"}),
            new DoctorDto("Konrad", "Wimek", 7000, new List<string> { "8" }),
            new DoctorDto("Anna", "Jarmin", 8000, new List<string> { "6", "4" }),
            new DoctorDto("Anna", "Astra", 8600, new List<string> { "7", "8" }),
            new DoctorDto("Jakub", "Wolkowski", 9600, new List<string> { "2", "7", "4" }),
            new DoctorDto("Adolf", "D¹browski", 9800, new List<string>{ "1"}),
            new DoctorDto("Bo¿ydar", "Nowak", 7300, new List<string>{ "2"}),
            new DoctorDto("Lucyfer", "Warszawski", 5100, new List<string>{ "2","5"}),
            new DoctorDto("Maria", "Radomska", 4200, new List<string>{ "4","8"}),
            new DoctorDto("Agnieszka", "Bia³a", 12200, new List<string>{ "6","7"}),
            new DoctorDto("Alicja", "Polska", 9200, new List<string>{ "1","7","6"}),
            new DoctorDto("Janusz", "Sosnowski", 7200, new List<string>{ "4","5"}),
            new DoctorDto("Piotr", "M¹dry", 8500, new List<string>{ "12"}),
            new DoctorDto("Adam", "Wysoki", 8600, new List<string>{ "10","9"}),
            new DoctorDto("Marian", "Wolny", 8000, new List<string>{ "5","3","2","1"})
            };

        [TestMethod]
        public void TestDoctorsIsNotNull()
        {
            ExaminationRoomsSelectorQueryHandler handler = new ExaminationRoomsSelectorQueryHandler(examinationRoomsServiceClient, doctorsServiceClient);
            var doctors = new List<DoctorDto>();

            Action action = () => handler.PairRoomDoctor(doctors, examinationRooms);

            Assert.ThrowsException<ArgumentException>(action, "Should throw ArgumentException on empty DoctorDto list");
        }

        [TestMethod]
        public void TestRoomsIsNotNull()
        {
            ExaminationRoomsSelectorQueryHandler handler = new ExaminationRoomsSelectorQueryHandler(examinationRoomsServiceClient, doctorsServiceClient);
            var rooms = new List<ExaminationRoomDto>();
            Action action = () => handler.PairRoomDoctor(doctors, rooms);

            Assert.ThrowsException<ArgumentException>(action, "Should throw ArgumentException on empty rooms list");
        }

        [TestMethod]
        public void RunTestOneDoctorOneRoom()
        {
            TestOneDoctorOneRoom(doctors, examinationRooms);
            TestOneDoctorOneRoom(doctors2, examinationRooms2);
            TestOneDoctorOneRoom(doctors3, examinationRooms3);
        }

        
        public void TestOneDoctorOneRoom(List<DoctorDto> doctors, List<ExaminationRoomDto> examinationRooms)
        {
            ExaminationRoomsSelectorQueryHandler handler = new ExaminationRoomsSelectorQueryHandler(examinationRoomsServiceClient, doctorsServiceClient);
            var pairs = handler.PairRoomDoctor(doctors, examinationRooms);
            var docs = new List<DoctorDto>();
            var rooms = new List<ExaminationRoomDto>();
            foreach(var p in pairs)
            {
                docs.Add(p.doctor);
                rooms.Add(p.room);
            }

            Assert.AreEqual(docs.Count(), docs.Distinct().Count(), "Doctors count should be {0} and not {1}", docs.Count(), docs.Distinct().Count());
            Assert.AreEqual(rooms.Count(), rooms.Distinct().Count(), "Rooms count should be {0} and not {1}", rooms.Count(), rooms.Distinct().Count());

        }

        [TestMethod]
        public void RunNoMorePairs()
        {

            TestNoMorePairs(doctors, examinationRooms, goodPairs);
            TestNoMorePairs(doctors2, examinationRooms2, goodPairs2);
            TestNoMorePairs(doctors3, examinationRooms3, goodPairs3);
        }
        public void TestNoMorePairs(List<DoctorDto> doctors, List<ExaminationRoomDto> examinationRooms, List<Pair> goodPairs)
        {
            ExaminationRoomsSelectorQueryHandler handler = new ExaminationRoomsSelectorQueryHandler(examinationRoomsServiceClient, doctorsServiceClient);
            var pairs = handler.PairRoomDoctor(doctors, examinationRooms);
            

            bool correct = true;
            foreach(var p in goodPairs)
            {
                if (!goodPairs.Any(x => x.doctor.Surname == p.doctor.Surname &&  x.room.Number == p.room.Number))
                { 
                    correct = false;
                    break;
                }
            }
                
            Assert.AreEqual(true, correct, "Data mismatch");

        }

        [TestMethod]
        public void TestDurationTime()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ExaminationRoomsSelectorQueryHandler handler = new ExaminationRoomsSelectorQueryHandler(examinationRoomsServiceClient, doctorsServiceClient);
            var pairs = handler.PairRoomDoctor(doctorsBig, examinationRoomsBig);
            stopWatch.Stop();
            var elapsedMs = stopWatch.ElapsedMilliseconds;
            Assert.IsTrue(elapsedMs < 100, "Duration time of algorithm should be less than {0} not {1} ", 100, elapsedMs);
        }


        
    }
}
