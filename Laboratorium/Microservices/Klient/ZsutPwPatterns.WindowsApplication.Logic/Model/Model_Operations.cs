﻿//===============================================================================
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
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public partial class Model : IOperations
  {
    public void LoadPairList( )
    {
      /* AT
      this.LoadNodesTask( );
      */
      Task.Run( ( ) => this.LoadPairsTask( ) );
    }

    private void LoadPairsTask( )
    {
      INetwork networkClient = NetworkClientFactory.GetNetworkClient( );

      try
      {
        List<Pair> pairs = networkClient.GetPairs();

        this.PairList = pairs;
      }
      catch( Exception )
      {
      }
    }
  }
}
