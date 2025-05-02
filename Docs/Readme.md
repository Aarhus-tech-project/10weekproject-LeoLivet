#  Case Beskrivelse

## En ide ud af mange om fremtidens "telefoner" 
---
i denne case er min ummiddelbare tanke at prøve at give et lille blik i hvordan at man kan bruge teknologi og AR i sin hverdag.
Indtil at teknologien til selve headsettet kommer ned til et alle mands niveau ser jeg det her mest som et proof of concept hvor at man måske bare tager et headset på eller bruger sin telefon til at se med.
## Hvilket behov skal det opfylde?
---
Bekæmpe madspild ved at kunne se og holde styr på fødevarer der er i huset ved at:
	- prioritere mad der er ved at være for gammelt
	- hjælpe med at se kalorier og energi i ens mad.
	- Ud fra det man har i køkkenet lave en ret ud fra det man har i køkkenet.



## Hvordan det kunne bygges videre på i fremtiden.
---
### Blinde hjælp
man kunne bruge headsettet til at hjælpe svagtseende/blinde mennesker ved at bruge AI til at fortælle om hvad man ser lige nu. Dette har [Be My Eyes](https://www.bemyeyes.com/) allerede godt i gang med både ved hjælp af mennesker men også ai som kan hjælpe med at "se" fra ens øjne ved bare at spørge, istedet for at skulle hive sin telefon frem af lommen og åbne en app.

### Inventory management

Uoverskueligt rod hvor at man ikke ved hvor at man skal starte.

Jeg har personligt selv et stort uoverskueligt rod i min kælder og har også flere gange set andre nikke genkendene til det når jeg snakker om det. 
Derfor kunne en fremtidig ide at bygge videre på at kunne "scanne" ens rod og få en liste af hvilke ting og hvor mange at man har.
Siden at vi allerede er i unity kunne man tage hele listen af ens ting og så gå i VR hvor at de findes i 3D og man kan lave sig et overblik over hvad at man har af ting og sortere med noget gamification.

# Need to have
---
- Database CRUD
- Object recogniton
- LLM af en art for at kunne se med "bedre" øjne end f.eks en lille trænet neural engine i  unity syntis.


# Nice to have
---
- Få de fleste funktioner til at køre lokalt på headsettet (LLM ok fra server).
- At kunne genkende og tilføje flere ting end køkken relaterede ting.

- Gamification af at overholde bedst før datoer.

# MVP
---
Object genkendelse og optælling med simpel CRUD til en database. 


# Timeline
---

|         | Opgaver                       |     |     |     |     |     |     |     |     |     |     |
| ------- | ----------------------------- | :-: | :-: | :-: | :-: | :-: | :-: | :-: | :-: | :-: | :-: |
| **Uge** |                               |  1  |  2  |  3  |  4  |  5  |  6  |  7  |  8  |  9  | 10  |
|         | Case , diagrammer og concept. |  x  |     |     |     |     |     |     |     |     |     |
|         | Dokumentation                 |  x  |  x  |  x  |  x  |  x  |  x  |  x  |  x  |  x  |  x  |
|         | Research                      |  x  |  x  |     |     |     |     |     |     |     |     |
|         | MVP                           |  x  |  x  |  x  |  x  |     |     |     |     |     |     |
|         | Feedback                      |     |     |     |  x  |  x  |     |     |     |     |     |
|         |                               |     |     |     |     |     |     |     |     |     |     |


# Mockups
---
![[apples .png|300]]
Optælling af æbler
![[YOGHURT TJEK.png|300]]
Calorie tracker
![[Screenshot_20250410-095710.png]]
AI object recognition i gang.

![[Recipe AR.png]]
Cooking instructions



# Inspirationer
---
Mange af tingene er selvfølgelig inspireret af mange forskellige former for scifi og cyberpunk temaer.


### EyePhone
En af de ting som dukker op oftest i mit hoved er nok [Eyephone](https://futurama.fandom.com/wiki/EyePhone) fra futurama. 
Forhåbentlig kræver fremtidens HMD at man skal have det indsat som i serien men størrelses mæssigt er det nok ned i noget som den før at folk måske kan glemme google glass lidt igen.
![[EyePhone-Install.webp|300]]

### Iron man
De første iron man film er for mig også en inspiration i hvordan man kan få følelsen af at have holografi indtil at der bliver opfundet en teknologi der kan lave hologrammer uden at man har noget siddende på hovedet kroppen
![[Pasted image 20250410123537.png|500]]


### Microsoft hololens & Meta orion
Når nu hovedemnet i dette project handler om AR kan man ikke komme uden om at tage inspiration fra Microsofts hololens og meta quests orion. Men da den ene er discontinued og den anden koster 10.000$ så er mit håb lidt mere at bruge en quest 3 som en mere "pøbel"consumer venlig version. 

Meta orion
![[Meta-Orion.jpg|300]]
Microsoft HoloLens
![[img-Microsoft-HoloLens-2_web.jpg|400]]



# Teknik

## Hurtig test af object detection fra hugging face
Huggingface.co har et stort antal forskellige modeller man kan lege med. Her er et eksempel på hvor at jeg bare har lagt et billede fra mit køleskab op for at undersøge hvad der er tilgængeligt lige nu.![[KøleskabMockup.png|300]]


