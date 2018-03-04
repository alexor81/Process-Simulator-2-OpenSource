# Process Simulator 2 Open Source

Open source code of Process Simulator 2  
Project's site: automation.ucoz.com  
YouTube channel: youtube.com/channel/UC0CQz6fu2gPb9jaKjqNk2RA

## Connections
* **Internal** - communication between objects inside application.
* **ModbusN** - modbus master for Ethernet and Serial port. Uses NModbus library (https://github.com/NModbus/NModbus).
* **MQTT** - MQTT client. Uses M2Mqtt library (https://m2mqtt.wordpress.com/).
* **OPC UA** - OPC UA client.
* **S7IsoTCP** - communication with Siemens SIMATIC PLC S7-300/400 and S7-1200/1500. Uses Snap7 library (http://snap7.sourceforge.net).
* **S7PLCSim** - communication with Siemens SIMATIC S7PLCSim V5.4.
* **S7PLCSimAdv2** - communication with Siemens SIMATIC S7PLCSim Advanced v2.

## Converters
* **Compare** - compare value with configured one and give the result of Boolean type.
* **FilterExp** - exponential filter.
* **Inverse** - invert value of Boolean type or array of this type.
* **Round** - round numeric value or all values in array.
* **Scale** - scale value using configured ranges.
* **ToBoolean** - convert two values (true/false) to Boolean value and backwards.
* **ToString** - convert any value to string and backward.

## Simulation objects
* **Animation.ImageMove** - image moving and rotating.
* **Binary.Counter** - count of positive and negative front of Boolean value.
* **Binary.Delay** - delay of positive and negative edge of Boolean value.
* **Binary.Logic** - logical operations: AND, OR, XOR, NOT, NAND, NOR, NXOR.
* **Binary.Trigger** - trigger logic.
* **Item.ArraySplitter** - splits Item with array to different Items by index.
* **Item.BitSplitter** - split bits of Item with real number value to different Items by index.
* **Item.Delay** - copy one Item value to another on command with adjustable delay.
* **Item.TimeLine** - write values to Items at intervals.
* **Item.WriteToFile** - write values to CSV file.
* **Pipeline.Pump** - pump simulation.
* **Pipeline.Valve** - valve actuator simulation.
* **Real.Calculator** - arithmetic operations with values: Add, Subtract, Multiply, Divide, Modulo, Power, Logarithm, Logarithm (natural), Logarithm (base 10), Exponent, Square root, Sine, Cosine, Tangent, Absolute, Round, Truncate.
* **Real.Comparator** - comparison of two values. Result is Boolean value.
* **Real.Generator** - signal generation: Sine, Square, Sawtooth, Random.
* **Real.Lag** - first order lag.
* **Real.OneOfTwo** - one value from two by boolean switch.
* **Real.Scale** - scale value using configured ranges.
* **Real.XYDependency** - define function Y=F(X) as array of points.
* **Robot.Conveyor** -  conveyor simulation.
* **Robot.SixAxis** - six-axis robot simulation. Can be connected to RoKiSim 1.7 for visualization (http://www.parallemic.org/RoKiSim.html).
* **Script.CSharp** - simple script using C# language.
* **Script.CSharpFSM** - Finite-state machine in C# language.
* **Sensor.Analog** - display and change of analog signal with scaling and thresholds.
* **Sensor.Discrete** - display and change of discrete signal.
* **Voice.Command** - recognize predefined phrase and writes corresponding value.

## Utils
