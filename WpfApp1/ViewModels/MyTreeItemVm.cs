﻿using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace WpfApp1.ViewModels;

public partial class MyTreeItemVm : ReactiveObject
{
    [Reactive] public string _name;
    [Reactive] private Guid _id;
    [Reactive] private bool _isExpanded;
    [Reactive] private bool _isSelected;

    public List<MyTreeItemVm> Children { get;  } = new();

    public MyTreeItemVm? Parent { get;  }

    private int Level { get; }
    
    public MyTreeItemVm(MyTreeItemVm? parent, int level, int pos)
    {
        Parent = parent;
        Id = Guid.NewGuid();
        Level = level;

        Name = parent != null ? $"{parent.Name}.{level}.{pos}" : $"Level {Level}";
        IsExpanded = false;
        IsSelected = false;

        // Create random children based on level
        if (level < 4)  // Create children for levels 0 through 3
        {
            var random = new Random();
            int childCount = level switch
            {
                1 => random.Next(6, 13),  // Level 1: 6-12 children
                2 => random.Next(3, 7),   // Level 2: 3-6 children
                3 => random.Next(3, 6),   // Level 3: 3-5 children
                4 => random.Next(1, 3),   // Level 4: 1-2 children
                _ => 0
            };

            for (int i = 0; i < childCount; i++)
            {
                Children.Add(new MyTreeItemVm(this, level + 1, i+1));
            }
        }
    }
}