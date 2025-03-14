﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using AgilePoker.Client.ViewModels;

namespace AgilePoker.Client.Components;

public abstract class ComponentBase<TViewModel> : ComponentBase
    where TViewModel : ViewModelBase
{
    [Inject]
    [NotNull]
#pragma warning disable CS8618
    protected TViewModel ViewModel { get; set; }
#pragma warning restore CS8618

    protected override void OnInitialized()
    {
        ViewModel.PropertyChanged += (_, _) => StateHasChanged();
        base.OnInitialized();
    }

    protected override Task OnAfterRenderAsync(bool firstRender)
        => base.OnAfterRenderAsync(firstRender);

    protected override Task OnInitializedAsync()
        => ViewModel.OnInitializedAsync();
}
