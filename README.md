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

# Project policies

* Zeilenlänge nicht größer als 120 Zeichen (haltet euch einfach an die Linie im Editor).
* Pull requests erst mergen wenn das Projekt auch kompiliert.
* Dateien und Ordner bitte in `PascalCase`.
* Den Code so einfach und und klar wie möglich halten (selbsterklärend).
* Jedes Feature sollte bestenfalls seinen eigenen branch haben.
* Lieber kleinere und dafür öftere commits machen als ein riesen commit.
* Falls man Hilfe braucht lieber früher nachfragen anstatt zu viel Zeit zu verschwenden indem man selber ewig rumprobiert.
* commit messages sinnvoll gestalten (anders als bei der README...)
* Pull requests machen sobald ein feature fertig ist.
    * statt einem riesen request mit X features, pro feature ein pull request.

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

# How to use git shell 
1. Aktuellste version vom master branch pullen
    * `git fetch -p`
    * `git pull origin master`
2. Checkout zu einem neuen branch (ein branch pro feature)
    * `git checkout -b <branch_name>`
3. Das feature coden und committen
    * `git status` - Zeigt die veränderten Dateien an
    * `git add <filename>` - fügt Dateien dem commit hinzu
    * `git add -u` - fügt alle veränderten Dateien dem commit hinzu
    * `git add -A` - fügt alle Dateien im Ordner hinzu die noch nicht im commit sind
    * `git commit -m "<commit message>"` -erstelle den commit  
(Schritt 3 so oft wiederholen bis das feature fertig ist)  
4. Push zu github
    * `git push origin <branch_name>`
5. erstelle pull request
    * `git pull-request`
6. Checkout zum masterbranch
    * `git checkout master`
7. Für jedes feature wiederholen
