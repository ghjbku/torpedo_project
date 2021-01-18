# Torpedo project for C# dev class

**Progress so far:**

![](https://cdn.discordapp.com/attachments/780127130003701790/798903063779737630/torpedo_gif.gif)

## Requirements::

# Torpedó játék
> .NET-es grafikus (WPF keretrendszerben írt) játék elkészítése.

### Játék leírása
[Magyar](https://hu.wikipedia.org/wiki/Torped%C3%B3_(j%C3%A1t%C3%A9k))

## Követelmények
- #### Egymás ellen lehessen játszani ugyanazon a gépen, ugyanabban az alkalmazásban :x:
- #### AI ellen lehessen játszani
    - Kezdő játékos véletlenszerűen választva :heavy_check_mark: 
    - AI elemezési sorrend :x:
        1. Random találgat :heavy_check_mark: 
        2. Ha van találat akkor már a mellette lévő mezőket lövi :heavy_check_mark: 
            - UNIT tesztet írni a logikához (randomhoz nem muszáj) :x:
- #### Játékmenet
    - Belépéskor kérjen nevet, majd ahhoz mentse az eredményeket :heavy_check_mark: 
    - Eredményjelző :heavy_check_mark: 
        - Körök száma :heavy_check_mark: 
        - Saját találatok :heavy_check_mark: 
        - Ellenfél találatai :heavy_check_mark: 
        - Milyen hajók vannak még és melyek lettek elsüllyesztve :heavy_check_mark: 
        - Billentyűkombinációra mutassa meg az AI hajóit (Csak AI ellen működjön) :heavy_check_mark: 
- #### Játék vége :heavy_check_mark: 
    - Tárolja le az eredményeket :heavy_check_mark: 
        - Adatok tárolása: JSON, XML vagy adatbázis :heavy_check_mark: 
    - Mindenkori eredménylista beolvasva tárolt adatokból (nyert - vesztett) :heavy_check_mark: 
