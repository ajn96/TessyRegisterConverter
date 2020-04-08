# Tessy Register Converter

This program converts a C header file which defines memory mapped registers on a microprocessor to a format usable by the [Tessy](https://www.razorcat.com/en/product-tessy.html) embedded unit testing framework.

For each register defined, a source variable to replace the register is created, which can be easily accessed in Tessy, and the define target is changed.

## Disclaimer

This software is governed by the MIT license agreement included in this repository. 

This software is not associated with Tessy or RazorCat - It is simply a helper library to facilitate using Tessy with embedded systems.