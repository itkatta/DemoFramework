## Framework Install Instructions

 1. Clone the repository in Visual studio.
 2. Go to **Test** &#8594; select **Configure run settings** &#8594; click on **Select solution wide settings file** &#8594; Select **Test.runsettings** file from root folder.
 3. Build **"Framework.sln"**.
 4. Tests are in **Framework.Test** project.
  5. Range values for variance are mentioned in **Test.runsettings** file
```
    <Parameter name="WebAppUrl" value="https://www.accuweather.com/" />
    <Parameter name="ApiBaseUri" value="api.openweathermap.org" />
    <Parameter name="AppId" value="7fe67bf08c80ded756e598d6f8fedaea" />
    <Parameter name="TempMin" value="0" />
    <Parameter name="TempMax" value="1" />
    <Parameter name="WindMin" value="0" />
    <Parameter name="WindMax" value="1" />
    <Parameter name="PressureMin" value="0" />
    <Parameter name="PressureMax" value="1" />
    <Parameter name="CloudMin" value="0" />
    <Parameter name="CloudMax" value="1" />
    <Parameter name="VisibilityMin" value="0" />
    <Parameter name="VisibilityMax" value="1" />
    <Parameter name="HumidityMin" value="0" />
    <Parameter name="HumidityMax" value="1" /> 
```
 
