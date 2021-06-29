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

namespace ZsutPw.Patterns.Application.Model
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public partial class Model : IData
  {
        public List<Pair> PairList
        {
            get { return this.pairList; }
            private set
            {
                this.pairList = value;

                this.RaisePropertyChanged("PairList");
            }
        }
        private List<Pair> pairList = new List<Pair>();

        public Pair SelectedPair
        {
            get { return this.selectedPair; }
            set
            {
                this.selectedPair = value;

                this.RaisePropertyChanged("SelectedPair");
            }
        }
        private Pair selectedPair;
    }
}
