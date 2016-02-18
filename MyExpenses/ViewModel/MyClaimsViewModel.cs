using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.ViewModel
{
  public  class MyClaimsViewModel:ViewModelBase
    {
   private   ObservableCollection<ClaimHeadersDT> _listClaimHeadersDTDraft { set; get; }

      public ObservableCollection<ClaimHeadersDT> ListClaimHeadersDTDraft
      {
          set
          {
              _listClaimHeadersDTDraft = value;
              RaisePropertyChanged("ListClaimHeadersDTDraft");
          }
          get
          {
              return _listClaimHeadersDTDraft;
          }
      }

      private ObservableCollection<ClaimHeadersDT> _listClaimHeadersDTSubmitted { set; get; }

      public ObservableCollection<ClaimHeadersDT> ListClaimHeadersDTSubmitted
      {
          set
          {
              _listClaimHeadersDTSubmitted = value;
              RaisePropertyChanged("ListClaimHeadersDTSubmitted");
          }
          get
          {
              return _listClaimHeadersDTSubmitted;
          }
      }

      private ObservableCollection<ClaimHeadersDT> _listClaimHeadersDTCompleted { set; get; }

      public ObservableCollection<ClaimHeadersDT> ListClaimHeadersDTCompleted
      {
          set
          {
              _listClaimHeadersDTCompleted = value;
              RaisePropertyChanged("ListClaimHeadersDTCompleted");
          }
          get
          {
              return _listClaimHeadersDTCompleted;
          }
      }

      public List<ClaimHeadersDT> ListClaimHeadersDT { set; get; }

      public ObservableCollection<MyExpenses.ResponseParsers.AuthClaims.AuthClaimHeadersDT> _ListAuthClaimHeadersDT { set; get; }
      public ObservableCollection<MyExpenses.ResponseParsers.AuthClaims.AuthClaimHeadersDT> ListAuthClaimHeadersDT
      {
          set
          {
              _ListAuthClaimHeadersDT = value;
              RaisePropertyChanged("ListAuthClaimHeadersDT");
          }
          get
          {
              return _ListAuthClaimHeadersDT;
          }
      }

 
    }
}
