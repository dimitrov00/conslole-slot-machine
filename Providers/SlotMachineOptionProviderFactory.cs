using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace SlotMachineProject.Providers;

public class SlotMachineOptionProviderFactory
{
    private readonly IReadOnlyDictionary<string, ISlotMachineOptionProvider> _slotMachineOptionProviders;

    public SlotMachineOptionProviderFactory(ISlotMachineState slotMachine)
    {
        ArgumentNullException.ThrowIfNull(slotMachine);

        var slotMachineOptionProviderType = typeof(ISlotMachineOptionProvider);
        _slotMachineOptionProviders = slotMachineOptionProviderType.Assembly.ExportedTypes
            .Where(x => slotMachineOptionProviderType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            .Select(x =>
            {
                var parameterLessCtor = x.GetConstructors().SingleOrDefault(c => c.GetParameters().Length == 0);
                return parameterLessCtor is not null
                    ? Activator.CreateInstance(x)
                    : Activator.CreateInstance(x, slotMachine);
            })
            .Cast<ISlotMachineOptionProvider>()
            .ToImmutableDictionary(k => k.OptionName, v => v);
    }

    public ISlotMachineOptionProvider GetOptionProvider(string optionName)
    {
        var provider = _slotMachineOptionProviders.GetValueOrDefault(optionName);
        if (provider is null)
        {
            throw new ArgumentException("No such option provided");
        }
        return provider;
    }
}