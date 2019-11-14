# JB_SWResupplyCalculation

## Background:
As part of this code challenge you will be using an API available here: https://swapi.co/  

We want to know for all SW star ships, to cover a given distance, how many stops for resupply are required.

The application will take as input a distance in mega lights (MGLT).

The output should be a collection of all the star ships and the total amount of stops required to make the distance between the planets.

All other application details are at your own discretion.

Sample output for 1000000 input:
Y-wing: 74
Millennium Falcon: 9
Rebel Transport: 11

NOTE: The console application can be created in any language you wish to use (not limited to .NET
languages).

## Requirements
1) The completed code should be submitted along with
2) Accompanying documentation
3) Tests and instructions on the usage of the application.

If there are any queries on the challenge I can be contacted for clarification if necessary.

All aspects of the challenge will be considered during the review, coding style, code organization,
correct calculations, working application etc.

This is a very important part of the interview process and they like our candidates to put their best
code forward.

## Instructions to use the Console Application
When program is executed, the user will be prompted to inform the distance in MegaLights for calculation.

Once received a correct input (numeric only and greater than 0), the program will do all the processing and present the response to the user with all the Starship names and the respective amount of resupply stops required for the journey. 


## Code documentation
Project is divided and 4 projects:

### 1. JB_SWResupplyCalculationConsole
This is the Console Application Project.

#### JB_SWResupplyCalculationConsole/Program.cs
Contains the interface for the user to prompt the distance and where it displays the results.

### 2. JB_SWResupplyCalculationCore
This is the Core project.

#### JB_SWResupplyCalculationCore/Entities/StarshipOverride.cs
Contains the new StartShipOverride object to store the new values calculated.

#### JB_SWResupplyCalculationCore/Helpers/SharpTrooperHelper.cs
Method to retrieve the data. Loops through all the pages and return a List of objects.

#### JB_SWResupplyCalculationCore/Calculations.cs
It's the main class, get called by the Console Application and interacts with the Helpers. Also does the validation on the data.

#### JB_SWResupplyCalculationCore/TimeFrames.cs
Class to standardize time frames available.

### 3. JB_SWResupplyCalculationUnitTests
Contains the Unit Tests created to validate that the calculations are correct. Also check for a few possibly bad data scenarios. 

#### JB_SWResupplyCalculationUnitTests/ResupplyTests.cs 
Contains the test cases.

### 4. SharpTrooper
The code is a copy from the the C# Helper available here: https://github.com/olcay/SharpTrooper

This project contains all the helpers and entities necessary to make the connection to the API.

Ideally that code should be packed and only referenced on the Solution as an Assembly using a nuget packet or similar, but hence that is not available, for the purpose of this exercise, the whole code was copied and re-compiled.
