HarNet
======

HarNet is .NET Library for handling HTTP Archive files. 

HAR files can be created by browsers or browser extensions. HAR is a W3C-defined format (https://dvcs.w3.org/hg/webperf/raw-file/tip/specs/HAR/Overview.html) based on JSON. The format defines obligatory and optional parameters for each log.

This project aims to provide a free .NET library. This library relies on Newtonsoft.JSON for efficient data deserialization. Newtonsoft.JSON deserializes into basic data types (int, string and object). HarNet converts this to more complex types (ulong, float) as well as class implementations of the objects. A set of useful methods have also been added to many of the classes, making it easier to manipulate the data in those files.

License
=======

HarNet is released under GNU Lesser General Public License v2.1 (LGPL-2.1). Please refer to the LICENSE file for more details. For a short version of the license, go to: https://tldrlegal.com/license/gnu-lesser-general-public-license-v2.1-(lgpl-2.1)
