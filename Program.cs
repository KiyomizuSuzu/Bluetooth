// MAIN RUNTIME
using Windows.Devices.Radios;
//EXECUTION
class Program {
    static async Task Main(string[] args) {
        if (args.Length == 0) {
            Console.WriteLine("You didn't provide any arguements, please type /help to know how to use it properly.");
            return;
        }
        else {
            string command = args[0].ToLower().TrimStart('/');
            IReadOnlyList<Radio> radios = await Radio.GetRadiosAsync();
            bool DeviceNotFound = true;
            foreach (Radio device in radios) {
                bool findBluetooth = device.Kind == RadioKind.Bluetooth;
                if (findBluetooth) {
                    DeviceNotFound = false;
                    if (command == "off") {
                        bool bluetoothIsOn = device.State == RadioState.On;
                        if (bluetoothIsOn) {
                            try {
                                await device.SetStateAsync(RadioState.Off);
                                Console.WriteLine("Bluetooth successfully turned OFF");
                            }
                            catch (Exception ERROR) {
                                Console.WriteLine("Failed to turn off Bluetooth because " + ERROR.Message);
                            }
                        }
                        else {
                            Console.WriteLine("Bluetooth is already turned off.");
                        }
                    }
                    else if (command == "on") {
                        bool bluetoothIsOff = device.State == RadioState.Off;
                        if (bluetoothIsOff) {
                            try {
                                await device.SetStateAsync(RadioState.On);
                                Console.WriteLine("Bluetooth successfully turned ON");
                            }
                            catch (Exception ERROR) {
                                Console.WriteLine("Failed to turn on Bluetooth because " + ERROR.Message);
                            }
                        }
                        else {
                            Console.WriteLine("Bluetooth is already turned on.");
                        }
                    }
                    else if (command == "status") {
                        Console.WriteLine("Bluetooth state: " + device.State);
                    }
                    else if (command == "help") {
                        Console.WriteLine("Usage:");
                        Console.WriteLine("/on      - Turn Bluetooth ON");
                        Console.WriteLine("/off     - Turn Bluetooth OFF");
                        Console.WriteLine("/status  - Show Bluetooth state");
                        Console.WriteLine("/help    - List available commands that you can use");
                    }
                    else {
                        Console.WriteLine("Unknown command. Check your spelling or type /help for correction.");
                    }
                }
            }
            if (DeviceNotFound) {
                Console.WriteLine("No compatible bluetooth devices were found.");
            }
        }
    }
}