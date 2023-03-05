# CityInfo

.NET 6 WebAPI of a simple project to consume cities and their point of interests

I have attached what i what I learned during the implementation of this course exercice

What I learned:

	1. Enable Routing

For a WebAPI we should always activate routing by adding the Middleware:

	1. App.UseRouting() which should be added before the authentication middleware (app.UseAuthentication)
	2. App.UseRouting() match the URI request with the action (executable end points)
	3. Right after the authentication middleware, add the Endpoint middleware : 
	app.UseEndPoints(endpoint => endpoint.MapControllers());



	2. API Controllers creation
		
	• After creating a controller it should be tagged with 2 decorating attributes
	• [ApiController] And [Route("some/optional/Uri")] which will route to the controller from the URI request matching the "somewebapp.com/some/optional/Uri"
	• APIController decorating attribute can be applied to a controller class to enable more features than a standard controller would have such as: 
		○ Attribute routing requirement => new concept aside of conventional routing which is (controller/action/id), it is new and flexible routing type to solve the child resources requests, for instance cities can have multiple points of interest, and let's say we request a specific city's point of interest such as a city with an id: 1 and among all of its points of interest we get the point of interest with id: 1  also
		It can be translated to this :
		Attribute routing request : /cities/1/pointsofinterest/1
		
		○ Automatic http 400 response => some cases are implicitly validated by the [APIController] attribute such as empty data in the request, also adding Data Annotation to the model such as [MaxLength(100)] or [Required] is the only thing needed, with that being said, there is no need to verify if the model State is valid in the action with this code : if (!ModelState.IsValid) return BadRequest();.
		It's implicitly mapped thanks to [ApiController] Attribute, for the partial update of a resource (Patch) we do need to validate the model though after validating the jsonPatch
		
		○ Binding source parameter inference
		○ Multipart/form-data request inference
		○ Problem details for error status codes
		
	3. Manage requests in the WebAPI

	• Create a resource
		○ The action should be decorated with [HttpPost]
		○ The action should return ActionResult<ModelDto> and takes in param (ModelForCreationDto)
		○ After applying the validating Data Annotations to the ModelForCreationDto such as required [MaxLength(100)] or [Phone] etc… if the Post data matches the validation then we can:
			§ Persist the data
			§ Return a 201 Created response by returning the CreatedAtRoute() which takes in param the route name (name of the Get action),  route value, and content value (the object).
	Note 
	In order to prevent the consumer messing with the Id which is in most cases attributed automatically, we create a second Model class for a ModelDto called ModelForCreationDto which contains all the props of the Model except the unique key such as {Id}, either that or prevent the consumer to Post the Id as well, same thing goes for the update case.
	
	• Update resource
		○ The action should be decorated with [HttpPut("{modelId}")] the attribute HttpPut contains the variable modelId  which is the id of the object to update
		○ The action should return ActionResult and takes in param the model Id (int) as well as the object (ModelForUpdateDto)
		○ After the Model validation we can return an Ok() 201 response or a NoContent() 204
	
	• Patch resource
		○ The action should be decorated with [HttpPatch("{modelId}")] the attribute HttpPatch contains the variable modelId  which is the id of the object to patch
		○ The action should return ActionResult and takes in param the model Id (int) as well as the JsonPatch (JsonPatchDocument<ModelForUpdateDto>)
		○ In case you're wondering what's a JsonPatch, it's a standard format for describing changes to a JSON document, it can be used to avoid sending back the whole document when only a part has changed.
		○ Technical example: say we have name and description properties in our ModelDto and we only need to change the name only we can use the standard Json request for this property
			§ The Json request contains 2 to 3 metadata:
				□ Attribute 'op' which contains the operation ('rename',' remove'…)
				□ Attribute 'path' which contains the property name we're willing to update/remove…
				□ Attribute 'value' (when op is 'rename') which contains the value updated in case of update (rename)
		○ In .NET Core it is the JsonPatchDocument<T> which takes care of the Patch cases and for that install the 'Microsoft.AspNetCore.JsonPatch' and also 'Microsoft.AspNetCore.Mvc.NewtonsoftJson' which takes care of formatting the input and output of requests for JSON and JsonPatch
		
	• Delete resource
		○ The action should be decorated with [HttpDelete("{modelId}")] the attribute HttpDelete contains the variable modelId  which is the id of the object to remove
		○ After verifying the existence of the object we remove it and return NoContent() 204
		
	• Get resource
		○ The action should be decorated with [HttpGet("{modelId}")] the attribute HttpGet contains the variable modelId  which is the id of the object to find and Get
		○ The action should return ActionResult and takes in param the model Id (int)
		○ In case the object is not found then NotFound() ActionResult is returned (404) otherwise an Ok( _object) is returned (200)
		
		
![image](https://user-images.githubusercontent.com/122980259/222942267-45a423e3-abe5-4ed6-912c-6baf4c01e369.png)
