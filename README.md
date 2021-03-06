HarNet
======

HarNet is .NET Library for handling HTTP Archive files. The library is available as a NuGet package here: https://www.nuget.org/packages/HarNet/

HAR files can be created by browsers or browser extensions. HAR is a W3C-defined format (https://dvcs.w3.org/hg/webperf/raw-file/tip/specs/HAR/Overview.html) based on JSON. The format defines obligatory and optional parameters for each log.

This project aims to provide a free .NET library. This library relies on Newtonsoft.JSON for efficient data deserialization. Newtonsoft.JSON deserializes into basic data types (int, string and object). HarNet converts this to more complex types (ulong, float) as well as class implementations of the objects. A set of useful methods have also been added to many of the classes, making it easier to manipulate the data in those files.

Build Status
============

[![Build status](https://ci.appveyor.com/api/projects/status/dva0af0v986vj28a/branch/master?svg=true)](https://ci.appveyor.com/project/acastaner/harnet/branch/master)

License
=======

HarNet is released under GNU Lesser General Public License v3 (LGPL-3).
