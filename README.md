# Planspiele

Ein Projekt der TUM (Design und Umsetzung von Planspielen) im Wintersemester 2017/2018.  
Dabei entwickeln wir mithilfe eines [ShaRe Devices](https://remotelab.fe.up.pt/instrumented_devices/share.php) Ein Spiel für Rheumapatienten in Portugal.

# C# guidelines

* Als Einrückstil bitte [K&R 1TBS](https://en.wikipedia.org/wiki/Indentation_style#Variant:_1TBS_.28OTBS.29)
   * Falls ihr Visual Studio benutzt, bitte unter Extras/Optionen [diese Einstellungen](https://imgur.com/a/7IUc1) verwenden 
* Funktionen in `PascalCase`
* Konstanten in `ALL_CAPS`
* private variables in `_camelCaseWithUnderscore`
* public properties mit getters/setters in `PascalCase`
* Zugriff auf public variables über getters/setters
* statt Regionen lieber mehrere Classes erstellen
* anstatt von großen switches oder langen if/else statements dictionaries benutzen
* Namen von boolean variables sollten einen Präfix haben `(is/can/should)`
* Ternäre Operatoren wenn möglich vermeiden (hässlich/unübersichtlich) `condition ? option1 : option2`
* Interpolierte strings mit logik sind auch nicht sehr schön `Debug.Log($"When {condition} is true, {condition ? "it`s true!" : "It`s False"}");`


Generell Empfehle ich für die Entwicklung [ReSharper](https://www.jetbrains.com/resharper/) zu benutzen, das man als Student kostenlos bekommt.  
Vor allem der erste Punkt und Unterpunkt ist wichtig damit Github nicht meckert. Gerne können wir uns auch einen anderen Stil einigen, wichtig ist jedoch das alle den selben verwenden.
