//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace ZsutPw.Patterns.WindowsApplication.Model
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  public class FakeNetworkClient : INetwork
  {
        private static List<Pair> pairs = new List<Pair>()
           /* {
                new Pair(new DoctorDto("Albert", "Kral", 9200, new List<string>{"5","7","2"}), new ExaminationRoomDto("03", new List<int>{5,7 })),
                new Pair(new DoctorDto("Jakub", "Wolkowski", 9600, new List<string> { "2", "7", "4" }), new ExaminationRoomDto("204a", new List<int>{4})),
                new Pair(new DoctorDto("Wanda", "Chalicka", 9500, new List<string>{"1","7"}),new ExaminationRoomDto("203", new List<int>{1})),
                new Pair(new DoctorDto("Marian", "Bam", 7000, new List<string>{"5","4"}),new ExaminationRoomDto("302", new List<int>{ 5,4})),
                new Pair(new DoctorDto("Konrad", "Wimek", 7000, new List<string> { "8" }),new ExaminationRoomDto("401", new List<int>{ 8,1,2})),
                new Pair(new DoctorDto("Jan", "Kowalski", 8200, new List<string>{ "3"}), new ExaminationRoomDto("102", new List<int>{3,2})),
                new Pair(new DoctorDto("Kamil", "Laszuk",9890, new List<string>{"1","4","2"}), new ExaminationRoomDto("403", new List<int>{2,4})),
                new Pair( new DoctorDto("Janina", "Nowak", 8000, new List<string>{"1","6"}), new ExaminationRoomDto("402", new List<int>{1})),
                new Pair(new DoctorDto("Anna", "Jarmin", 8000, new List<string> { "6", "4" }),new ExaminationRoomDto("301", new List<int>{6,5})),
                new Pair(new DoctorDto("Anna", "Astra", 8600, new List<string> { "7", "8" }),new ExaminationRoomDto("201", new List<int>{9,7,8}))
            }*/;

        public List<Pair> GetPairs()
    {
      return FakeNetworkClient.pairs;
    }
  }
}
