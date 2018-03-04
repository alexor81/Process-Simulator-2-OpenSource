# Process Simulator 2 Open Source

Open source code of Process Simulator 2
http://automation.ucoz.com/

## Connections
* **Internal** - communication between objects inside application.
* **ModbusN** - modbus master for Ethernet and Serial port. Use NModbus library (https://github.com/NModbus/NModbus).
* **MQTT** - MQTT client. Use M2Mqtt library (https://m2mqtt.wordpress.com/).
* **OPC UA** - OPC UA client.
* **S7IsoTCP** - communication with Siemens SIMATIC PLC S7-300/400 and S7-1200/1500. Use Snap7 library (http://snap7.sourceforge.net).
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
* **Real.Generator**
* **Real.Lag**
* **Real.OneOfTwo**
* **Real.Scale**
* **Real.XYDependency**
* **Robot.Conveyor**
* **Robot.SixAxis**
* **Script.CSharp**
* **Script.CSharpFSM**
* **Sensor.Analog**
* **Sensor.Discrete**
* **Voice.Command**

## Utils
