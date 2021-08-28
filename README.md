# api_script
C# API Script to pull dog facts from a public Flask API Server.</br>
This code was my very first attempt at learning how to use C# from a very Python centric development background in order to try something new and broaden my horizons!</br>
(Many thanks to https://github.com/DukeNgn and https://dukengn.github.io/Dog-facts-API/ for running a Python Flask server publically for development testing!)</br>

## Disclaimer
Feel free for anyone to copy / use this in any way as part of educational learning only!</br>

## How to use
cd C#_code<br>
dotnet restore .<br>
dotnet run .<br>

This code runs on dotnet version 5.0.302.</br>
Download from the offical Microsoft website: https://dotnet.microsoft.com/download/dotnet/5.0

## How this code works
This code in essence does the following things:

- Sets up a logger with a custom format using Serilog
- Splits the URL into URL + URI parts and sets them both
- Generates a random number within a method and returns the newly created random number
- Adds the random number onto the end of the URI
- Passes both the URL and URI to the Send Request method in which it trys / catches on sending a JSON request and returns the response
- Sets up custom JSON decoding options and deserialises the JSON response from the public API
- Pulls out the "dog fact" out of the JSON in a for each (to allow extending to pulling in a list of facts rather than a single one)
- Logs the output to the terminal / console using the custom logger format
