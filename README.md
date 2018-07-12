# Dnn Web API Extended Filters/Attributes
This project extends some of the Attributes(mostly used by DNN service framework)  in order to reuse the DNN service framework based controllers for mobile applications by enabling JWT.

The request coming from DNN DesktopModules and Mobile applications need different sets of Auth filters/attributes and these attributes may conflict each other and could not be used on the same controller.

One way is to write the duplicate controllers for mobile applications with different attributes but this will make the controller class difficult to maintain.
In this project, a `TestController` with extended attributes authenticates the requests coming from both DesktopModules and Mobile applications.

#### Extended Attributes are : 

### 1. CustomModuleAuthorizeAttribute:
- Extends `DnnModuleAuthorizeAttribute`   
- Only the `SkipAuthorization` method is overridden, 
    which checks if the current request is JWT Authenticated then return true
    otherwise return the result of `SkipAuthorization` method of its base class ie.`DnnModuleAuthorizeAttribute`
### 2. CustomSupportedModulesAttribute:
- Extends `SupportedModulesAttribute`   
- Only the `SkipAuthorization` method is overridden, 
    which checks if the current request is JWT Authenticated then return true
    otherwise return the result of `SkipAuthorization` method of its base class     ie.`SupportedModulesAttribute`
### 3. CustomValidateAntiForgeryTokenAttribute:
- Extends `ValidateAntiForgeryTokenAttribute`   
- Only the `IsAuthorized` method is overridden, 
    which checks if the current request is JWT Authenticated then return true
    otherwise return the result of `SkipAuthorization` method of its base class     ie.`ValidateAntiForgeryTokenAttribute`
### 4. JwtAuthorizeAttribute:
- Extends `AuthorizeAttributeBase`
- It checks for JWT Authentication and Role Authorization.
- It skips the Authorization if No JWT Auth header present in the request and let other attributes handle the request.
    
CustomModuleAuthorizeAttribute, CustomSupportedModulesAttribute and CustomValidateAntiForgeryTokenAttribute skip their base class Authorization if the request successfully passed JWT Authentication.

