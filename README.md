# Process Simulator 2 Open Source

Open source code of Process Simulator 2
http://automation.ucoz.com/

## Connections
* **Internal** - communication between objects inside application.
* **ModbusN** - modbus master for Ethernet and Serial port. Uses NModbus library (https://github.com/NModbus/NModbus).
* **MQTT** - MQTT client. Uses M2Mqtt library (https://m2mqtt.wordpress.com/).
* **OPC UA** - OPC UA client.
* **S7IsoTCP** - communication with Siemens SIMATIC PLC S7-300/400 and S7-1200/1500. Uses Snap7 library (http://snap7.sourceforge.net).
* **S7PLCSim** - communication with Siemens SIMATIC S7PLCSim V5.4.
* **S7PLCSimAdv2** - communication with Siemens SIMATIC S7PLCSim Advanced v2.

## Converters
* **Compare** - compares value with configured one and give the result of Boolean type.
* **FilterExp** - exponential filter.
* **Inverse** - inverts value of Boolean type or array of this type.
* **Round** - rounds numeric value or all values in array.
* **Scale** - scales value using configured ranges.
* **ToBoolean** - converts two values (true/false) to Boolean value and backwards.
* **ToString** - converts any value to string and backward.

## Simulation objects
* **Animation.ImageMove**
* **Binary.Counter**
* **Binary.Delay**
* **Binary.Logic**
* **Binary.Trigger**
* **Item.ArraySplitter**
* **Item.BitSplitter**
* **Item.Delay**
* **Item.TimeLine**
* **Item.WriteToFile**
* **Pipeline.Pump**
* **Pipeline.Valve**
* **Real.Calculator**
* **Real.Comparator**
* **Real.Generator** - for signal generation: Sine, Square, Sawtooth, Random.
* **Real.Lag** - first order lag.
* **Real.OneOfTwo** - select one value from two by boolean switch.
* **Real.Scale** - scales value using configured ranges.
* **Real.XYDependency** - defines function Y=F(X) as array of points.
* **Robot.Conveyor** -  for conveyor imitating.
* **Robot.SixAxis** - for six-axis robot imitating. Can be connected to RoKiSim 1.7 for visualization (http://www.parallemic.org/RoKiSim.html).
* **Script.CSharp** - for writing simple script using C# language.
* **Script.CSharpFSM** - for creating Finite-state machine in C# language.
* **Sensor.Analog** - for display and change of analog signal with scaling and thresholds.
* **Sensor.Discrete** - for display and change of discrete signal.
* **Voice.Command** - recognizes predefined phrase and writes corresponding value.

## Utils
