# Dnn Web API Extended Filters/Attributes
This project extends some of the Attributes(mostly used by DNN service framework)  in order to reuse the DNN service framework based controllers for mobile applications by enabling JWT.

The request coming from DNN DesktopModules and Mobile applications need different sets of Auth filters/attributes and these attributes may conflict each other and could not be used on the same controller.

One bad way is to write the same controller again with different attributes, one for DesktopModules and other for Mobile applications.
Other way is to extend these attributes which can Authenticate the requests coming from both DesktopModules and Mobile applications, which is shown here.

#### Extended Attributes are : 

### 1. CustomModuleAuthorizeAttribute:
- Extends `DnnModuleAuthorizeAttribute`   
- Only the `SkipAuthorization` method is overrided, 
    which checks if the current request is JWT Authenticated then return true
    otherwise return the result of `SkipAuthorization` method of its base class ie.`DnnModuleAuthorizeAttribute`
### 2. CustomSupportedModulesAttribute:
- Extends `SupportedModulesAttribute`   
- Only the `SkipAuthorization` method is overrided, 
    which checks if the current request is JWT Authenticated then return true
    otherwise return the result of `SkipAuthorization` method of its base class     ie.`SupportedModulesAttribute`
### 3. CustomValidateAntiForgeryTokenAttribute:
- Extends `ValidateAntiForgeryTokenAttribute`   
- Only the `IsAuthorized` method is overrided, 
    which checks if the current request is JWT Authenticated then return true
    otherwise return the result of `SkipAuthorization` method of its base class     ie.`ValidateAntiForgeryTokenAttribute`
### 4. JwtAuthorizeAttribute:
- Extends `AuthorizeAttributeBase`
- It checks for JWT Authentication and Role Authorization.
- It skips the Authorization if No JWT Auth header present in the request and let other attributes handle the request.
    
CustomModuleAuthorizeAttribute, CustomSupportedModulesAttribute and CustomValidateAntiForgeryTokenAttribute skip their base class Authorization if the request successfully passed JWT Authentication.

