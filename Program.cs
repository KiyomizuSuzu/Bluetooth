// MAIN RUNTIME
using Windows.Devices.Radios;
//EXECUTION
class Program {
    static async Task Main(string[] args) {
        if (args.Length == 0) {
            Console.WriteLine("You didn't provide any arguments, please type /help to know how to use it properly.");
        }
        else {
            string command = args[0].ToLower().TrimStart('/');
            IReadOnlyList<Radio> radios = await Radio.GetRadiosAsync();
            Radio? bluetooth = radios.FirstOrDefault(device => device.Kind == RadioKind.Bluetooth);
            if (bluetooth is null) {
                Console.WriteLine("No compatible Bluetooth devices were found.");
                return;
            }
            else {
                switch (command) {
                    case "off":
                        if (bluetooth.State == RadioState.On) {
                            try {
                                await bluetooth.SetStateAsync(RadioState.Off);
                                Console.WriteLine("Bluetooth successfully turned OFF");
                            }
                            catch (Exception ERROR) {
                                Console.WriteLine("Failed to turn off Bluetooth because " + ERROR.Message);
                            }
                        }
                        else {
                            Console.WriteLine("Bluetooth is already turned off.");
                        }
                        break;
                    case "on":
                        if (bluetooth.State == RadioState.Off) {
                            try {
                                await bluetooth.SetStateAsync(RadioState.On);
                                Console.WriteLine("Bluetooth successfully turned ON");
                            }
                            catch (Exception ERROR) {
                                Console.WriteLine("Failed to turn on Bluetooth because " + ERROR.Message);
                            }
                        }
                        else {
                            Console.WriteLine("Bluetooth is already turned on.");
                        }
                        break;
                    case "status":
                        Console.WriteLine("Bluetooth state: " + bluetooth.State);
                        break;
                    case "help":
                        Console.WriteLine("Usage:");
                        Console.WriteLine("/on      - Turn Bluetooth ON");
                        Console.WriteLine("/off     - Turn Bluetooth OFF");
                        Console.WriteLine("/status  - Show Bluetooth state");
                        Console.WriteLine("/help    - List available commands");
                        break;
                    default:
                        Console.WriteLine("Unknown command. Check your spelling or type /help.");
                        break;
                }
            }
        }
    }
}