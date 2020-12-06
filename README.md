# Torpedo project for C# dev class

**Progress so far:**

![](https://i.gyazo.com/d2521a641b9fab935c5b5cb9b63b9a9d.gif)

## Requirements::

# Torpedó játék
> .NET-es grafikus (WPF keretrendszerben írt) játék elkészítése.

### Játék leírása
[Magyar](https://hu.wikipedia.org/wiki/Torped%C3%B3_(j%C3%A1t%C3%A9k))

## Követelmények
- #### Egymás ellen lehessen játszani ugyanazon a gépen, ugyanabban az alkalmazásban
- #### AI ellen lehessen játszani
    - Kezdő játékos véletlenszerűen választva
    - AI elemezési sorrend
        1. Random találgat
        2. Ha van találat akkor már a mellette lévő mezőket lövi
            - UNIT tesztet írni a logikához (randomhoz nem muszáj)
- #### Játékmenet
    - Belépéskor kérjen nevet, majd ahhoz mentse az eredményeket
    - Eredményjelző
        - Körök száma
        - Saját találatok
        - Ellenfél találatai
        - Milyen hajók vannak még és melyek lettek elsüllyesztve
        - Billentyűkombinációra mutassa meg az AI hajóit (Csak AI ellen működjön)
- #### Játék vége
    - Tárolja le az eredményeket
        - Adatok tárolása: JSON, XML vagy adatbázis
    - Mindenkori eredménylista beolvasva tárolt adatokból (nyert - vesztett)
