# Xml Any Object
This class offers a Serialization or Deserialization of any xml sequence at compile time, using recursively algorithm concept; this feature is able to transform a xml string to XmlAnyObject object or XmlAnyObject object to xml string.
Follow this example; I have one XML sequence like this:

```xml
<?xml version='1.0' encoding='UTF-8'?>
<Company att='teste'>
    <First>teste 1</First>
    <Second>teste 2</Second>
    <Third vvv='hello'>teste 3</Third>
    <FirstVarious>other test 1</FirstVarious>
</Company>
<Company>
    <First>novo teste 1</First>
    <Second bi='ttt'>novo teste 2</Second>
    <Third>novo teste 3</Third>
    <SecondVarious></SecondVarious>
    <ThirdVarious>other test 2</ThirdVarious>
</Company>
```

If do you want to consume this Xml above or multiples Xml without write [C# Data Transfer Object](https://www.codeproject.com/Articles/1050468/Data-Transfer-Object-Design-Pattern-in-Csharp) for each Xml, use XmlAnyObject , with a simple line:

```cs
string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
               <Company att=""teste"">
                   <First>teste 1</First>
                   <Second>teste 2</Second>
                   <Third vvv=""hello"">teste 3</Third>
                   <FirstVarious>other test 1</FirstVarious>
               </Company>
               <Company>
                   <First>novo teste 1</First>
                   <Second bi=""ttt"">novo teste 2</Second>
                   <Third>novo teste 3</Third>
                   <SecondVarious></SecondVarious>
                   <ThirdVarious>other test 2</ThirdVarious>
               </Company>";
               
XmlAnyObject anyObject = XmlAnyObject.Deserialize(xml);
```
From Visual Studio QuickWatch, the developer throw and navigate to object nodes generated with [dynamic type](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/dynamic) behavior, with the vantage to be executed at compile time:
![From: https://github.com/antonio-leonardo/XmlAnyObject](https://github.com/antonio-leonardo/XmlAnyObject/blob/master/vs-quickwatch-anyObject.png)

----------------------
## License

[View MIT license](https://github.com/antonio-leonardo/XmlAnyObject/blob/master/LICENSE)
