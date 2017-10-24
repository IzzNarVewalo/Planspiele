# Übersicht

Ein Projekt der TUM (Design und Umsetzung von Planspielen) im Wintersemester 2017/2018.  
Dabei entwickeln wir mithilfe eines [ShaRe Devices](https://remotelab.fe.up.pt/instrumented_devices/share.php) Ein Spiel für Rheumapatienten in Portugal.

# Für Artists

* Weil git nicht sehr gut mit großen Dateien klarkommt, und es für euch einfacher zu halten würde ich vorschlagen dass die [Assets hier](https://goo.gl/ynbDtW) hochgeladen werden, bei bedarf werden sie dann von (Level-)Designer, Codern oder sonst wem eingebunden.
  * noch ist der Ordner für alle Personen mit dem Link editierbar, wenn ihr wollt stell ich ein dass nur Leute auf der Whitelist den Ordner bearbeiten können.

# Für Coder

* Generell Empfehle ich für die Entwicklung [ReSharper](https://www.jetbrains.com/resharper/) zu benutzen, das man als Student kostenlos bekommt.  
* Falls es keinen wichtigen Grund gibt Unity zu Updaten, für das Projekt die Version 2017.2.0f3 (zzt. die aktuellste) verwenden.  
* Im nächsten Abschnitt ist vor allem der erste Punkt und sein Unterpunkt ist wichtig damit GitHub nicht meckert. Gerne können wir uns auch einen anderen Stil einigen, wichtig ist jedoch das alle den selben verwenden.  
* Lest euch bitte alle ein wie git funktioniert falls ihr es noch nicht könnt und coden wollt, wichtig ist auf jeden Fall die Reihenfolge (commit, pull, push) beizubehalten. bestenfalls wird jedes Feature auf einem eigenen Branch entwickelt.  
* Ich würde mich persönlich freuen wenn wir so wenig Assets wie möglich aus dem AssetStore benutzen können.


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
