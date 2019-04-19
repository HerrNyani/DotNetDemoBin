Periodic PropertyBinding update implemented with an attached Behavior
=====================================================================

Periodically update the target of a bound control. Can be used if a class cannot implement the `INotifyPropertyChanged` interface.

Keystones
---------
* PeriodicPropertyBindingUpdateBehavior: Calls `UpdateTarget()` on the binding every time the internal timer ticks.


Acquiring the System.Windows.Interactivity DLL
----------------------------------------------
The PeriodicPropertyBindingUpdateBehavior extends from [`System.Windows.Interactivity.Behavior<DependencyObject>`](https://docs.microsoft.com/en-us/previous-versions/visualstudio/design-tools/expression-studio-4/ff726531(v%3Dexpression.40)), 
which is defined in the *System.Windows.Interactivity* DLL.
To get the DLL, open the NuGet browser and search for the [**System.Windows.Interactivity.WPF** package](https://www.nuget.org/packages/System.Windows.Interactivity.WPF/) and install it.


Using a Behavior in WPF
-----------------------
First, add a reference to the Interactivity DLL in XAML:
```xaml
xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
```

Then attach the Behavior using the `Interaction.Behaviors` tag:
```xaml
<Run Text="{Binding NowDateTime, Mode=OneWay, FallbackValue='not available.'}">
	<i:Interaction.Behaviors>
		<behaviors:PeriodicPropertyBindingUpdateBehavior Interval="0:00:01" PropertyToUpdate="{x:Static Run.TextProperty}" />
	</i:Interaction.Behaviors>
</Run>
```
