**EFCore2 DDD Simple Patterns**

This code goes with my Sept 2017 MSDN Mag Data Points column about EF Core 2.0 features that help you build code using patterns from Domain-Driven Design. 


* Better support for one:one mappings 
* Support for value objects
 * Totally new support for backing fields  
 * and better encapsulation.  

The patterns are shown individually so you can comprehend what's happening in the domain classes and EF's DbContext.

In the PersonName value object type, note that EF Core *requires* that these fields be non-null, so I've added "empty" logic to hep accommodate for that.

This .NET Core Console app uses Sqlite and was built on a Mac with VS Code. But you can use it on Windows as well whether you're in VS Code or VS 2017. Or on Linux with VS Code. Oh this cross platform world makes sharing so much easier!

The master branch currently aligns with the "Simpler Patterns" branch.  

In the Advanced branch (which I'll discuss in another column, possibly October 2017) you can see these concepts combined, e.g. encapsulating the related and value object properties in the aggregate root.  

Additional concepts like unconventional foreign key and backing field names are included in the Advanced branch as well. I also add in a ShadowProperty and update that on SaveChanges. There you'll also see the additional mappings needed in the DbContext to ensure that EF Core is still able to interact with them. 