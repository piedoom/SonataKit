# SonataKit
API and scaper for the gameStar Sonata 2.  Portable class library for UWP applications and Windows 10.

# Setting Up
Clone the repository and reference the project in your UWP application

# Using the wrapper
Currently, the Galaxy API wrapper is working.

## Galaxy Wrapper

SonataKit operates by utilizing the static `Client` class to interface with endpoints.

To get a list of galaxies, we simply need to call a method in our Client class.  
This is done asynchronously, so make sure your calling an async method so you can properly await the response.

```
List<Galaxy> universe = await SonataKit.Client.BuildUniverse();
```

Now that we have a `List` of galaxies in the variable `universe`, we can access that Galaxy's properties.

The full meaning of each property can be found [http://wiki2.starsonata.com/index.php/APIs_and_data_end_points](here), however most properties are self-explainatory.

If we wanted to get the name of each `Galaxy`, we could do the following.

```
foreach (Galaxy galaxy in universe){
	Debug.WriteLine(galaxy.Name);
}
```