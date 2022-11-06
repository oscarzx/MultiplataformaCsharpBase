using StoreDTOs;
using StoresApiClient.RestServices;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiStoresApp.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly BranchRestService _branchRestService;
    public MainViewModel(BranchRestService branchRestService)
    {
        _branchRestService = branchRestService;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string name = "")
        => PropertyChanged?.Invoke(this, new(name));

    private bool isBusy;

    public bool IsBusy
    {
        get => isBusy;

        set {
            isBusy = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<BranchDTO> branches;
    

    public ObservableCollection<BranchDTO> Branches
    {
        get => branches;

        set
        {
            branches = value;
            OnPropertyChanged();
        }
    }

    public Command LoadCommand => new Command(async () => await LoadBranches());

    private async Task LoadBranches()
    {
        IsBusy = true;

        var branchResponse = await _branchRestService.GetAll();

        if (branchResponse.ResponseStatus == StoresApiClient.Enums.ResponseStatus.Success)
            Branches = new(branchResponse.Response);

        IsBusy = false;
    }
}
